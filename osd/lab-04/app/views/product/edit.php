<?php include 'app/views/shares/header.php'; ?>

<h2 class="mb-4">✏️ Sửa sản phẩm</h2>

<div class="card shadow-sm p-4" style="max-width:600px;">
    <form id="edit-product-form">

        <input type="hidden" id="id" name="id" value="<?= $product->id ?>">

        <div class="form-group">
            <label>Tên sản phẩm:</label>
            <input type="text" id="name" class="form-control" required>
        </div>

        <div class="form-group">
            <label>Mô tả:</label>
            <textarea id="description" class="form-control" required></textarea>
        </div>

        <div class="form-group">
            <label>Giá:</label>
            <input type="number" id="price" class="form-control" required>
        </div>

        <div class="form-group">
            <label>Danh mục:</label>
            <select id="category_id" class="form-control"></select>
        </div>

        <button type="submit" class="btn btn-primary">💾 Lưu</button>
        <a href="/webbanhang/Product" class="btn btn-secondary">⬅ Quay lại</a>

    </form>
</div>

<?php include 'app/views/shares/footer.php'; ?>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<script>
    $(document).ready(function() {

        const productId = <?= $product->id ?>;

        // LOAD CATEGORY trước
        $.get('/webbanhang/api/category', function(categories) {

            let html = '';
            categories.forEach(c => {
                html += `<option value="${c.id}">${c.name}</option>`;
            });

            $('#category_id').html(html);

            // Sau đó load product
            $.get(`/webbanhang/api/product/${productId}`, function(p) {
                $('#name').val(p.name);
                $('#description').val(p.description);
                $('#price').val(p.price);
                $('#category_id').val(p.category_id);
            });
        });

        // SUBMIT
        $('#edit-product-form').submit(function(e) {
            e.preventDefault();

            const product = {
                id: $('#id').val(),
                name: $('#name').val(),
                description: $('#description').val(),
                price: $('#price').val(),
                category_id: $('#category_id').val()
            };

            $.ajax({
                url: `/webbanhang/api/product/${product.id}`,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(product),
                success: function(res) {
                    if (res.message === 'Product updated successfully') {
                        alert('Cập nhật thành công');
                        window.location.href = '/webbanhang/Product';
                    } else {
                        alert('Cập nhật thất bại');
                    }
                },
                error: function() {
                    alert('Lỗi khi cập nhật');
                }
            });
        });

    });
</script>