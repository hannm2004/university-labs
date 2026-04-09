<?php
require_once('app/config/database.php');
require_once('app/models/ProductModel.php');
require_once('app/models/CategoryModel.php');
require_once('app/helpers/SessionHelper.php');

class ProductController
{
    private $productModel;
    private $db;

    public function __construct()
    {
        $this->db           = (new Database())->getConnection();
        $this->productModel = new ProductModel($this->db);
    }

    public function index()
    {
        $products = $this->productModel->getProducts();
        include 'app/views/product/list.php';
    }

    public function list()
    {
        $this->index();
    }

    public function show($id)
    {
        $product = $this->productModel->getProductById($id);
        if ($product) {
            include 'app/views/product/show.php';
        } else {
            echo '<div style="text-align:center;padding:60px;color:#94a3b8">Không tìm thấy sản phẩm.</div>';
        }
    }

    public function add()
    {
        SessionHelper::requireAdmin();
        $categories = (new CategoryModel($this->db))->getCategories();
        include_once 'app/views/product/add.php';
    }

    public function save()
    {
        SessionHelper::requireAdmin();
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $name        = $_POST['name']        ?? '';
            $description = $_POST['description'] ?? '';
            $price       = $_POST['price']       ?? '';
            $category_id = $_POST['category_id'] ?? null;
            $image       = '';

            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                try { $image = $this->uploadImage($_FILES['image']); } catch (\Exception $e) { $image = ''; }
            }

            $result = $this->productModel->addProduct($name, $description, $price, $category_id, $image ?: null);

            if (is_array($result)) {
                $errors     = $result;
                $categories = (new CategoryModel($this->db))->getCategories();
                include 'app/views/product/add.php';
            } else {
                header('Location: /webbanhang/Product');
            }
        }
    }

    public function edit($id = null)
    {
        SessionHelper::requireAdmin();
        if (!$id) { header('Location: /webbanhang/Product'); exit; }
        $product    = $this->productModel->getProductById($id);
        $categories = (new CategoryModel($this->db))->getCategories();
        $editId     = $id;
        if ($product) {
            include 'app/views/product/edit.php';
        } else {
            header('Location: /webbanhang/Product');
        }
    }

    public function update()
    {
        SessionHelper::requireAdmin();
        if ($_SERVER['REQUEST_METHOD'] === 'POST') {
            $id          = $_POST['id'];
            $name        = $_POST['name'];
            $description = $_POST['description'];
            $price       = $_POST['price'];
            $category_id = $_POST['category_id'];
            $image       = null;

            if (isset($_FILES['image']) && $_FILES['image']['error'] == 0) {
                try { $image = $this->uploadImage($_FILES['image']); } catch (\Exception $e) { $image = null; }
            } else {
                $image = $_POST['existing_image'] ?? null;
            }

            $edit = $this->productModel->updateProduct($id, $name, $description, $price, $category_id, $image);
            if ($edit) {
                header('Location: /webbanhang/Product');
            } else {
                $errors     = ['system' => 'Lỗi khi lưu sản phẩm!'];
                $product    = $this->productModel->getProductById($id);
                $categories = (new CategoryModel($this->db))->getCategories();
                $editId     = $id;
                include 'app/views/product/edit.php';
            }
        }
    }

    public function delete($id)
    {
        SessionHelper::requireAdmin();
        if ($this->productModel->isProductSold($id)) {
            header('Location: /webbanhang/Product?error=sold');
            exit;
        }
        if ($this->productModel->deleteProduct($id)) {
            header('Location: /webbanhang/Product?success=deleted');
        } else {
            header('Location: /webbanhang/Product?error=delete_failed');
        }
    }

    private function uploadImage($file)
    {
        $target_dir = 'uploads/';
        if (!is_dir($target_dir)) mkdir($target_dir, 0777, true);

        $ext = strtolower(pathinfo($file["name"], PATHINFO_EXTENSION));
        $allowed = ['jpg', 'jpeg', 'png', 'gif', 'webp'];

        if ($file["size"] > 10 * 1024 * 1024) throw new \Exception("Ảnh quá lớn (max 10MB)");
        if (!in_array($ext, $allowed))         throw new \Exception("Chỉ cho phép JPG, PNG, GIF, WEBP");
        if (!getimagesize($file["tmp_name"]))  throw new \Exception("File không phải hình ảnh");

        $filename    = uniqid('img_', true) . '.' . $ext;
        $target_file = $target_dir . $filename;

        if (!move_uploaded_file($file["tmp_name"], $target_file)) {
            throw new \Exception("Lỗi upload ảnh");
        }
        return $target_file;
    }

    public function addToCart($id)
    {
        $product = $this->productModel->getProductById($id);
        if (!$product) { header('Location: /webbanhang/Product'); exit; }

        if (!isset($_SESSION['cart'])) $_SESSION['cart'] = [];

        if (isset($_SESSION['cart'][$id])) {
            $_SESSION['cart'][$id]['quantity']++;
        } else {
            $_SESSION['cart'][$id] = [
                'name'     => $product->name,
                'price'    => $product->price,
                'quantity' => 1,
                'image'    => $product->image ?? ''
            ];
        }
        header('Location: /webbanhang/Product/cart');
    }

    public function cart()
    {
        $cart = isset($_SESSION['cart']) ? $_SESSION['cart'] : [];
        include 'app/views/product/cart.php';
    }

    public function checkout()
    {
        SessionHelper::requireLogin();
        include 'app/views/product/checkout.php';
    }

    public function processCheckout()
    {
        SessionHelper::requireLogin();
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $name    = $_POST['name']    ?? '';
            $phone   = $_POST['phone']   ?? '';
            $address = $_POST['address'] ?? '';

            if (!isset($_SESSION['cart']) || empty($_SESSION['cart'])) {
                header('Location: /webbanhang/Product/cart');
                exit;
            }

            $this->db->beginTransaction();
            try {
                $user_id = $_SESSION['user_id'] ?? null;
                $stmt = $this->db->prepare("INSERT INTO orders (user_id, name, phone, address) VALUES (:user_id, :name, :phone, :address)");
                $stmt->bindParam(':user_id',  $user_id);
                $stmt->bindParam(':name',     $name);
                $stmt->bindParam(':phone',    $phone);
                $stmt->bindParam(':address',  $address);
                $stmt->execute();
                $order_id = $this->db->lastInsertId();

                foreach ($_SESSION['cart'] as $product_id => $item) {
                    $s2 = $this->db->prepare("INSERT INTO order_details (order_id, product_id, quantity, price) VALUES (:order_id, :product_id, :quantity, :price)");
                    $s2->bindParam(':order_id',   $order_id);
                    $s2->bindParam(':product_id', $product_id);
                    $s2->bindParam(':quantity',   $item['quantity']);
                    $s2->bindParam(':price',      $item['price']);
                    $s2->execute();
                }

                unset($_SESSION['cart']);
                $this->db->commit();
                header('Location: /webbanhang/Product/orderConfirmation');
            } catch (\Exception $e) {
                $this->db->rollBack();
                echo 'Lỗi: ' . $e->getMessage();
            }
        }
    }

    public function orderConfirmation()
    {
        include 'app/views/product/orderConfirmation.php';
    }
}
