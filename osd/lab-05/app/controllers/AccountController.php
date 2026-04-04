<?php
require_once('app/config/database.php');
require_once('app/models/AccountModel.php');
require_once('app/utils/JWTHandler.php');
class AccountController
{
    private $accountModel;
    private $db;
    private $jwtHandler;
    public function __construct()
    {
        $this->db = (new Database())->getConnection();
        $this->accountModel = new AccountModel($this->db);
        $this->jwtHandler = new JWTHandler();
    }

    function register()
    {
        include_once 'app/views/account/register.php';
    }
    public function login()
    {
        include_once 'app/views/account/login.php';
    }

    function save()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $username = $_POST['username'] ?? '';
            $fullName = $_POST['fullname'] ?? '';
            $password = $_POST['password'] ?? '';
            $confirmPassword = $_POST['confirmpassword'] ?? '';

            $errors = [];
            if (empty($username)) {
                $errors['username'] = "Vui long nhap userName!";
            }
            if (empty($fullName)) {
                $errors['fullname'] = "Vui long nhap fullName!";
            }
            if (empty($password)) {
                $errors['password'] = "Vui long nhap password!";
            }
            if ($password != $confirmPassword) {
                $errors['confirmPass'] = "Mat khau va xac nhan chua dung";
            }

            $account = $this->accountModel->getAccountByUsername($username);

            if ($account) {
                $errors['account'] = "Tai khoan nay da co nguoi dang ky!";
            }

            if (count($errors) > 0) {
                include_once 'app/views/account/register.php';
            } else {

                $password = password_hash($password, PASSWORD_BCRYPT, ['cost' => 12]);

                $result = $this->accountModel->save($username, $fullName, $password);

                if ($result) {
                    header('Location: /webbanhang/account/login');
                    exit;
                }
            }
        }
    }
    function logout()
    {
        session_unset();
        session_destroy();
        header('Location: /webbanhang/Product');
        exit;
    }

    public function checkLogin()
    {
        header('Content-Type: application/json');
        $data = json_decode(file_get_contents("php://input"), true);
        $username = $data['username'] ?? '';
        $password = $data['password'] ?? '';
        $user = $this->accountModel->getAccountByUserName($username);
        if ($user && password_verify($password, $user->password)) {
            // Set PHP Session for Backend validation
            $_SESSION['username'] = $user->username;
            $_SESSION['user_role'] = $user->role;
            $_SESSION['user_id'] = $user->id;

            $token = $this->jwtHandler->encode(['id' => $user->id, 'username' => $user->username]);
            echo json_encode(['token' => $token]);
        } else {
            http_response_code(401);
            echo json_encode(['message' => 'Invalid credentials']);
        }
    }
}
