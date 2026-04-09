<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng nhập – Quản lý sản phẩm</title>
    <meta name="description" content="Đăng nhập vào hệ thống quản lý sản phẩm, bảo mật bằng JWT Token.">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    <style>
        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

        body {
            font-family: 'Inter', sans-serif;
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            background: linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%);
            overflow: hidden;
        }

        /* Animated background blobs */
        .bg-blob {
            position: fixed;
            border-radius: 50%;
            filter: blur(80px);
            opacity: 0.35;
            animation: float 8s ease-in-out infinite;
            pointer-events: none;
            z-index: 0;
        }
        .bg-blob-1 { width: 420px; height: 420px; background: #7c3aed; top: -100px; left: -100px; animation-delay: 0s; }
        .bg-blob-2 { width: 300px; height: 300px; background: #2563eb; bottom: -80px; right: -80px; animation-delay: 3s; }
        .bg-blob-3 { width: 200px; height: 200px; background: #ec4899; top: 50%; left: 50%; transform: translate(-50%,-50%); animation-delay: 1.5s; }

        @keyframes float {
            0%, 100% { transform: translateY(0) scale(1); }
            50% { transform: translateY(-30px) scale(1.05); }
        }

        /* Card */
        .login-container {
            position: relative;
            z-index: 1;
            width: 100%;
            max-width: 440px;
            padding: 20px;
        }

        .login-card {
            background: rgba(255, 255, 255, 0.06);
            backdrop-filter: blur(24px);
            -webkit-backdrop-filter: blur(24px);
            border: 1px solid rgba(255, 255, 255, 0.12);
            border-radius: 24px;
            padding: 48px 40px;
            box-shadow: 0 25px 60px rgba(0,0,0,0.5), inset 0 1px 0 rgba(255,255,255,0.1);
            animation: slideUp 0.6s cubic-bezier(0.16, 1, 0.3, 1);
        }

        @keyframes slideUp {
            from { opacity: 0; transform: translateY(40px); }
            to   { opacity: 1; transform: translateY(0); }
        }

        /* Logo / Icon */
        .logo-wrap {
            display: flex;
            align-items: center;
            justify-content: center;
            margin-bottom: 28px;
        }
        .logo-icon {
            width: 56px;
            height: 56px;
            background: linear-gradient(135deg, #7c3aed, #2563eb);
            border-radius: 16px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 26px;
            box-shadow: 0 8px 24px rgba(124,58,237,0.45);
        }

        .login-title {
            text-align: center;
            margin-bottom: 8px;
        }
        .login-title h1 {
            font-size: 26px;
            font-weight: 700;
            color: #fff;
            letter-spacing: -0.5px;
        }
        .login-subtitle {
            text-align: center;
            color: rgba(255,255,255,0.45);
            font-size: 14px;
            margin-bottom: 36px;
        }

        /* Form */
        .form-group {
            margin-bottom: 20px;
        }
        .form-label {
            display: block;
            font-size: 13px;
            font-weight: 500;
            color: rgba(255,255,255,0.7);
            margin-bottom: 8px;
            letter-spacing: 0.3px;
        }
        .input-wrap {
            position: relative;
        }
        .input-icon {
            position: absolute;
            left: 14px;
            top: 50%;
            transform: translateY(-50%);
            color: rgba(255,255,255,0.35);
            font-size: 17px;
            pointer-events: none;
        }
        .form-input {
            width: 100%;
            padding: 13px 14px 13px 42px;
            background: rgba(255,255,255,0.07);
            border: 1px solid rgba(255,255,255,0.12);
            border-radius: 12px;
            color: #fff;
            font-size: 15px;
            font-family: 'Inter', sans-serif;
            outline: none;
            transition: border-color 0.25s, background 0.25s, box-shadow 0.25s;
        }
        .form-input::placeholder { color: rgba(255,255,255,0.28); }
        .form-input:focus {
            border-color: #7c3aed;
            background: rgba(124,58,237,0.12);
            box-shadow: 0 0 0 3px rgba(124,58,237,0.22);
        }

        /* Toggle password */
        .toggle-pw {
            position: absolute;
            right: 14px;
            top: 50%;
            transform: translateY(-50%);
            background: none;
            border: none;
            cursor: pointer;
            color: rgba(255,255,255,0.4);
            font-size: 17px;
            padding: 0;
            transition: color 0.2s;
        }
        .toggle-pw:hover { color: rgba(255,255,255,0.8); }

        /* Error message */
        .error-box {
            display: none;
            background: rgba(239,68,68,0.15);
            border: 1px solid rgba(239,68,68,0.35);
            border-radius: 10px;
            padding: 12px 16px;
            color: #fca5a5;
            font-size: 14px;
            margin-bottom: 20px;
            text-align: center;
            animation: shake 0.4s ease;
        }
        @keyframes shake {
            0%,100% { transform: translateX(0); }
            20%,60% { transform: translateX(-6px); }
            40%,80% { transform: translateX(6px); }
        }

        /* Submit button */
        .btn-login {
            width: 100%;
            padding: 14px;
            background: linear-gradient(135deg, #7c3aed, #2563eb);
            border: none;
            border-radius: 12px;
            color: #fff;
            font-size: 16px;
            font-weight: 600;
            font-family: 'Inter', sans-serif;
            cursor: pointer;
            letter-spacing: 0.3px;
            transition: opacity 0.2s, transform 0.15s, box-shadow 0.2s;
            box-shadow: 0 6px 20px rgba(124,58,237,0.4);
            margin-top: 8px;
            position: relative;
            overflow: hidden;
        }
        .btn-login:hover { opacity: 0.9; transform: translateY(-1px); box-shadow: 0 10px 28px rgba(124,58,237,0.5); }
        .btn-login:active { transform: translateY(0); }
        .btn-login:disabled { opacity: 0.6; cursor: not-allowed; transform: none !important; }

        /* Spinner inside button */
        .spinner {
            display: none;
            width: 18px; height: 18px;
            border: 2px solid rgba(255,255,255,0.4);
            border-top-color: #fff;
            border-radius: 50%;
            animation: spin 0.7s linear infinite;
            margin: 0 auto;
        }
        @keyframes spin { to { transform: rotate(360deg); } }

        /* JWT info badge */
        .jwt-badge {
            display: flex;
            align-items: center;
            gap: 6px;
            background: rgba(37,99,235,0.12);
            border: 1px solid rgba(37,99,235,0.25);
            border-radius: 8px;
            padding: 8px 12px;
            margin-top: 20px;
            color: #93c5fd;
            font-size: 12px;
        }
        .jwt-badge svg { flex-shrink: 0; }

        /* Links */
        .footer-links {
            text-align: center;
            margin-top: 24px;
            color: rgba(255,255,255,0.4);
            font-size: 14px;
        }
        .footer-links a {
            color: #a78bfa;
            text-decoration: none;
            font-weight: 500;
            transition: color 0.2s;
        }
        .footer-links a:hover { color: #c4b5fd; }

        /* Success flash */
        .success-box {
            display: none;
            background: rgba(16,185,129,0.15);
            border: 1px solid rgba(16,185,129,0.35);
            border-radius: 10px;
            padding: 12px 16px;
            color: #6ee7b7;
            font-size: 14px;
            margin-bottom: 20px;
            text-align: center;
        }
    </style>
</head>
<body>

<!-- Background blobs -->
<div class="bg-blob bg-blob-1"></div>
<div class="bg-blob bg-blob-2"></div>
<div class="bg-blob bg-blob-3"></div>

<div class="login-container">
    <div class="login-card">

        <div class="logo-wrap">
            <div class="logo-icon">🛒</div>
        </div>

        <div class="login-title">
            <h1>Đăng nhập</h1>
        </div>
        <p class="login-subtitle">Nhập thông tin tài khoản để tiếp tục</p>

        <!-- Messages -->
        <div class="error-box" id="error-msg"></div>
        <div class="success-box" id="success-msg">✅ Đăng nhập thành công! Đang chuyển hướng...</div>

        <form id="login-form" autocomplete="off" novalidate>

            <!-- Username -->
            <div class="form-group">
                <label class="form-label" for="username-input">Tên đăng nhập</label>
                <div class="input-wrap">
                    <span class="input-icon">👤</span>
                    <input
                        type="text"
                        id="username-input"
                        name="username"
                        class="form-input"
                        placeholder="Nhập tên đăng nhập..."
                        autocomplete="username"
                        required
                    >
                </div>
            </div>

            <!-- Password -->
            <div class="form-group">
                <label class="form-label" for="password-input">Mật khẩu</label>
                <div class="input-wrap">
                    <span class="input-icon">🔒</span>
                    <input
                        type="password"
                        id="password-input"
                        name="password"
                        class="form-input"
                        placeholder="Nhập mật khẩu..."
                        autocomplete="current-password"
                        required
                    >
                    <button type="button" class="toggle-pw" id="toggle-pw" title="Hiện/ẩn mật khẩu">👁</button>
                </div>
            </div>

            <button type="submit" class="btn-login" id="btn-submit">
                <span id="btn-text">Đăng nhập</span>
                <div class="spinner" id="btn-spinner"></div>
            </button>

        </form>

        <!-- JWT info -->
        <div class="jwt-badge">
            <svg width="14" height="14" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M12 11c0-1.657 1.343-3 3-3s3 1.343 3 3v2H9v-2c0-1.657 1.343-3 3-3z"/>
                <rect x="3" y="11" width="18" height="11" rx="2" stroke-width="2"/>
            </svg>
            Xác thực bảo mật bằng JWT Token (HS256)
        </div>

        <div class="footer-links">
            Chưa có tài khoản?
            <a href="/webbanhang/account/register">Đăng ký ngay</a>
        </div>

    </div>
</div>

<script>
    const form       = document.getElementById('login-form');
    const errorMsg   = document.getElementById('error-msg');
    const successMsg = document.getElementById('success-msg');
    const btnSubmit  = document.getElementById('btn-submit');
    const btnText    = document.getElementById('btn-text');
    const spinner    = document.getElementById('btn-spinner');
    const togglePw   = document.getElementById('toggle-pw');
    const pwInput    = document.getElementById('password-input');

    // Toggle password visibility
    togglePw.addEventListener('click', () => {
        if (pwInput.type === 'password') {
            pwInput.type = 'text';
            togglePw.textContent = '🙈';
        } else {
            pwInput.type = 'password';
            togglePw.textContent = '👁';
        }
    });

    function setLoading(state) {
        btnSubmit.disabled = state;
        btnText.style.display  = state ? 'none'  : 'inline';
        spinner.style.display  = state ? 'block' : 'none';
    }

    function showError(msg) {
        errorMsg.textContent = '❌ ' + msg;
        errorMsg.style.display = 'block';
        successMsg.style.display = 'none';
        // Re-trigger shake animation
        errorMsg.style.animation = 'none';
        errorMsg.offsetHeight; // reflow
        errorMsg.style.animation = '';
    }

    function showSuccess() {
        successMsg.style.display = 'block';
        errorMsg.style.display   = 'none';
    }

    form.addEventListener('submit', async function (e) {
        e.preventDefault();

        const username = document.getElementById('username-input').value.trim();
        const password = document.getElementById('password-input').value;

        errorMsg.style.display   = 'none';
        successMsg.style.display = 'none';

        if (!username || !password) {
            showError('Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!');
            return;
        }

        setLoading(true);

        try {
            const response = await fetch('/webbanhang/account/checkLogin', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username, password })
            });

            const data = await response.json();

            if (response.ok && data.token) {
                // Lưu JWT token vào localStorage
                localStorage.setItem('jwtToken', data.token);
                localStorage.setItem('username', data.username || username);
                localStorage.setItem('fullname', data.fullname || '');
                localStorage.setItem('role', data.role || 'user');

                showSuccess();

                // Chuyển hướng sau 800ms
                setTimeout(() => {
                    window.location.href = '/webbanhang/Product';
                }, 800);
            } else {
                showError(data.message || 'Sai tên đăng nhập hoặc mật khẩu!');
                setLoading(false);
            }
        } catch (err) {
            showError('Lỗi kết nối máy chủ. Vui lòng thử lại!');
            setLoading(false);
        }
    });

    // Enter key support
    document.getElementById('password-input').addEventListener('keydown', function (e) {
        if (e.key === 'Enter') form.dispatchEvent(new Event('submit'));
    });

    // Focus first input on load
    window.addEventListener('DOMContentLoaded', () => {
        setTimeout(() => document.getElementById('username-input').focus(), 300);
    });
</script>

</body>
</html>
