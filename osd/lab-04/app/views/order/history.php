<?php require_once('app/helpers/SessionHelper.php'); ?>
<h2>Lịch sử đơn hàng</h2>

<table border="1">
    <tr>
        <th>ID</th>
        <th>Tên</th>
        <th>SĐT</th>
        <th>Địa chỉ</th>
        <th>Trạng thái</th>
        <th>Ngày</th>
    </tr>

    <?php foreach ($orders as $order): ?>
        <tr>
            <td><?= $order->id ?></td>
            <td><?= $order->name ?></td>
            <td><?= $order->phone ?></td>
            <td><?= $order->address ?></td>

            <td>
                <?php if (SessionHelper::isAdmin()): ?>
                    <form method="POST" action="/webbanhang/Order/updateStatus">
                        <input type="hidden" name="order_id" value="<?= $order->id ?>">

                        <select name="status">
                            <option value="pending" <?= $order->status == 'pending' ? 'selected' : '' ?>>Pending</option>
                            <option value="processing" <?= $order->status == 'processing' ? 'selected' : '' ?>>Processing</option>
                            <option value="shipping" <?= $order->status == 'shipping' ? 'selected' : '' ?>>Shipping</option>
                            <option value="completed" <?= $order->status == 'completed' ? 'selected' : '' ?>>Completed</option>
                            <option value="cancelled" <?= $order->status == 'cancelled' ? 'selected' : '' ?>>Cancelled</option>
                        </select>

                        <button type="submit">Cập nhật</button>
                    </form>
                <?php else: ?>
                    <?= $order->status ?? 'pending' ?>
                <?php endif; ?>
            </td>

            <td><?= $order->created_at ?? '' ?></td>
        </tr>
    <?php endforeach; ?>
</table>