<?php
$uri = urldecode(parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH));

// Bỏ đoạn prefix /webbanhang/ vì server chạy thẳng ở thư mục này
if (strpos($uri, '/webbanhang') === 0) {
    $uri = substr($uri, strlen('/webbanhang'));
}

if ($uri !== '/' && $uri !== '' && file_exists(__DIR__ . $uri)) {
    return false;
}

$_GET['url'] = ltrim($uri, '/');
require_once __DIR__ . '/index.php';
