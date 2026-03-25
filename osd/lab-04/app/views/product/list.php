<?php include 'app/views/shares/header.php'; ?>

<h2 class="mb-4">Danh sách sản phẩm</h2>

<a href="/webbanhang/Product/add" class="btn btn-success mb-3">
    ➕ Thêm sản phẩm mới
</a>

<div class="row">
    <?php foreach ($products as $product): ?>
        <div class="col-md-4 mb-4">
            <div class="card h-100 shadow-sm">
                <div class="card-body">

                    <h5 class="card-title">
                        <a href="/webbanhang/Product/show/<?php echo $product->id; ?>">
                            <?php echo htmlspecialchars($product->name); ?>
                        </a>
                    </h5>

                    <p class="card-text">
                        <?php echo htmlspecialchars($product->description); ?>
                    </p>

                    <p><b>Giá:</b> <?php echo $product->price; ?> VNĐ</p>
                    <p><b>Danh mục:</b> <?php echo $product->category_name; ?></p>

                </div>

                <div class="card-footer text-center">
                    <a href="/webbanhang/Product/edit/<?php echo $product->id; ?>"
                        class="btn btn-warning btn-sm">Sửa</a>

                    <a href="/webbanhang/Product/delete/<?php echo $product->id; ?>"
                        class="btn btn-danger btn-sm"
                        onclick="return confirm('Bạn có chắc muốn xóa?');">
                        Xóa
                    </a>
                </div>
            </div>
        </div>
    <?php endforeach; ?>
</div>

<?php include 'app/views/shares/footer.php'; ?>