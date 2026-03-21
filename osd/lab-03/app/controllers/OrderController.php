<?php
require_once('app/models/OrderModel.php');
require_once('app/helpers/SessionHelper.php');
require_once('app/config/database.php');
class OrderController
{
    private $orderModel;

    public function __construct()
    {
        $this->orderModel = new OrderModel((new Database())->getConnection());
    }

    public function history()
    {
        if (!SessionHelper::isLoggedIn()) {
            die("Bạn cần đăng nhập!");
        }

        if (SessionHelper::isAdmin()) {
            $orders = $this->orderModel->getAllOrders();
        } else {
            $user_id = $_SESSION['user_id'];
            $orders = $this->orderModel->getOrdersByUser($user_id);
        }

        include 'app/views/order/history.php';
    }

    public function updateStatus()
{

    if (!SessionHelper::isAdmin()) {
        die("Bạn không có quyền!");
    }

    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $order_id = $_POST['order_id'];
        $status = $_POST['status'];

        $this->orderModel->updateStatus($order_id, $status);

        header('Location: /webbanhang/Order/history');
    }
}
}