<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng ký – ShopHub</title>
    <meta name="description" content="Tạo tài khoản ShopHub để mua sắm và quản lý sản phẩm.">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
    <style>
        *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }
        body {
            font-family: 'Inter', sans-serif;
            min-height: 100vh;
            display: flex; align-items: center; justify-content: center;
            background: linear-gradient(135deg, #0f0c29 0%, #302b63 50%, #24243e 100%);
            overflow: hidden; padding: 20px;
        }
        .bg-blob { position: fixed; border-radius: 50%; filter: blur(80px); opacity: 0.3;
            animation: float 8s ease-in-out infinite; pointer-events: none; z-index: 0; }
        .b1 { width:380px; height:380px; background:#7c3aed; top:-80px; left:-80px; animation-delay:0s; }
        .b2 { width:260px; height:260px; background:#2563eb; bottom:-60px; right:-60px; animation-delay:3s; }
        @keyframes float { 0%,100%{transform:translateY(0);} 50%{transform:translateY(-20px);} }

        .register-container { position:relative; z-index:1; width:100%; max-width:480px; }
        .register-card {
            background: rgba(255,255,255,0.06);
            backdrop-filter: blur(24px); -webkit-backdrop-filter: blur(24px);
            border: 1px solid rgba(255,255,255,0.12);
            border-radius: 24px; padding: 44px 40px;
            box-shadow: 0 25px 60px rgba(0,0,0,0.5);
            animation: slideUp 0.6s cubic-bezier(0.16,1,0.3,1);
        }
        @keyframes slideUp { from{opacity:0;transform:translateY(30px);} to{opacity:1;transform:translateY(0);} }

        .logo-wrap { display:flex; align-items:center; justify-content:center; margin-bottom:24px; }
        .logo-icon {
            width:52px; height:52px;
            background: linear-gradient(135deg, #7c3aed, #2563eb);
            border-radius: 14px; display:flex; align-items:center; justify-content:center;
            font-size:24px; box-shadow: 0 8px 24px rgba(124,58,237,0.45);
        }
        .reg-title { text-align:center; font-size:24px; font-weight:700; color:#fff; letter-spacing:-0.5px; margin-bottom:6px; }
        .reg-subtitle { text-align:center; color:rgba(255,255,255,0.45); font-size:13px; margin-bottom:32px; }

        .form-group { margin-bottom: 16px; }
        .form-label { display:block; font-size:12px; font-weight:600; color:rgba(255,255,255,0.6); margin-bottom:7px; letter-spacing:0.3px; text-transform:uppercase; }
        .input-wrap { position:relative; }
        .input-icon { position:absolute; left:13px; top:50%; transform:translateY(-50%); color:rgba(255,255,255,0.3); font-size:14px; pointer-events:none; }
        .form-input {
            width:100%; padding:12px 12px 12px 40px;
            background:rgba(255,255,255,0.07); border:1px solid rgba(255,255,255,0.12);
            border-radius:11px; color:#fff; font-size:14px; font-family:'Inter',sans-serif; outline:none;
            transition: all 0.25s;
        }
        .form-input::placeholder { color:rgba(255,255,255,0.25); }
        .form-input:focus { border-color:#7c3aed; background:rgba(124,58,237,0.12); box-shadow:0 0 0 3px rgba(124,58,237,0.2); }
        .form-input.error { border-color:#ef4444; }
        .field-error { font-size:12px; color:#fca5a5; margin-top:5px; display:none; }

        .error-box {
            display:none; background:rgba(239,68,68,0.12); border:1px solid rgba(239,68,68,0.3);
            border-radius:10px; padding:12px 14px; color:#fca5a5; font-size:13px; margin-bottom:16px; text-align:center;
        }
        .btn-register {
            width:100%; padding:13px; margin-top:8px;
            background:linear-gradient(135deg, #7c3aed, #2563eb);
            border:none; border-radius:11px;
            color:#fff; font-size:15px; font-weight:600; font-family:'Inter',sans-serif;
            cursor:pointer; transition: all 0.2s; box-shadow:0 6px 20px rgba(124,58,237,0.35);
        }
        .btn-register:hover { opacity:0.9; transform:translateY(-1px); }
        .btn-register:disabled { opacity:0.6; cursor:not-allowed; transform:none; }
        .spinner { display:inline-block; width:16px; height:16px; border:2px solid rgba(255,255,255,0.4); border-top-color:#fff; border-radius:50%; animation:spin 0.7s linear infinite; }
        @keyframes spin { to{transform:rotate(360deg);} }

        .two-col { display:grid; grid-template-columns:1fr 1fr; gap:12px; }
        @media(max-width:480px) { .two-col{grid-template-columns:1fr;} }
        .footer-links { text-align:center; margin-top:20px; color:rgba(255,255,255,0.4); font-size:13px; }
        .footer-links a { color:#a78bfa; text-decoration:none; font-weight:500; }
        .footer-links a:hover { color:#c4b5fd; }
    </style>
</head>
<body>
<div class="bg-blob b1"></div>
<div class="bg-blob b2"></div>

<div class="register-container">
    <div class="register-card">
        <div class="logo-wrap"><div class="logo-icon">🛒</div></div>
        <div class="reg-title">Tạo tài khoản</div>
        <p class="reg-subtitle">Đăng ký để bắt đầu mua sắm</p>

        <?php if (isset($errors) && count($errors) > 0): ?>
        <div class="error-box" style="display:block">
            <?php foreach ($errors as $err): ?><?= htmlspecialchars($err) ?><br><?php endforeach; ?>
        </div>
        <?php endif; ?>

        <form action="/webbanhang/account/save" method="post" id="reg-form">
            <div class="form-group">
                <label class="form-label">Tên đăng nhập *</label>
                <div class="input-wrap">
                    <i class="fas fa-user input-icon"></i>
                    <input type="text" name="username" class="form-input <?= isset($errors['username']) ? 'error' : '' ?>"
                        placeholder="Tên đăng nhập"
                        value="<?= htmlspecialchars($username ?? '') ?>" required>
                </div>
                <?php if (isset($errors['username'])): ?><div class="field-error" style="display:block"><?= $errors['username'] ?></div><?php endif; ?>
            </div>

            <div class="form-group">
                <label class="form-label">Họ và tên *</label>
                <div class="input-wrap">
                    <i class="fas fa-id-card input-icon"></i>
                    <input type="text" name="fullname" class="form-input <?= isset($errors['fullname']) ? 'error' : '' ?>"
                        placeholder="Nguyễn Văn A"
                        value="<?= htmlspecialchars($fullName ?? '') ?>" required>
                </div>
                <?php if (isset($errors['fullname'])): ?><div class="field-error" style="display:block"><?= $errors['fullname'] ?></div><?php endif; ?>
            </div>

            <div class="two-col">
                <div class="form-group">
                    <label class="form-label">Mật khẩu *</label>
                    <div class="input-wrap">
                        <i class="fas fa-lock input-icon"></i>
                        <input type="password" name="password" class="form-input <?= isset($errors['password']) ? 'error' : '' ?>"
                            placeholder="••••••••" required>
                    </div>
                    <?php if (isset($errors['password'])): ?><div class="field-error" style="display:block"><?= $errors['password'] ?></div><?php endif; ?>
                </div>
                <div class="form-group">
                    <label class="form-label">Xác nhận *</label>
                    <div class="input-wrap">
                        <i class="fas fa-lock input-icon"></i>
                        <input type="password" name="confirmpassword" class="form-input <?= isset($errors['confirmPass']) ? 'error' : '' ?>"
                            placeholder="••••••••" required>
                    </div>
                    <?php if (isset($errors['confirmPass'])): ?><div class="field-error" style="display:block"><?= $errors['confirmPass'] ?></div><?php endif; ?>
                </div>
            </div>

            <button type="submit" class="btn-register" id="reg-btn">
                <span id="reg-text">Tạo tài khoản</span>
            </button>
        </form>

        <div class="footer-links">
            Đã có tài khoản? <a href="/webbanhang/account/login">Đăng nhập</a>
        </div>
    </div>
</div>

<script>
document.getElementById('reg-form').addEventListener('submit', function() {
    const btn  = document.getElementById('reg-btn');
    const text = document.getElementById('reg-text');
    btn.disabled = true;
    text.innerHTML = '<span class="spinner"></span>';
});
</script>
</body>
</html>