<?php
require_once('app/config/database.php');
require_once('app/models/ProductModel.php');
require_once('app/models/CategoryModel.php');
require_once('app/utils/JWTHandler.php');

class ProductApiController
{
    private $productModel;
    private $db;
    private $jwtHandler;

    public function __construct()
    {
        $this->db           = (new Database())->getConnection();
        $this->productModel = new ProductModel($this->db);
        $this->jwtHandler   = new JWTHandler();
    }

    /** Lấy JWT decoded data từ Authorization header */
    private function getAuthUser()
    {
        $headers = function_exists('apache_request_headers')
            ? apache_request_headers()
            : $this->getRequestHeaders();

        $authHeader = $headers['Authorization'] ?? $headers['authorization'] ?? '';

        if (!$authHeader) return null;

        $parts = explode(' ', $authHeader);
        $jwt   = $parts[1] ?? null;
        if (!$jwt) return null;

        return $this->jwtHandler->decode($jwt);
    }

    /** Fallback lấy headers khi apache_request_headers không có */
    private function getRequestHeaders()
    {
        $headers = [];
        foreach ($_SERVER as $key => $value) {
            if (substr($key, 0, 5) === 'HTTP_') {
                $header = str_replace('_', '-', ucwords(strtolower(substr($key, 5)), '_'));
                $headers[$header] = $value;
            }
        }
        return $headers;
    }

    private function requireAuth()
    {
        $user = $this->getAuthUser();
        if (!$user) {
            http_response_code(401);
            echo json_encode(['message' => 'Unauthorized – Vui lòng đăng nhập']);
            exit;
        }
        return $user;
    }

    private function requireAdmin()
    {
        $user = $this->requireAuth();
        if (($user['role'] ?? 'user') !== 'admin') {
            http_response_code(403);
            echo json_encode(['message' => 'Forbidden – Chỉ admin mới có quyền này']);
            exit;
        }
        return $user;
    }

    /** GET /api/product – Cần đăng nhập */
    public function index()
    {
        $this->requireAuth();
        header('Content-Type: application/json');
        $products = $this->productModel->getProducts();
        echo json_encode($products);
    }

    /** GET /api/product/:id – Public */
    public function show($id)
    {
        header('Content-Type: application/json');
        $product = $this->productModel->getProductById($id);
        if ($product) {
            echo json_encode($product);
        } else {
            http_response_code(404);
            echo json_encode(['message' => 'Không tìm thấy sản phẩm']);
        }
    }

    /** POST /api/product – Chỉ admin */
    public function store()
    {
        $this->requireAdmin();
        header('Content-Type: application/json');

        $data        = json_decode(file_get_contents("php://input"), true);
        $name        = $data['name']        ?? '';
        $description = $data['description'] ?? '';
        $price       = $data['price']       ?? '';
        $category_id = $data['category_id'] ?? null;

        $result = $this->productModel->addProduct($name, $description, $price, $category_id, null);
        if (is_array($result)) {
            http_response_code(400);
            echo json_encode(['errors' => $result]);
        } else {
            http_response_code(201);
            echo json_encode(['message' => 'Product created successfully']);
        }
    }

    /** PUT /api/product/:id – Chỉ admin */
    public function update($id)
    {
        $this->requireAdmin();
        header('Content-Type: application/json');

        $data        = json_decode(file_get_contents('php://input'), true);
        $name        = $data['name']        ?? '';
        $description = $data['description'] ?? '';
        $price       = $data['price']       ?? '';
        $category_id = $data['category_id'] ?? null;

        $result = $this->productModel->updateProduct($id, $name, $description, $price, $category_id, null);
        if ($result) {
            echo json_encode(['message' => 'Product updated successfully']);
        } else {
            http_response_code(400);
            echo json_encode(['message' => 'Cập nhật thất bại']);
        }
    }

    /** DELETE /api/product/:id – Chỉ admin */
    public function destroy($id)
    {
        $this->requireAdmin();
        header('Content-Type: application/json');

        if ($this->productModel->isProductSold($id)) {
            http_response_code(400);
            echo json_encode(['message' => 'Sản phẩm đã được bán, không thể xóa!']);
            return;
        }

        $result = $this->productModel->deleteProduct($id);
        if ($result) {
            echo json_encode(['message' => 'Product deleted successfully']);
        } else {
            http_response_code(400);
            echo json_encode(['message' => 'Xóa thất bại']);
        }
    }
}
