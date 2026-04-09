<?php
if (!SessionHelper::isLoggedIn()) {
    header('Location: /webbanhang/account/login');
    exit;
}
include 'app/views/shares/header.php';
$cart  = isset($_SESSION['cart']) ? $_SESSION['cart'] : [];
$total = 0;
foreach ($cart as $item) $total += $item['price'] * $item['quantity'];
?>

<style>
.checkout-layout { display: grid; grid-template-columns: 1fr 360px; gap: 24px; align-items: start; }
.checkout-form-card {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px; padding: 32px;
}
.section-title { font-size: 16px; font-weight: 700; color: #fff; margin-bottom: 20px;
    display: flex; align-items: center; gap: 8px; }
.order-item-row { display: flex; gap: 12px; align-items: center; padding: 12px 0;
    border-bottom: 1px solid rgba(255,255,255,0.05); }
.order-item-row:last-child { border-bottom: none; }
.oitem-name { flex:1; font-size: 14px; color: #e2e8f0; }
.oitem-qty  { font-size: 13px; color: #94a3b8; }
.oitem-price { font-size: 14px; font-weight: 700; color: #818cf8; }
.order-summary-side {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px; padding: 24px; position: sticky; top: 84px;
}
.summary-row { display: flex; justify-content: space-between; margin-bottom: 12px; font-size: 14px; color: #94a3b8; }
.summary-total { border-top: 1px solid rgba(255,255,255,0.1); padding-top: 14px; margin-top: 14px; display: flex; justify-content: space-between; font-size: 18px; font-weight: 800; color: #fff; }
.grand { background: linear-gradient(135deg, #6366f1, #818cf8); -webkit-background-clip: text; -webkit-text-fill-color: transparent; }
@media(max-width:768px){ .checkout-layout { grid-template-columns: 1fr; } }
</style>

<div class="page-header">
    <div>
        <h1 class="page-title"><i class="fas fa-credit-card" style="color:#6366f1"></i> Thanh toán</h1>
        <p class="page-subtitle">Điền thông tin nhận hàng</p>
    </div>
    <a href="/webbanhang/Product/cart" class="btn btn-ghost">
        <i class="fas fa-arrow-left"></i> Quay lại giỏ hàng
    </a>
</div>

<?php if (empty($cart)): ?>
<div class="empty-state">
    <i class="fas fa-shopping-cart"></i>
    <h3>Giỏ hàng trống</h3>
    <a href="/webbanhang/Product" class="btn btn-primary" style="margin-top:20px;">Mua sắm ngay</a>
</div>
<?php else: ?>
<div class="checkout-layout">
    <div>
        <div class="checkout-form-card">
            <div class="section-title"><i class="fas fa-user" style="color:#6366f1"></i> Thông tin nhận hàng</div>
            <form method="POST" action="/webbanhang/Product/processCheckout" id="checkout-form">
                <div class="form-group">
                    <label class="form-label">Họ và tên *</label>
                    <input type="text" name="name" class="form-control"
                        placeholder="Nguyễn Văn A"
                        value="<?= htmlspecialchars(SessionHelper::getFullname()) ?>"
                        required>
                </div>
                <div class="form-group">
                    <label class="form-label">Số điện thoại *</label>
                    <input type="tel" name="phone" class="form-control" placeholder="0901234567" required>
                </div>
                <div class="form-group">
                    <label class="form-label">Địa chỉ giao hàng *</label>
                    <textarea name="address" class="form-control" style="min-height:90px;"
                        placeholder="Số nhà, đường, phường/xã, quận/huyện, tỉnh/thành phố" required></textarea>
                </div>
                <div class="form-group" style="margin-top:24px;">
                    <div style="background:rgba(16,185,129,0.08); border:1px solid rgba(16,185,129,0.2); border-radius:10px; padding:14px 16px; margin-bottom:20px;">
                        <div style="font-size:13px; color:#6ee7b7; font-weight:600; margin-bottom:4px;">
                            <i class="fas fa-shield-alt"></i> Thanh toán khi nhận hàng (COD)
                        </div>
                        <div style="font-size:12px; color:#94a3b8;">Miễn phí vận chuyển toàn quốc</div>
                    </div>
                    <button type="submit" class="btn btn-primary" style="width:100%; padding:14px; font-size:16px; justify-content:center;">
                        <i class="fas fa-check-circle"></i> Xác nhận đặt hàng
                    </button>
                </div>
            </form>
        </div>
    </div>

    <div class="order-summary-side">
        <div class="section-title"><i class="fas fa-receipt" style="color:#6366f1"></i> Đơn hàng</div>
        <?php foreach ($cart as $id => $item): ?>
        <div class="order-item-row">
            <div class="oitem-name"><?= htmlspecialchars($item['name']) ?></div>
            <div class="oitem-qty">x<?= $item['quantity'] ?></div>
            <div class="oitem-price"><?= number_format($item['price'] * $item['quantity'], 0, ',', '.') ?> ₫</div>
        </div>
        <?php endforeach; ?>
        <div class="summary-row" style="margin-top:14px;">
            <span>Tạm tính</span>
            <span><?= number_format($total, 0, ',', '.') ?> ₫</span>
        </div>
        <div class="summary-row">
            <span>Vận chuyển</span>
            <span style="color:#10b981;">Miễn phí</span>
        </div>
        <div class="summary-total">
            <span>Tổng cộng</span>
            <span class="grand"><?= number_format($total, 0, ',', '.') ?> ₫</span>
        </div>
    </div>
</div>
<?php endif; ?>

<?php include 'app/views/shares/footer.php'; ?>