<?php require_once 'vendor/autoload.php';

use \Firebase\JWT\JWT;
use \Firebase\JWT\Key;

class JWTHandler
{
    private $secret_key;
    public function __construct()
    {
        // Phải đủ 256-bit (32+ ký tự) cho firebase/php-jwt v7+ với HS256
        $this->secret_key = "HUTECH_JWT_SECRET_KEY_256BIT_2024_SECURE";
    }
    public function encode($data)
    {
        $issuedAt = time();
        $expirationTime = $issuedAt + 3600;
        $payload = array('iat' => $issuedAt,             'exp' => $expirationTime,             'data' => $data);
        return JWT::encode($payload, $this->secret_key, 'HS256');
    }
    public function decode($jwt)
    {
        try {
            $decoded = JWT::decode($jwt, new Key($this->secret_key, 'HS256'));
            return (array) $decoded->data;
        } catch (Exception $e) {
            return null;
        }
    }
}
