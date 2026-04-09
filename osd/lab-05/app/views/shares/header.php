<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ShopHub – Quản lý sản phẩm</title>
    <meta name="description" content="Hệ thống quản lý sản phẩm trực tuyến, xác thực JWT bảo mật.">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
    <style>
        :root {
            --primary:    #6366f1;
            --primary-d:  #4f46e5;
            --secondary:  #10b981;
            --danger:     #ef4444;
            --warning:    #f59e0b;
            --dark:       #0f172a;
            --dark-2:     #1e293b;
            --dark-3:     #334155;
            --light:      #f8fafc;
            --muted:      #94a3b8;
            --border:     rgba(255,255,255,0.08);
            --card-bg:    rgba(30,41,59,0.85);
            --radius:     14px;
            --shadow:     0 4px 24px rgba(0,0,0,0.25);
            --transition: all 0.25s cubic-bezier(0.4,0,0.2,1);
        }
        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }
        body {
            font-family: 'Inter', sans-serif;
            background: #0f172a;
            color: #e2e8f0;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }

        /* ===== NAVBAR ===== */
        .navbar {
            position: sticky;
            top: 0;
            z-index: 1000;
            background: rgba(15,23,42,0.92);
            backdrop-filter: blur(16px);
            -webkit-backdrop-filter: blur(16px);
            border-bottom: 1px solid var(--border);
            padding: 0 24px;
            height: 64px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 16px;
        }
        .navbar-brand {
            display: flex;
            align-items: center;
            gap: 10px;
            text-decoration: none;
            font-size: 20px;
            font-weight: 800;
            color: #fff;
            letter-spacing: -0.5px;
        }
        .navbar-brand .brand-icon {
            width: 36px; height: 36px;
            background: linear-gradient(135deg, var(--primary), #818cf8);
            border-radius: 10px;
            display: flex; align-items: center; justify-content: center;
            font-size: 18px;
        }
        .navbar-brand span { color: var(--primary); }
        .navbar-nav {
            display: flex; align-items: center; gap: 4px; list-style: none;
            flex: 1; margin: 0 24px;
        }
        .nav-link {
            padding: 7px 14px;
            border-radius: 8px;
            text-decoration: none;
            color: var(--muted);
            font-size: 14px;
            font-weight: 500;
            transition: var(--transition);
            display: flex; align-items: center; gap: 6px;
        }
        .nav-link:hover, .nav-link.active { color: #fff; background: rgba(255,255,255,0.08); }
        .nav-link i { font-size: 13px; }

        /* Cart badge */
        .cart-badge {
            position: relative;
            display: inline-flex;
        }
        .badge-count {
            position: absolute;
            top: -6px; right: -6px;
            width: 18px; height: 18px;
            background: var(--danger);
            border-radius: 50%;
            font-size: 10px;
            font-weight: 700;
            display: flex; align-items: center; justify-content: center;
            color: #fff;
        }

        /* User menu */
        .navbar-actions { display: flex; align-items: center; gap: 12px; }
        .user-chip {
            display: flex; align-items: center; gap: 8px;
            background: rgba(99,102,241,0.15);
            border: 1px solid rgba(99,102,241,0.3);
            border-radius: 100px;
            padding: 6px 14px 6px 8px;
            cursor: default;
        }
        .user-avatar {
            width: 28px; height: 28px;
            background: linear-gradient(135deg, var(--primary), #818cf8);
            border-radius: 50%;
            display: flex; align-items: center; justify-content: center;
            font-size: 12px; font-weight: 700; color: #fff;
        }
        .user-name { font-size: 13px; font-weight: 600; color: #c7d2fe; }
        .role-badge {
            font-size: 10px; font-weight: 700; padding: 2px 6px;
            border-radius: 100px; text-transform: uppercase;
        }
        .role-admin { background: rgba(239,68,68,0.2); color: #fca5a5; }
        .role-user  { background: rgba(16,185,129,0.2); color: #6ee7b7; }

        .btn-logout {
            padding: 7px 16px;
            background: rgba(239,68,68,0.15);
            border: 1px solid rgba(239,68,68,0.3);
            border-radius: 8px;
            color: #fca5a5;
            font-size: 13px; font-weight: 600;
            cursor: pointer; text-decoration: none;
            transition: var(--transition);
            display: flex; align-items: center; gap: 6px;
        }
        .btn-logout:hover { background: rgba(239,68,68,0.3); color: #fecaca; }

        .btn-login-nav {
            padding: 7px 20px;
            background: var(--primary);
            border-radius: 8px;
            color: #fff; font-size: 13px; font-weight: 600;
            text-decoration: none; transition: var(--transition);
            display: flex; align-items: center; gap: 6px;
        }
        .btn-login-nav:hover { background: var(--primary-d); }

        /* ===== MAIN ===== */
        main { flex: 1; padding: 32px 24px; max-width: 1280px; margin: 0 auto; width: 100%; }

        /* ===== TOAST ===== */
        .toast-container {
            position: fixed; top: 80px; right: 20px; z-index: 9999;
            display: flex; flex-direction: column; gap: 10px;
        }
        .toast {
            background: var(--dark-2);
            border: 1px solid var(--border);
            border-radius: 12px;
            padding: 14px 20px;
            display: flex; align-items: center; gap: 10px;
            min-width: 280px;
            box-shadow: var(--shadow);
            animation: toastIn 0.35s cubic-bezier(0.16,1,0.3,1);
        }
        .toast.success { border-left: 3px solid var(--secondary); }
        .toast.error   { border-left: 3px solid var(--danger); }
        .toast.info    { border-left: 3px solid var(--primary); }
        .toast-icon { font-size: 18px; }
        .toast-msg  { font-size: 14px; font-weight: 500; color: #e2e8f0; }
        @keyframes toastIn {
            from { opacity:0; transform: translateX(20px); }
            to   { opacity:1; transform: translateX(0); }
        }

        /* ===== MODAL ===== */
        .modal-backdrop {
            display: none; position: fixed; inset: 0;
            background: rgba(0,0,0,0.7); z-index: 2000;
            backdrop-filter: blur(4px);
            align-items: center; justify-content: center;
        }
        .modal-backdrop.open { display: flex; }
        .modal {
            background: var(--dark-2);
            border: 1px solid var(--border);
            border-radius: 20px;
            padding: 32px;
            width: 90%; max-width: 520px;
            box-shadow: 0 30px 80px rgba(0,0,0,0.5);
            animation: modalIn 0.3s cubic-bezier(0.16,1,0.3,1);
        }
        @keyframes modalIn {
            from { opacity:0; transform: scale(0.9) translateY(20px); }
            to   { opacity:1; transform: scale(1) translateY(0); }
        }
        .modal-header { display: flex; align-items: center; justify-content: space-between; margin-bottom: 24px; }
        .modal-title  { font-size: 20px; font-weight: 700; color: #fff; }
        .modal-close  {
            background: none; border: none; cursor: pointer;
            color: var(--muted); font-size: 20px; transition: var(--transition);
        }
        .modal-close:hover { color: #fff; }

        /* ===== FORM CONTROLS ===== */
        .form-group { margin-bottom: 18px; }
        .form-label { display: block; font-size: 13px; font-weight: 600; color: var(--muted); margin-bottom: 8px; letter-spacing: 0.3px; text-transform: uppercase; }
        .form-control {
            width: 100%; padding: 11px 14px;
            background: rgba(255,255,255,0.05);
            border: 1px solid rgba(255,255,255,0.1);
            border-radius: 10px;
            color: #e2e8f0; font-size: 15px; font-family: 'Inter', sans-serif;
            outline: none; transition: var(--transition);
        }
        .form-control:focus {
            border-color: var(--primary);
            background: rgba(99,102,241,0.08);
            box-shadow: 0 0 0 3px rgba(99,102,241,0.2);
        }
        .form-control::placeholder { color: rgba(255,255,255,0.25); }
        select.form-control option { background: var(--dark-2); color: #e2e8f0; }
        textarea.form-control { resize: vertical; min-height: 100px; }

        /* ===== BUTTONS ===== */
        .btn {
            display: inline-flex; align-items: center; gap: 8px;
            padding: 10px 20px; border-radius: 10px;
            font-size: 14px; font-weight: 600; font-family: 'Inter', sans-serif;
            cursor: pointer; text-decoration: none; border: none;
            transition: var(--transition); white-space: nowrap;
        }
        .btn-primary { background: var(--primary); color: #fff; }
        .btn-primary:hover { background: var(--primary-d); transform: translateY(-1px); box-shadow: 0 6px 20px rgba(99,102,241,0.4); }
        .btn-success { background: var(--secondary); color: #fff; }
        .btn-success:hover { background: #059669; transform: translateY(-1px); box-shadow: 0 6px 20px rgba(16,185,129,0.4); }
        .btn-danger  { background: var(--danger); color: #fff; }
        .btn-danger:hover  { background: #dc2626; transform: translateY(-1px); }
        .btn-warning { background: var(--warning); color: #000; }
        .btn-warning:hover { background: #d97706; transform: translateY(-1px); }
        .btn-ghost {
            background: rgba(255,255,255,0.06);
            border: 1px solid rgba(255,255,255,0.1);
            color: #e2e8f0;
        }
        .btn-ghost:hover { background: rgba(255,255,255,0.1); }
        .btn-sm { padding: 6px 12px; font-size: 12px; border-radius: 8px; }
        .btn:disabled { opacity: 0.5; cursor: not-allowed; transform: none !important; }

        /* ===== PAGE HEADER ===== */
        .page-header {
            display: flex; align-items: center; justify-content: space-between;
            margin-bottom: 28px; flex-wrap: wrap; gap: 16px;
        }
        .page-title { font-size: 28px; font-weight: 800; color: #fff; letter-spacing: -0.5px; }
        .page-subtitle { font-size: 14px; color: var(--muted); margin-top: 4px; }

        /* ===== CARD ===== */
        .card {
            background: var(--card-bg);
            border: 1px solid var(--border);
            border-radius: var(--radius);
            overflow: hidden;
            transition: var(--transition);
        }
        .card:hover { border-color: rgba(99,102,241,0.3); transform: translateY(-2px); box-shadow: var(--shadow); }

        /* ===== LOADING ===== */
        .spinner-wrap { text-align: center; padding: 60px; color: var(--muted); }
        .spinner {
            display: inline-block; width: 36px; height: 36px;
            border: 3px solid rgba(255,255,255,0.1);
            border-top-color: var(--primary);
            border-radius: 50%;
            animation: spin 0.8s linear infinite;
        }
        @keyframes spin { to { transform: rotate(360deg); } }

        /* ===== EMPTY STATE ===== */
        .empty-state { text-align: center; padding: 80px 20px; }
        .empty-state i { font-size: 60px; color: var(--dark-3); margin-bottom: 16px; }
        .empty-state h3 { font-size: 20px; color: var(--muted); margin-bottom: 8px; }
        .empty-state p { font-size: 14px; color: var(--dark-3); }

        /* ===== RESPONSIVE ===== */
        @media (max-width: 768px) {
            .navbar { padding: 0 16px; }
            .navbar-nav { display: none; }
            main { padding: 20px 16px; }
        }
    </style>
</head>
<body>

<div class="toast-container" id="toast-container"></div>

<nav class="navbar">
    <a href="/webbanhang/Product" class="navbar-brand">
        <div class="brand-icon">🛒</div>
        Shop<span>Hub</span>
    </a>

    <ul class="navbar-nav" id="main-nav">
        <li>
            <a href="/webbanhang/Product" class="nav-link">
                <i class="fas fa-box"></i> Sản phẩm
            </a>
        </li>
        <li id="nav-cart" style="display:none">
            <a href="/webbanhang/Product/cart" class="nav-link">
                <span class="cart-badge">
                    <i class="fas fa-shopping-cart"></i>
                    <span class="badge-count" id="cart-count" style="display:none">0</span>
                </span>
                Giỏ hàng
            </a>
        </li>
        <li id="nav-order" style="display:none">
            <a href="/webbanhang/Order/history" class="nav-link">
                <i class="fas fa-clipboard-list"></i> Đơn hàng
            </a>
        </li>
        <li id="nav-admin-add" style="display:none">
            <a href="#" class="nav-link" onclick="openAddModal(); return false;">
                <i class="fas fa-plus-circle"></i> Thêm sản phẩm
            </a>
        </li>
    </ul>

    <div class="navbar-actions">
        <!-- Khi chưa login -->
        <a href="/webbanhang/account/login" class="btn-login-nav" id="nav-login-btn">
            <i class="fas fa-sign-in-alt"></i> Đăng nhập
        </a>

        <!-- Khi đã login -->
        <div id="nav-user-info" style="display:none; align-items:center; gap:10px;">
            <div class="user-chip">
                <div class="user-avatar" id="nav-avatar">A</div>
                <span class="user-name" id="nav-username">Admin</span>
                <span class="role-badge" id="nav-role-badge">user</span>
            </div>
            <a href="#" class="btn-logout" onclick="doLogout(); return false;">
                <i class="fas fa-sign-out-alt"></i> Đăng xuất
            </a>
        </div>
    </div>
</nav>

<main>
<!-- Content goes here -->

<script>
    // ===== AUTH STATE =====
    function getToken()    { return localStorage.getItem('jwtToken'); }
    function getUsername() { return localStorage.getItem('username') || ''; }
    function getRole()     { return localStorage.getItem('role') || 'user'; }
    function getFullname() { return localStorage.getItem('fullname') || getUsername(); }
    function isAdmin()     { return getRole() === 'admin'; }
    function isLoggedIn()  { return !!getToken(); }

    function doLogout() {
        localStorage.removeItem('jwtToken');
        localStorage.removeItem('username');
        localStorage.removeItem('fullname');
        localStorage.removeItem('role');
        fetch('/webbanhang/account/logoutJWT', { method: 'POST' }).finally(() => {
            window.location.href = '/webbanhang/account/login';
        });
    }

    function authHeaders() {
        const token = getToken();
        return token ? { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + token }
                     : { 'Content-Type': 'application/json' };
    }

    // ===== TOAST =====
    function showToast(msg, type = 'info') {
        const icons = { success: '✅', error: '❌', info: 'ℹ️', warning: '⚠️' };
        const tc = document.getElementById('toast-container');
        const t  = document.createElement('div');
        t.className = 'toast ' + type;
        t.innerHTML = `<span class="toast-icon">${icons[type]||'ℹ️'}</span><span class="toast-msg">${msg}</span>`;
        tc.appendChild(t);
        setTimeout(() => { t.style.opacity='0'; t.style.transform='translateX(20px)'; setTimeout(() => t.remove(), 300); }, 3500);
    }

    // ===== UPDATE NAVBAR =====
    document.addEventListener('DOMContentLoaded', function () {
        if (isLoggedIn()) {
            document.getElementById('nav-login-btn').style.display   = 'none';
            const ui = document.getElementById('nav-user-info');
            ui.style.display = 'flex';
            document.getElementById('nav-username').textContent = getFullname() || getUsername();
            const av = document.getElementById('nav-avatar');
            av.textContent = (getFullname() || getUsername()).charAt(0).toUpperCase();
            const rb = document.getElementById('nav-role-badge');
            rb.textContent = getRole();
            rb.className   = 'role-badge role-' + getRole();

            // Hiển thị Cart và Order menu
            document.getElementById('nav-cart').style.display = 'list-item';
            document.getElementById('nav-order').style.display = 'list-item';

            if (isAdmin()) {
                document.getElementById('nav-admin-add').style.display = 'list-item';
            }
        }
        // update cart count
        updateCartCount();
    });

    function updateCartCount() {
        // Cart count from session (PHP sets it) — update via simple check
        const cartCountEl = document.getElementById('cart-count');
        if (!cartCountEl) return;
        // We'll leave this for pages that manage their own cart
    }
</script>