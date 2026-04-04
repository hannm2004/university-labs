<!DOCTYPE html>
<html lang="vi">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>TechStore - Thiết bị điện tử</title>
    <!-- Google Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        :root {
            --primary-color: #6366f1;
            --primary-hover: #4f46e5;
            --secondary-color: #ec4899;
            --bg-color: #f8fafc;
            --text-main: #1e293b;
            --text-muted: #64748b;
        }

        body {
            font-family: 'Outfit', sans-serif;
            background-color: var(--bg-color);
            color: var(--text-main);
            -webkit-font-smoothing: antialiased;
        }

        /* Navbar enhancements */
        .navbar {
            background: rgba(255, 255, 255, 0.8) !important;
            backdrop-filter: blur(12px);
            -webkit-backdrop-filter: blur(12px);
            box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.05), 0 2px 4px -1px rgba(0, 0, 0, 0.03);
            border-bottom: 1px solid rgba(255, 255, 255, 0.3);
            transition: all 0.3s ease;
        }

        .navbar-brand {
            font-weight: 800;
            background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            font-size: 1.5rem;
            letter-spacing: -0.5px;
        }

        .nav-link {
            font-weight: 500;
            color: var(--text-main) !important;
            transition: color 0.2s ease, transform 0.2s ease;
        }

        .nav-link:hover {
            color: var(--primary-color) !important;
            transform: translateY(-1px);
        }

        /* Buttons & utility */
        .btn-custom {
            background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
            color: white;
            border: none;
            border-radius: 8px;
            font-weight: 500;
            padding: 8px 24px;
            box-shadow: 0 4px 14px 0 rgba(99, 102, 241, 0.39);
            transition: all 0.3s ease;
        }

        .btn-custom:hover {
            transform: translateY(-2px);
            box-shadow: 0 6px 20px rgba(99, 102, 241, 0.4);
            color: white;
        }

        .btn-outline-custom {
            color: var(--primary-color);
            border: 2px solid var(--primary-color);
            border-radius: 8px;
            font-weight: 600;
            transition: all 0.3s ease;
            padding: 6px 24px;
        }

        .btn-outline-custom:hover {
            background-color: var(--primary-color);
            color: white;
        }
        
        .product-image {
            max-width: 100px;
            height: auto;
            border-radius: 8px;
            object-fit: cover;
        }

        .container.mt-4 {
            min-height: 80vh; /* Make sure footer stays at bottom */
        }
    </style>
</head>

<body>
    <nav class="navbar navbar-expand-lg navbar-light sticky-top"> 
        <div class="container">
            <a class="navbar-brand" href="/webbanhang/">TechStore</a> 
            <button class="navbar-toggler pr-0 border-0" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation"> 
                <span class="navbar-toggler-icon"></span> 
            </button>
            
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"> <a class="nav-link" href="/webbanhang/Product/">Cửa hàng</a> </li>
                    <li class="nav-item"> <a class="nav-link" href="/webbanhang/Product/add">Thêm sản phẩm</a> </li>
                </ul>
                <ul class="navbar-nav ml-auto align-items-center">
                    <li class="nav-item mr-3"> <a class="btn btn-outline-custom btn-sm" href="/webbanhang/Product/cart">🛒 Giỏ hàng</a> </li>
                    <li class="nav-item" id="nav-login"> <a class="btn btn-custom btn-sm" href="/webbanhang/account/login">Đăng nhập</a> </li>
                    <li class="nav-item" id="nav-logout" style="display: none;"> <a class="nav-link text-danger font-weight-bold" href="#" onclick="logout()">Đăng xuất</a> </li>
                </ul>
            </div>
        </div>
    </nav>
    <script>
        function logout() {
            localStorage.removeItem('jwtToken');
            location.href = '/webbanhang/account/logout';
        }
        document.addEventListener("DOMContentLoaded", function() {
            const token = localStorage.getItem('jwtToken');
            if (token) {
                document.getElementById('nav-login').style.display = 'none';
                document.getElementById('nav-logout').style.display = 'block';
            } else {
                document.getElementById('nav-login').style.display = 'block';
                document.getElementById('nav-logout').style.display = 'none';
            }
        });
    </script>
    <main class="main-content">