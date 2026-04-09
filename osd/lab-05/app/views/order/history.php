<?php include 'app/views/shares/header.php'; ?>

<style>
.table-container {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px;
    padding: 24px;
    overflow-x: auto;
}
.order-table {
    width: 100%;
    border-collapse: collapse;
    color: #e2e8f0;
}
.order-table th {
    text-align: left;
    padding: 14px;
    font-size: 13px;
    font-weight: 700;
    color: #94a3b8;
    text-transform: uppercase;
    letter-spacing: 0.5px;
    border-bottom: 1px solid rgba(255,255,255,0.1);
}
.order-table td {
    padding: 16px 14px;
    font-size: 14px;
    border-bottom: 1px solid rgba(255,255,255,0.05);
    vertical-align: middle;
}
.order-table tbody tr:last-child td { border-bottom: none; }
.order-table tbody tr:hover { background: rgba(255,255,255,0.03); }

.badge-status {
    padding: 6px 12px;
    border-radius: 8px;
    font-size: 12px;
    font-weight: 700;
    text-transform: uppercase;
    display: inline-block;
}
.status-pending    { background: rgba(245,158,11,0.15); color: #fbbf24; border: 1px solid rgba(245,158,11,0.3); }
.status-processing { background: rgba(99,102,241,0.15); color: #818cf8; border: 1px solid rgba(99,102,241,0.3); }
.status-shipping   { background: rgba(14,165,233,0.15); color: #38bdf8; border: 1px solid rgba(14,165,233,0.3); }
.status-completed  { background: rgba(16,185,129,0.15); color: #34d399; border: 1px solid rgba(16,185,129,0.3); }
.status-cancelled  { background: rgba(239,68,68,0.15); color: #f87171; border: 1px solid rgba(239,68,68,0.3); }

.select-status {
    background: rgba(15,23,42,0.6);
    border: 1px solid rgba(255,255,255,0.1);
    color: #e2e8f0;
    padding: 6px 10px;
    border-radius: 8px;
    outline: none;
    font-size: 13px;
}
</style>

<div class="page-header">
    <div>
        <h1 class="page-title"><i class="fas fa-clipboard-list" style="color:#6366f1"></i> Lịch sử đơn hàng</h1>
        <p class="page-subtitle">Quản lý và theo dõi trạng thái đơn hàng của bạn</p>
    </div>
</div>

<div class="table-container">
    <?php if (empty($orders)): ?>
        <div class="empty-state">
            <i class="fas fa-box-open"></i>
            <h3>Chưa có đơn hàng nào</h3>
            <p>Bạn chưa thực hiện bất kỳ giao dịch nào.</p>
        </div>
    <?php else: ?>
        <table class="order-table">
            <thead>
                <tr>
                    <th>Mã ĐH</th>
                    <th>Khách hàng</th>
                    <th>Số điện thoại</th>
                    <th>Địa chỉ giao hàng</th>
                    <th>Ngày đặt</th>
                    <th>Trạng thái</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach ($orders as $order): ?>
                    <tr>
                        <td><strong>#<?= $order->id ?></strong></td>
                        <td><?= htmlspecialchars($order->name) ?></td>
                        <td><?= htmlspecialchars($order->phone) ?></td>
                        <td><?= htmlspecialchars($order->address) ?></td>
                        <td style="color:#94a3b8; font-size:13px;"><?= $order->created_at ?></td>
                        <td>
                            <?php if (SessionHelper::isAdmin()): ?>
                                <form method="POST" action="/webbanhang/Order/updateStatus" style="display:flex; gap:8px;">
                                    <input type="hidden" name="order_id" value="<?= $order->id ?>">
                                    <select name="status" class="select-status">
                                        <option value="pending" <?= $order->status == 'pending' ? 'selected' : '' ?>>Chờ xử lý</option>
                                        <option value="processing" <?= $order->status == 'processing' ? 'selected' : '' ?>>Đang xử lý</option>
                                        <option value="shipping" <?= $order->status == 'shipping' ? 'selected' : '' ?>>Đang vận chuyển</option>
                                        <option value="completed" <?= $order->status == 'completed' ? 'selected' : '' ?>>Hoàn thành</option>
                                        <option value="cancelled" <?= $order->status == 'cancelled' ? 'selected' : '' ?>>Đã hủy</option>
                                    </select>
                                    <button type="submit" class="btn btn-primary btn-sm"><i class="fas fa-save"></i> Cập nhật</button>
                                </form>
                            <?php else: ?>
                                <?php
                                    $statusClass = 'status-pending';
                                    $statusText  = 'Chờ xử lý';
                                    switch($order->status){
                                        case 'processing': $statusClass = 'status-processing'; $statusText = 'Đang xử lý'; break;
                                        case 'shipping':   $statusClass = 'status-shipping';   $statusText = 'Đang vận chuyển'; break;
                                        case 'completed':  $statusClass = 'status-completed';  $statusText = 'Hoàn thành'; break;
                                        case 'cancelled':  $statusClass = 'status-cancelled';  $statusText = 'Đã hủy'; break;
                                    }
                                ?>
                                <span class="badge-status <?= $statusClass ?>"><?= $statusText ?></span>
                            <?php endif; ?>
                        </td>
                    </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    <?php endif; ?>
</div>

<?php include 'app/views/shares/footer.php'; ?>