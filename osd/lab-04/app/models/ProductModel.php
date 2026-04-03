<?php
class ProductModel
{
    private $db;
    private $table_name = "product";

    public function __construct($db)
    {
        $this->db = $db;
    }

    public function getProducts()
    {
        $query = "SELECT p.id, p.name, p.description, p.price, c.name as category_name
                  FROM " . $this->table_name . " p
                  LEFT JOIN category c ON p.category_id = c.id";

        $stmt = $this->db->prepare($query);
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_OBJ);
    }

    public function getProductById($id)
    {
        $query = "SELECT * FROM " . $this->table_name . " WHERE id = :id";

        $stmt = $this->db->prepare($query);
        $stmt->bindParam(':id', $id);
        $stmt->execute();

        return $stmt->fetch(PDO::FETCH_OBJ);
    }

    public function addProduct($name, $description, $price, $category_id)
    {
        $errors = [];

        if (empty($name)) {
            $errors['name'] = 'Tên sản phẩm không được để trống';
        }

        if (empty($description)) {
            $errors['description'] = 'Mô tả không được để trống';
        }

        if (!is_numeric($price) || $price < 0) {
            $errors['price'] = 'Giá sản phẩm không hợp lệ';
        }

        if (count($errors) > 0) {
            return $errors;
        }

        $query = "INSERT INTO " . $this->table_name . " (name, description, price, category_id)
                  VALUES (:name, :description, :price, :category_id)";

        $stmt = $this->db->prepare($query);

        $name = htmlspecialchars(strip_tags($name ?? ''));
        $description = htmlspecialchars(strip_tags($description ?? ''));
        $price = is_numeric($price) ? $price : 0;
        $category_id = htmlspecialchars(strip_tags($category_id ?? ''));

        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':price', $price);
        $stmt->bindParam(':category_id', $category_id);

        return $stmt->execute();
    }

    public function updateProduct($id, $name, $description, $price, $category_id)
    {
        $query = "UPDATE " . $this->table_name . "
                  SET name=:name, description=:description, price=:price, category_id=:category_id
                  WHERE id=:id";

        $stmt = $this->db->prepare($query);

        $name = htmlspecialchars(strip_tags($name ?? ''));
        $description = htmlspecialchars(strip_tags($description ?? ''));
        $price = is_numeric($price) ? $price : 0;
        $category_id = htmlspecialchars(strip_tags($category_id ?? ''));

        $stmt->bindParam(':id', $id);
        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':price', $price);
        $stmt->bindParam(':category_id', $category_id);

        return $stmt->execute();
    }

    public function deleteProduct($id)
    {
        $query = "DELETE FROM " . $this->table_name . " WHERE id=:id";

        $stmt = $this->db->prepare($query);
        $stmt->bindParam(':id', $id);

        return $stmt->execute();
    }

    public function isProductSold($product_id)
    {
        $query = "SELECT COUNT(*) as total 
                  FROM order_details 
                  WHERE product_id = :product_id";

        $stmt = $this->db->prepare($query);
        $stmt->bindParam(':product_id', $product_id);
        $stmt->execute();

        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        return $result['total'] > 0;
    }
}
