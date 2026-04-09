<?php include 'app/views/shares/header.php'; ?>

<div style="text-align:center; padding: 80px 20px; max-width: 500px; margin: 0 auto;">
    <div style="
        width: 90px; height: 90px; margin: 0 auto 24px;
        background: linear-gradient(135deg, rgba(16,185,129,0.2), rgba(16,185,129,0.05));
        border: 2px solid rgba(16,185,129,0.4);
        border-radius: 50%; display: flex; align-items: center; justify-content: center;
        font-size: 44px;
    ">✅</div>

    <h1 style="font-size: 28px; font-weight: 800; color: #fff; margin-bottom: 10px;">
        Đặt hàng thành công!
    </h1>
    <p style="color: #94a3b8; font-size: 15px; margin-bottom: 32px; line-height: 1.6;">
        Cảm ơn bạn đã đặt hàng. Đơn hàng của bạn đã được ghi nhận và đang được xử lý.<br>
        Chúng tôi sẽ liên hệ sớm nhất có thể!
    </p>

    <div style="
        background: rgba(30,41,59,0.85); border: 1px solid rgba(255,255,255,0.07);
        border-radius: 14px; padding: 20px; margin-bottom: 28px; text-align: left;
    ">
        <div style="font-size: 13px; color: #94a3b8; margin-bottom: 8px; font-weight: 600; text-transform: uppercase; letter-spacing: 0.5px;">
            Thông tin đơn hàng
        </div>
        <div style="font-size: 14px; color: #e2e8f0; display: flex; gap: 8px; align-items: center;">
            <i class="fas fa-truck" style="color:#6366f1"></i>
            Giao hàng trong 2–5 ngày làm việc
        </div>
        <div style="font-size: 14px; color: #e2e8f0; display: flex; gap: 8px; align-items: center; margin-top: 8px;">
            <i class="fas fa-shield-alt" style="color:#10b981"></i>
            Thanh toán khi nhận hàng (COD)
        </div>
    </div>

    <div style="display: flex; gap: 12px; justify-content: center; flex-wrap: wrap;">
        <a href="/webbanhang/Product" class="btn btn-primary">
            <i class="fas fa-shopping-bag"></i> Tiếp tục mua sắm
        </a>
    </div>
</div>

<?php include 'app/views/shares/footer.php'; ?>