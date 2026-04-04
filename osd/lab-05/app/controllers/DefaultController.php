<?php
require_once 'app/config/database.php';
require_once 'app/models/ProductModel.php';

class DefaultController
{
    private $productModel;
    private $db;

    public function __construct()
    {
        $this->db = (new Database())->getConnection();
        $this->productModel = new ProductModel($this->db);
    }

    public function index()
    {
        // Fetch products for the homepage
        $products = $this->productModel->getProducts();
        
        include 'app/views/shares/header.php';
        include 'app/views/home/index.php';
        include 'app/views/shares/footer.php';
    }
}
