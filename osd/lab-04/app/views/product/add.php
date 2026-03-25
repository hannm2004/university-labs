<?php include 'app/views/shares/header.php'; ?>

<h2 class="mb-4">➕ Thêm sản phẩm mới</h2>

<div class="card shadow-sm p-4" style="max-width:600px;">
    <form id="add-product-form">

        <div class="form-group">
            <label>Tên sản phẩm:</label>
            <input type="text" id="name" name="name" class="form-control" required>
        </div>

        <div class="form-group">
            <label>Mô tả:</label>
            <textarea id="description" name="description" class="form-control" required></textarea>
        </div>

        <div class="form-group">
            <label>Giá:</label>
            <input type="number" id="price" name="price" class="form-control" required>
        </div>

        <div class="form-group">
            <label>Danh mục:</label>
            <select id="category_id" name="category_id" class="form-control" required></select>
        </div>

        <button type="submit" class="btn btn-primary">💾 Thêm sản phẩm</button>
        <a href="/webbanhang/Product/list" class="btn btn-secondary">⬅ Quay lại</a>

    </form>
</div>

<?php include 'app/views/shares/footer.php'; ?>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<script>
    $(document).ready(function() {

        // LOAD CATEGORY
        $.get('/webbanhang/api/category', function(data) {
            let html = '';

            data.forEach(c => {
                html += `<option value="${c.id}">${c.name}</option>`;
            });

            $('#category_id').html(html);
        });

        // SUBMIT FORM
        $('#add-product-form').submit(function(e) {
            e.preventDefault();

            const product = {
                name: $('#name').val(),
                description: $('#description').val(),
                price: $('#price').val(),
                category_id: $('#category_id').val()
            };

            $.ajax({
                url: '/webbanhang/api/product',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(product),
                success: function(res) {
                    if (res.message === 'Product created successfully') {
                        alert('Thêm thành công');
                        window.location.href = '/webbanhang/Product';
                    } else {
                        alert('Thêm thất bại');
                    }
                },
                error: function() {
                    alert('Lỗi khi thêm sản phẩm');
                }
            });
        });

    });
</script>