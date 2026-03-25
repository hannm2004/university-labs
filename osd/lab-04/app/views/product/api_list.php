<?php include 'app/views/shares/header.php'; ?>

<h2 class="mb-4">Danh sách sản phẩm (API + jQuery)</h2>

<a href="/webbanhang/Product/add" class="btn btn-success mb-3">
    ➕ Thêm sản phẩm mới
</a>

<ul class="list-group" id="product-list"></ul>

<?php include 'app/views/shares/footer.php'; ?>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<script>
    $(document).ready(function() {
        loadProducts();
    });

    function loadProducts() {
        $.ajax({
            url: '/webbanhang/api/product',
            method: 'GET',
            success: function(data) {
                let html = '';

                data.forEach(product => {
                    html += `
                    <li class="list-group-item">
                        <h5>
                            <a href="/webbanhang/Product/show/${product.id}">
                                ${product.name}
                            </a>
                        </h5>

                        <p>${product.description ?? ''}</p>
                        <p><b>Giá:</b> ${product.price} VNĐ</p>
                        <p><b>Danh mục:</b> ${product.category_name ?? ''}</p>

                        <a href="/webbanhang/Product/edit/${product.id}" 
                           class="btn btn-warning btn-sm">Sửa</a>

                        <button class="btn btn-danger btn-sm" 
                                onclick="deleteProduct(${product.id})">
                                Xóa
                        </button>
                    </li>
                `;
                });

                $('#product-list').html(html);
            },
            error: function() {
                alert('Lỗi load dữ liệu');
            }
        });
    }

    function deleteProduct(id) {
        if (!confirm('Bạn chắc chắn muốn xóa?')) return;

        $.ajax({
            url: `/webbanhang/api/product/${id}`,
            method: 'DELETE',
            success: function(data) {
                if (data.message === 'Product deleted successfully') {
                    loadProducts();
                } else {
                    alert('Xóa thất bại');
                }
            },
            error: function() {
                alert('Lỗi khi xóa');
            }
        });
    }
</script>