<?php include 'app/views/shares/header.php'; ?>

<style>
.cart-layout { display: grid; grid-template-columns: 1fr 340px; gap: 24px; align-items: start; }
.cart-item {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px; padding: 20px;
    display: flex; gap: 16px; align-items: center;
    transition: all 0.25s; margin-bottom: 12px;
}
.cart-item:hover { border-color: rgba(99,102,241,0.3); }
.cart-item-img {
    width: 80px; height: 80px; border-radius: 12px;
    object-fit: cover;
    background: #334155; flex-shrink: 0;
    display: flex; align-items: center; justify-content: center;
    color: #475569; font-size: 28px; overflow: hidden;
}
.cart-item-img img { width:100%; height:100%; object-fit:cover; }
.cart-item-info { flex: 1; }
.cart-item-name { font-size: 15px; font-weight: 700; color: #fff; margin-bottom: 4px; }
.cart-item-price { font-size: 14px; color: #818cf8; font-weight: 600; }
.cart-item-qty {
    display: flex; align-items: center; gap: 10px;
    background: rgba(255,255,255,0.05); border-radius: 8px; padding: 6px 12px;
}
.qty-btn {
    background: none; border: none; color: #94a3b8; cursor: pointer;
    font-size: 16px; width: 24px; height: 24px; display: flex; align-items:center; justify-content:center;
    border-radius: 6px; transition: all 0.2s;
}
.qty-btn:hover { background: rgba(255,255,255,0.1); color: #fff; }
.qty-num { font-size: 15px; font-weight: 700; color: #fff; min-width: 24px; text-align: center; }
.cart-item-total { font-size: 16px; font-weight: 800; color: #fff; min-width: 110px; text-align: right; }

.order-summary {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px; padding: 24px; position: sticky; top: 84px;
}
.summary-title { font-size: 16px; font-weight: 700; color: #fff; margin-bottom: 20px; }
.summary-row { display: flex; justify-content: space-between; margin-bottom: 12px; font-size: 14px; color: #94a3b8; }
.summary-total { border-top: 1px solid rgba(255,255,255,0.1); padding-top: 14px; margin-top: 14px; display: flex; justify-content: space-between; font-size: 18px; font-weight: 800; color: #fff; }
.summary-grand { background: linear-gradient(135deg, #6366f1, #818cf8); -webkit-background-clip: text; -webkit-text-fill-color: transparent; }

@media (max-width: 768px) { .cart-layout { grid-template-columns: 1fr; } }
</style>

<div class="page-header">
    <div>
        <h1 class="page-title"><i class="fas fa-shopping-cart" style="color:#6366f1"></i> Giỏ hàng</h1>
        <p class="page-subtitle" id="cart-subtitle">Đang tải...</p>
    </div>
    <a href="/webbanhang/Product" class="btn btn-ghost">
        <i class="fas fa-arrow-left"></i> Tiếp tục mua sắm
    </a>
</div>

<?php
$cart  = isset($_SESSION['cart']) ? $_SESSION['cart'] : [];
$total = 0;
foreach ($cart as $item) $total += $item['price'] * $item['quantity'];
$count = count($cart);
?>

<?php if ($count > 0): ?>
<div class="cart-layout">
    <div>
        <?php foreach ($cart as $id => $item): ?>
        <div class="cart-item">
            <div class="cart-item-img">
                <?php if (!empty($item['image'])): ?>
                    <img src="/webbanhang/<?= htmlspecialchars($item['image']) ?>" alt="<?= htmlspecialchars($item['name']) ?>" onerror="this.parentElement.innerHTML='<i class=\'fas fa-image\'></i>'">
                <?php else: ?>
                    <i class="fas fa-image"></i>
                <?php endif; ?>
            </div>
            <div class="cart-item-info">
                <div class="cart-item-name"><?= htmlspecialchars($item['name']) ?></div>
                <div class="cart-item-price"><?= number_format($item['price'], 0, ',', '.') ?> ₫ / cái</div>
            </div>
            <div class="cart-item-qty">
                <button class="qty-btn"><i class="fas fa-minus"></i></button>
                <span class="qty-num"><?= $item['quantity'] ?></span>
                <button class="qty-btn"><i class="fas fa-plus"></i></button>
            </div>
            <div class="cart-item-total"><?= number_format($item['price'] * $item['quantity'], 0, ',', '.') ?> ₫</div>
        </div>
        <?php endforeach; ?>
    </div>

    <div class="order-summary">
        <div class="summary-title">📋 Tóm tắt đơn hàng</div>
        <div class="summary-row">
            <span>Số sản phẩm</span>
            <span><?= $count ?> loại</span>
        </div>
        <div class="summary-row">
            <span>Tạm tính</span>
            <span><?= number_format($total, 0, ',', '.') ?> ₫</span>
        </div>
        <div class="summary-row">
            <span>Phí vận chuyển</span>
            <span style="color:#10b981;">Miễn phí</span>
        </div>
        <div class="summary-total">
            <span>Tổng cộng</span>
            <span class="summary-grand"><?= number_format($total, 0, ',', '.') ?> ₫</span>
        </div>
        <a href="/webbanhang/Product/checkout" class="btn btn-primary" style="width:100%; justify-content:center; margin-top:20px; padding:14px;">
            <i class="fas fa-credit-card"></i> Thanh toán ngay
        </a>
        <div style="text-align:center; margin-top:12px; font-size:12px; color:#475569;">
            <i class="fas fa-shield-alt" style="color:#6366f1"></i>
            Thanh toán bảo mật – Xác thực JWT
        </div>
    </div>
</div>
<?php else: ?>
<div class="empty-state">
    <i class="fas fa-shopping-cart"></i>
    <h3>Giỏ hàng trống</h3>
    <p>Bạn chưa thêm sản phẩm nào vào giỏ hàng</p>
    <a href="/webbanhang/Product" class="btn btn-primary" style="margin-top:20px;">
        <i class="fas fa-shopping-bag"></i> Mua sắm ngay
    </a>
</div>
<?php endif; ?>

<script>
document.querySelector('.page-subtitle').textContent =
    '<?= $count ?> loại sản phẩm trong giỏ';
</script>

<?php include 'app/views/shares/footer.php'; ?>