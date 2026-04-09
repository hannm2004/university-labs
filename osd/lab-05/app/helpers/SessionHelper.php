<?php
class SessionHelper
{
    public static function isLoggedIn()
    {
        return isset($_SESSION['username']) && !empty($_SESSION['username']);
    }

    public static function isAdmin()
    {
        return isset($_SESSION['user_role']) && $_SESSION['user_role'] === 'admin';
    }

    public static function getUsername()
    {
        return $_SESSION['username'] ?? '';
    }

    public static function getFullname()
    {
        return $_SESSION['fullname'] ?? $_SESSION['username'] ?? '';
    }

    public static function getUserRole()
    {
        return $_SESSION['user_role'] ?? 'guest';
    }

    public static function requireLogin()
    {
        if (!self::isLoggedIn()) {
            header('Location: /webbanhang/account/login');
            exit;
        }
    }

    public static function requireAdmin()
    {
        if (!self::isLoggedIn()) {
            header('Location: /webbanhang/account/login');
            exit;
        }
        if (!self::isAdmin()) {
            http_response_code(403);
            include 'app/views/shares/403.php';
            exit;
        }
    }
}
