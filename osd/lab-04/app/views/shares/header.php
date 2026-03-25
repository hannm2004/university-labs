<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Quản lý sản phẩm</title>

    <!-- Bootstrap -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">

    <style>
        body {
            background-color: #f8f9fa;
        }

        .navbar {
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
        }

        .product-image {
            max-width: 100px;
            height: auto;
        }
    </style>
</head>

<body>

    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
        <a class="navbar-brand font-weight-bold" href="/webbanhang/Product/">🛒 Web Bán Hàng</a>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav mr-auto">

                <li class="nav-item">
                    <a class="nav-link" href="/webbanhang/Product/">Danh sách sản phẩm</a>
                </li>

                <li class="nav-item">
                    <a class="nav-link" href="/webbanhang/Product/add">Thêm sản phẩm</a>
                </li>

                <?php if (SessionHelper::isLoggedIn()): ?>
                    <li class="nav-item">
                        <a class="nav-link" href="/webbanhang/Order/history">Lịch sử đơn hàng</a>
                    </li>
                <?php endif; ?>

            </ul>

            <!-- Bên phải -->
            <ul class="navbar-nav">

                <?php if (SessionHelper::isLoggedIn()): ?>
                    <li class="nav-item">
                        <span class="nav-link text-white">
                            👋 Xin chào, <?php echo $_SESSION['username']; ?>
                        </span>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="/webbanhang/account/logout">Logout</a>
                    </li>
                <?php else: ?>
                    <li class="nav-item">
                        <a class="nav-link" href="/webbanhang/account/login">Login</a>
                    </li>
                <?php endif; ?>

            </ul>
        </div>
    </nav>

    <div class="container mt-4">