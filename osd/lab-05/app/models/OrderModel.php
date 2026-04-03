<?php
class OrderModel
{
    private $conn;

    public function __construct($db)
    {
        $this->conn = $db;
    }

    // Lấy đơn hàng theo user
    public function getOrdersByUser($user_id)
    {
        $query = "SELECT * FROM orders WHERE user_id = :user_id ORDER BY id DESC";
        $stmt = $this->conn->prepare($query);
        $stmt->bindParam(':user_id', $user_id);
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_OBJ);
    }

    // Admin: lấy tất cả
    public function getAllOrders()
    {
        $query = "SELECT * FROM orders ORDER BY id DESC";
        return $this->conn->query($query)->fetchAll(PDO::FETCH_OBJ);
    }

    public function updateStatus($order_id, $status)
{
    $query = "UPDATE orders SET status = :status WHERE id = :id";
    $stmt = $this->conn->prepare($query);

    $stmt->bindParam(':status', $status);
    $stmt->bindParam(':id', $order_id);

    return $stmt->execute();
}
}