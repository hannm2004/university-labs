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
        $this->db           = (new Database())->getConnection();
        $this->accountModel = new AccountModel($this->db);
        $this->jwtHandler   = new JWTHandler();
    }

    public function register()
    {
        include_once 'app/views/account/register.php';
    }

    public function login()
    {
        // Nếu đã login rồi thì redirect
        if (isset($_SESSION['username']) && !empty($_SESSION['username'])) {
            header('Location: /webbanhang/Product');
            exit;
        }
        include_once 'app/views/account/login.php';
    }

    public function save()
    {
        if ($_SERVER['REQUEST_METHOD'] == 'POST') {
            $username        = $_POST['username']        ?? '';
            $fullName        = $_POST['fullname']        ?? '';
            $password        = $_POST['password']        ?? '';
            $confirmPassword = $_POST['confirmpassword'] ?? '';

            $errors = [];
            if (empty($username))  $errors['username']    = 'Vui lòng nhập tên đăng nhập!';
            if (empty($fullName))  $errors['fullname']    = 'Vui lòng nhập họ và tên!';
            if (empty($password))  $errors['password']    = 'Vui lòng nhập mật khẩu!';
            if (strlen($password) < 6 && !empty($password)) $errors['password'] = 'Mật khẩu phải có ít nhất 6 ký tự!';
            if ($password !== $confirmPassword) $errors['confirmPass'] = 'Mật khẩu xác nhận không khớp!';

            $existing = $this->accountModel->getAccountByUsername($username);
            if ($existing) $errors['account'] = 'Tên đăng nhập đã được sử dụng!';

            if (count($errors) > 0) {
                include_once 'app/views/account/register.php';
            } else {
                $hashed = password_hash($password, PASSWORD_BCRYPT, ['cost' => 12]);
                $result = $this->accountModel->save($username, $fullName, $hashed);
                if ($result) {
                    header('Location: /webbanhang/account/login?registered=1');
                    exit;
                } else {
                    $errors['system'] = 'Có lỗi xảy ra, vui lòng thử lại!';
                    include_once 'app/views/account/register.php';
                }
            }
        }
    }

    public function logout()
    {
        session_unset();
        session_destroy();
        header('Location: /webbanhang/account/login');
        exit;
    }

    /** API: POST /account/checkLogin – Trả về JWT token */
    public function checkLogin()
    {
        header('Content-Type: application/json');
        $data     = json_decode(file_get_contents("php://input"), true);
        $username = trim($data['username'] ?? '');
        $password = $data['password'] ?? '';

        if (empty($username) || empty($password)) {
            http_response_code(400);
            echo json_encode(['message' => 'Vui lòng nhập đầy đủ thông tin!']);
            return;
        }

        $user = $this->accountModel->getAccountByUsername($username);

        if ($user && password_verify($password, $user->password)) {
            $token = $this->jwtHandler->encode([
                'id'       => $user->id,
                'username' => $user->username,
                'role'     => $user->role     ?? 'user',
                'fullname' => $user->fullname ?? ''
            ]);

            // Set PHP session đồng thời để PHP pages hoạt động
            $_SESSION['username']  = $user->username;
            $_SESSION['user_role'] = $user->role ?? 'user';
            $_SESSION['fullname']  = $user->fullname ?? '';
            $_SESSION['user_id']   = $user->id;

            echo json_encode([
                'token'    => $token,
                'username' => $user->username,
                'fullname' => $user->fullname ?? '',
                'role'     => $user->role ?? 'user'
            ]);
        } else {
            http_response_code(401);
            echo json_encode(['message' => 'Sai tên đăng nhập hoặc mật khẩu!']);
        }
    }

    /** API: POST /account/logoutJWT – Xóa session phía server */
    public function logoutJWT()
    {
        session_unset();
        session_destroy();
        header('Content-Type: application/json');
        echo json_encode(['success' => true, 'message' => 'Logged out']);
    }
}
