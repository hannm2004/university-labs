<?php include 'app/views/shares/header.php'; ?>

<style>
.product-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
    gap: 20px;
}
.product-card {
    background: rgba(30,41,59,0.85);
    border: 1px solid rgba(255,255,255,0.07);
    border-radius: 16px;
    overflow: hidden;
    transition: all 0.25s cubic-bezier(0.4,0,0.2,1);
    display: flex; flex-direction: column;
}
.product-card:hover {
    border-color: rgba(99,102,241,0.4);
    transform: translateY(-4px);
    box-shadow: 0 12px 40px rgba(0,0,0,0.35);
}
.product-thumb {
    width: 100%; height: 200px;
    object-fit: cover;
    background: linear-gradient(135deg, #1e293b, #334155);
    display: flex; align-items: center; justify-content: center;
    color: #475569; font-size: 48px;
}
.product-thumb img {
    width: 100%; height: 100%; object-fit: cover;
}
.product-body { padding: 18px; flex: 1; display: flex; flex-direction: column; }
.product-cat {
    font-size: 11px; font-weight: 700; text-transform: uppercase;
    color: #818cf8; letter-spacing: 0.8px; margin-bottom: 6px;
}
.product-name {
    font-size: 16px; font-weight: 700; color: #fff; margin-bottom: 8px;
    line-height: 1.4;
    display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical; overflow: hidden;
}
.product-desc {
    font-size: 13px; color: #94a3b8; margin-bottom: 12px; flex: 1;
    display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical; overflow: hidden;
}
.product-price {
    font-size: 20px; font-weight: 800;
    background: linear-gradient(135deg, #6366f1, #818cf8);
    -webkit-background-clip: text; -webkit-text-fill-color: transparent;
    margin-bottom: 14px;
}
.product-actions { display: flex; gap: 8px; flex-wrap: wrap; }
.product-actions .btn { flex: 1; justify-content: center; }

/* Search / Filter bar */
.toolbar {
    display: flex; gap: 12px; margin-bottom: 24px; flex-wrap: wrap; align-items: center;
}
.search-input {
    flex: 1; min-width: 200px; padding: 10px 16px;
    background: rgba(255,255,255,0.05);
    border: 1px solid rgba(255,255,255,0.1);
    border-radius: 10px; color: #e2e8f0; font-size: 14px;
    font-family: 'Inter', sans-serif; outline: none;
    transition: all 0.25s;
}
.search-input:focus { border-color: #6366f1; background: rgba(99,102,241,0.08); }
.search-input::placeholder { color: #475569; }
.filter-select {
    padding: 10px 14px;
    background: rgba(255,255,255,0.05);
    border: 1px solid rgba(255,255,255,0.1);
    border-radius: 10px; color: #e2e8f0; font-size: 14px;
    font-family: 'Inter', sans-serif; cursor: pointer; outline: none;
}
.filter-select option { background: #1e293b; }

/* JWT Token Display */
.jwt-panel {
    background: rgba(99,102,241,0.08);
    border: 1px solid rgba(99,102,241,0.2);
    border-radius: 12px; padding: 14px 18px;
    margin-bottom: 24px; display: none;
}
.jwt-panel-title { font-size: 12px; font-weight: 700; color: #818cf8; text-transform: uppercase; letter-spacing: 0.5px; margin-bottom: 8px; }
.jwt-token-box {
    background: rgba(0,0,0,0.3); border-radius: 8px; padding: 10px 14px;
    font-size: 11px; color: #c7d2fe; word-break: break-all;
    font-family: 'Courier New', monospace;
}

/* Modal form */
#product-modal .modal { max-width: 560px; }
</style>

<!-- Page Header -->
<div class="page-header">
    <div>
        <h1 class="page-title">Sản phẩm</h1>
        <p class="page-subtitle" id="product-count-text">Đang tải...</p>
    </div>
    <div style="display:flex; gap:10px; align-items:center;">
        <button class="btn btn-ghost btn-sm" onclick="toggleJwtPanel()">
            <i class="fas fa-key"></i> Xem Token
        </button>
        <button class="btn btn-success" id="btn-add-product" style="display:none" onclick="openAddModal()">
            <i class="fas fa-plus"></i> Thêm sản phẩm
        </button>
    </div>
</div>

<!-- JWT Token Panel -->
<div class="jwt-panel" id="jwt-panel">
    <div class="jwt-panel-title"><i class="fas fa-shield-alt"></i> JWT Token (HS256) – Xác thực API</div>
    <div class="jwt-token-box" id="jwt-token-display">Chưa đăng nhập</div>
</div>

<!-- Toolbar -->
<div class="toolbar">
    <input type="text" class="search-input" id="search-input" placeholder="🔍  Tìm kiếm sản phẩm...">
    <select class="filter-select" id="cat-filter">
        <option value="">Tất cả danh mục</option>
    </select>
</div>

<!-- Product Grid -->
<div class="product-grid" id="product-grid"></div>

<!-- Loading / Empty State -->
<div class="spinner-wrap" id="loading-state">
    <div class="spinner"></div>
    <p style="margin-top:16px; color:#94a3b8;">Đang tải sản phẩm...</p>
</div>

<div class="empty-state" id="empty-state" style="display:none">
    <i class="fas fa-box-open"></i>
    <h3>Không tìm thấy sản phẩm</h3>
    <p>Thử thay đổi bộ lọc hoặc thêm sản phẩm mới</p>
</div>

<!-- ===== ADD PRODUCT MODAL ===== -->
<div class="modal-backdrop" id="add-modal">
    <div class="modal">
        <div class="modal-header">
            <h2 class="modal-title"><i class="fas fa-plus-circle" style="color:#6366f1"></i> Thêm sản phẩm</h2>
            <button class="modal-close" onclick="closeModal('add-modal')"><i class="fas fa-times"></i></button>
        </div>
        <div id="add-error" style="display:none; background:rgba(239,68,68,0.15); border:1px solid rgba(239,68,68,0.3); border-radius:8px; padding:10px 14px; margin-bottom:16px; color:#fca5a5; font-size:13px;"></div>
        <form id="add-form" onsubmit="submitAdd(event)">
            <div class="form-group">
                <label class="form-label">Tên sản phẩm *</label>
                <input type="text" class="form-control" name="name" placeholder="Nhập tên sản phẩm" required>
            </div>
            <div class="form-group">
                <label class="form-label">Mô tả *</label>
                <textarea class="form-control" name="description" placeholder="Mô tả sản phẩm" required></textarea>
            </div>
            <div style="display:grid; grid-template-columns:1fr 1fr; gap:14px;">
                <div class="form-group">
                    <label class="form-label">Giá (VND) *</label>
                    <input type="number" class="form-control" name="price" placeholder="0" min="0" step="0.01" required>
                </div>
                <div class="form-group">
                    <label class="form-label">Danh mục</label>
                    <select class="form-control" name="category_id" id="add-cat-select">
                        <option value="">-- Chọn danh mục --</option>
                    </select>
                </div>
            </div>
            <div style="display:flex; gap:10px; justify-content:flex-end; margin-top:8px;">
                <button type="button" class="btn btn-ghost" onclick="closeModal('add-modal')">Hủy</button>
                <button type="submit" class="btn btn-primary" id="add-submit-btn">
                    <i class="fas fa-save"></i> Lưu sản phẩm
                </button>
            </div>
        </form>
    </div>
</div>

<!-- ===== EDIT PRODUCT MODAL ===== -->
<div class="modal-backdrop" id="edit-modal">
    <div class="modal">
        <div class="modal-header">
            <h2 class="modal-title"><i class="fas fa-edit" style="color:#f59e0b"></i> Sửa sản phẩm</h2>
            <button class="modal-close" onclick="closeModal('edit-modal')"><i class="fas fa-times"></i></button>
        </div>
        <div id="edit-error" style="display:none; background:rgba(239,68,68,0.15); border:1px solid rgba(239,68,68,0.3); border-radius:8px; padding:10px 14px; margin-bottom:16px; color:#fca5a5; font-size:13px;"></div>
        <form id="edit-form" onsubmit="submitEdit(event)">
            <input type="hidden" name="id" id="edit-id">
            <div class="form-group">
                <label class="form-label">Tên sản phẩm *</label>
                <input type="text" class="form-control" name="name" id="edit-name" required>
            </div>
            <div class="form-group">
                <label class="form-label">Mô tả *</label>
                <textarea class="form-control" name="description" id="edit-description" required></textarea>
            </div>
            <div style="display:grid; grid-template-columns:1fr 1fr; gap:14px;">
                <div class="form-group">
                    <label class="form-label">Giá (VND) *</label>
                    <input type="number" class="form-control" name="price" id="edit-price" min="0" step="0.01" required>
                </div>
                <div class="form-group">
                    <label class="form-label">Danh mục</label>
                    <select class="form-control" name="category_id" id="edit-cat-select">
                        <option value="">-- Chọn danh mục --</option>
                    </select>
                </div>
            </div>
            <div style="display:flex; gap:10px; justify-content:flex-end; margin-top:8px;">
                <button type="button" class="btn btn-ghost" onclick="closeModal('edit-modal')">Hủy</button>
                <button type="submit" class="btn btn-warning" id="edit-submit-btn">
                    <i class="fas fa-save"></i> Cập nhật
                </button>
            </div>
        </form>
    </div>
</div>

<!-- DELETE CONFIRM MODAL -->
<div class="modal-backdrop" id="delete-modal">
    <div class="modal" style="max-width:420px; text-align:center;">
        <div style="font-size:52px; margin-bottom:12px;">🗑️</div>
        <h2 class="modal-title" style="margin-bottom:8px;">Xác nhận xóa</h2>
        <p style="color:#94a3b8; font-size:14px; margin-bottom:24px;">Bạn có chắc muốn xóa sản phẩm <strong id="delete-name" style="color:#fff"></strong>? Hành động này không thể hoàn tác.</p>
        <div style="display:flex; gap:10px; justify-content:center;">
            <button class="btn btn-ghost" onclick="closeModal('delete-modal')">Hủy</button>
            <button class="btn btn-danger" id="confirm-delete-btn" onclick="confirmDelete()">
                <i class="fas fa-trash"></i> Xóa
            </button>
        </div>
    </div>
</div>

<script>
let allProducts  = [];
let categories   = [];
let deleteTarget = null;

// ===== INIT =====
document.addEventListener('DOMContentLoaded', async function () {
    // Show JWT token panel value
    const token = getToken();
    document.getElementById('jwt-token-display').textContent = token || 'Chưa đăng nhập';

    if (!isLoggedIn()) {
        showToast('Vui lòng đăng nhập để xem sản phẩm', 'error');
        setTimeout(() => { window.location.href = '/webbanhang/account/login'; }, 1500);
        return;
    }

    if (isAdmin()) {
        document.getElementById('btn-add-product').style.display = 'flex';
    }

    await loadCategories();
    await loadProducts();

    // Search
    document.getElementById('search-input').addEventListener('input', filterProducts);
    document.getElementById('cat-filter').addEventListener('change', filterProducts);
});

// ===== LOAD PRODUCTS =====
async function loadProducts() {
    document.getElementById('loading-state').style.display = 'block';
    document.getElementById('product-grid').style.display  = 'none';
    document.getElementById('empty-state').style.display   = 'none';

    try {
        const res  = await fetch('/webbanhang/api/product', { headers: authHeaders() });
        const data = await res.json();

        if (!res.ok) {
            if (res.status === 401) {
                showToast('Phiên đăng nhập hết hạn, vui lòng đăng nhập lại', 'error');
                setTimeout(() => { doLogout(); }, 2000);
                return;
            }
            throw new Error(data.message || 'Lỗi tải dữ liệu');
        }

        allProducts = data;
        filterProducts();
    } catch (e) {
        showToast('Lỗi: ' + e.message, 'error');
    } finally {
        document.getElementById('loading-state').style.display = 'none';
    }
}

// ===== LOAD CATEGORIES =====
async function loadCategories() {
    try {
        const res  = await fetch('/webbanhang/api/category');
        categories = await res.json();
        const catFilter   = document.getElementById('cat-filter');
        const addCatSel   = document.getElementById('add-cat-select');
        const editCatSel  = document.getElementById('edit-cat-select');
        categories.forEach(c => {
            [catFilter, addCatSel, editCatSel].forEach(sel => {
                const opt = document.createElement('option');
                opt.value = c.id; opt.textContent = c.name;
                sel.appendChild(opt);
            });
        });
    } catch(e) {}
}

// ===== RENDER / FILTER =====
function filterProducts() {
    const q   = document.getElementById('search-input').value.toLowerCase();
    const cat = document.getElementById('cat-filter').value;
    const filtered = allProducts.filter(p =>
        (p.name.toLowerCase().includes(q) || (p.description||'').toLowerCase().includes(q)) &&
        (!cat || String(p.category_id) === String(cat))
    );
    renderProducts(filtered);
}

function renderProducts(list) {
    const grid  = document.getElementById('product-grid');
    const empty = document.getElementById('empty-state');
    document.getElementById('product-count-text').textContent =
        `${list.length} sản phẩm`;

    if (list.length === 0) {
        grid.style.display  = 'none';
        empty.style.display = 'block';
        return;
    }
    empty.style.display  = 'none';
    grid.style.display   = 'grid';
    grid.innerHTML = list.map(p => productCard(p)).join('');
}

function fmt(price) {
    return Number(price).toLocaleString('vi-VN') + ' ₫';
}

function productCard(p) {
    const thumb = p.image
        ? `<div class="product-thumb"><img src="/webbanhang/${p.image}" alt="${p.name}" onerror="this.parentElement.innerHTML='<i class=\\'fas fa-image\\'></i>'"></div>`
        : `<div class="product-thumb"><i class="fas fa-image"></i></div>`;

    const adminBtns = isAdmin() ? `
        <button class="btn btn-warning btn-sm" onclick="openEditModal(${p.id})">
            <i class="fas fa-edit"></i> Sửa
        </button>
        <button class="btn btn-danger btn-sm" onclick="openDeleteModal(${p.id}, '${(p.name||'').replace(/'/g,"\\'")}')">
            <i class="fas fa-trash"></i> Xóa
        </button>
    ` : '';

    const cartBtn = isLoggedIn() ? `
        <a href="/webbanhang/Product/addToCart/${p.id}" class="btn btn-primary btn-sm" style="flex:1; justify-content:center;">
            <i class="fas fa-cart-plus"></i> Thêm vào giỏ
        </a>
    ` : '';

    return `
        <div class="product-card">
            ${thumb}
            <div class="product-body">
                <div class="product-cat">${p.category_name || 'Chưa phân loại'}</div>
                <div class="product-name">${p.name}</div>
                <div class="product-desc">${p.description || ''}</div>
                <div class="product-price">${fmt(p.price)}</div>
                <div class="product-actions">
                    ${cartBtn}
                    ${adminBtns}
                </div>
            </div>
        </div>`;
}

// ===== ADD PRODUCT =====
function openAddModal() {
    document.getElementById('add-form').reset();
    document.getElementById('add-error').style.display = 'none';
    document.getElementById('add-modal').classList.add('open');
}

async function submitAdd(e) {
    e.preventDefault();
    const btn  = document.getElementById('add-submit-btn');
    const err  = document.getElementById('add-error');
    const fd   = new FormData(document.getElementById('add-form'));
    const body = Object.fromEntries(fd.entries());
    btn.disabled = true; btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang lưu...';
    err.style.display = 'none';

    try {
        const res  = await fetch('/webbanhang/api/product', { method: 'POST', headers: authHeaders(), body: JSON.stringify(body) });
        const data = await res.json();
        if (res.ok) {
            closeModal('add-modal');
            showToast('Thêm sản phẩm thành công!', 'success');
            await loadProducts();
        } else {
            err.textContent = data.message || 'Thêm thất bại';
            err.style.display = 'block';
        }
    } catch(e) { err.textContent = 'Lỗi kết nối!'; err.style.display = 'block'; }
    finally { btn.disabled = false; btn.innerHTML = '<i class="fas fa-save"></i> Lưu sản phẩm'; }
}

// ===== EDIT PRODUCT =====
async function openEditModal(id) {
    document.getElementById('edit-error').style.display = 'none';
    try {
        const res  = await fetch(`/webbanhang/api/product/${id}`);
        const p    = await res.json();
        document.getElementById('edit-id').value          = p.id;
        document.getElementById('edit-name').value        = p.name;
        document.getElementById('edit-description').value = p.description;
        document.getElementById('edit-price').value       = p.price;
        document.getElementById('edit-cat-select').value  = p.category_id;
    } catch(e) { showToast('Không tải được thông tin sản phẩm', 'error'); return; }
    document.getElementById('edit-modal').classList.add('open');
}

async function submitEdit(e) {
    e.preventDefault();
    const btn  = document.getElementById('edit-submit-btn');
    const err  = document.getElementById('edit-error');
    const fd   = new FormData(document.getElementById('edit-form'));
    const body = Object.fromEntries(fd.entries());
    const id   = body.id;
    btn.disabled = true; btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang lưu...';
    err.style.display = 'none';

    try {
        const res  = await fetch(`/webbanhang/api/product/${id}`, { method: 'PUT', headers: authHeaders(), body: JSON.stringify(body) });
        const data = await res.json();
        if (res.ok) {
            closeModal('edit-modal');
            showToast('Cập nhật sản phẩm thành công!', 'success');
            await loadProducts();
        } else {
            err.textContent = data.message || 'Cập nhật thất bại';
            err.style.display = 'block';
        }
    } catch(e) { err.textContent = 'Lỗi kết nối!'; err.style.display = 'block'; }
    finally { btn.disabled = false; btn.innerHTML = '<i class="fas fa-save"></i> Cập nhật'; }
}

// ===== DELETE =====
function openDeleteModal(id, name) {
    deleteTarget = id;
    document.getElementById('delete-name').textContent = name;
    document.getElementById('delete-modal').classList.add('open');
}

async function confirmDelete() {
    if (!deleteTarget) return;
    const btn = document.getElementById('confirm-delete-btn');
    btn.disabled = true; btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang xóa...';

    try {
        const res  = await fetch(`/webbanhang/api/product/${deleteTarget}`, { method: 'DELETE', headers: authHeaders() });
        const data = await res.json();
        closeModal('delete-modal');
        if (res.ok) {
            showToast('Đã xóa sản phẩm thành công!', 'success');
            await loadProducts();
        } else {
            showToast(data.message || 'Xóa thất bại', 'error');
        }
    } catch(e) { showToast('Lỗi kết nối!', 'error'); }
    finally { deleteTarget = null; btn.disabled = false; btn.innerHTML = '<i class="fas fa-trash"></i> Xóa'; }
}

// ===== UTILS =====
function openAddModal() {
    document.getElementById('add-form').reset();
    document.getElementById('add-error').style.display = 'none';
    document.getElementById('add-modal').classList.add('open');
}
function closeModal(id) { document.getElementById(id).classList.remove('open'); }
function toggleJwtPanel() {
    const p = document.getElementById('jwt-panel');
    p.style.display = p.style.display === 'none' || !p.style.display ? 'block' : 'none';
}

// Close modal on backdrop click
document.querySelectorAll('.modal-backdrop').forEach(bd => {
    bd.addEventListener('click', function(e) {
        if (e.target === this) this.classList.remove('open');
    });
});
</script>

<?php include 'app/views/shares/footer.php'; ?>