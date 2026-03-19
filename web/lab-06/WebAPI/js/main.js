const apiBaseUrl = 'http://localhost:5156/api/ProductApi';

const state = {
    editingId: null
};

document.addEventListener('DOMContentLoaded', function () {
    fetchProducts();

    const btnAdd = document.getElementById('btnAdd');
    const btnUpdate = document.getElementById('btnUpdate');
    const btnReset = document.getElementById('btnReset');

    if (btnUpdate) btnUpdate.style.display = 'none';

    btnAdd?.addEventListener('click', addProduct);
    btnUpdate?.addEventListener('click', updateProduct);
    btnReset?.addEventListener('click', resetForm);

    // Use event delegation because rows are rendered dynamically
    const tbl = document.getElementById('tblStudent');
    tbl?.addEventListener('click', async (e) => {
        const target = e.target;
        const idStr = target?.getAttribute?.('data-id');
        if (!idStr) return;

        const productId = parseInt(idStr, 10);
        if (Number.isNaN(productId)) return;

        if (target.classList.contains('delete-btn')) {
            await deleteProduct(productId);
        } else if (target.classList.contains('edit-btn')) {
            await startEdit(productId);
        } else if (target.classList.contains('view-btn')) {
            await viewProduct(productId);
        }
    });
});

function handleJsonResponse(response) {
    if (!response.ok) throw new Error('Request failed');
    return response.json();
}

function handleNoContentResponse(response) {
    if (response.status === 204) return;
    if (!response.ok) throw new Error('Request failed');
}

async function fetchProducts() {
    try {
        const res = await fetch(apiBaseUrl);
        const data = await handleJsonResponse(res);
        displayProducts(data);
    } catch (error) {
        console.error('Fetch error:', error.message);
    }
}

// SỬA HÀM NÀY
function displayProducts(products) {
    const bookList = document.getElementById('bookList');
    bookList.innerHTML = '';
    products.forEach((product, index) => {
        // Truyền index + 1 để làm STT (1, 2, 3...)
        bookList.innerHTML += createProductRow(product, index + 1);
    });
}

// SỬA HÀM NÀY
function createProductRow(product, stt) {
    return `
<tr>
  <td>${stt}</td> <td>${product.name}</td>
  <td>${product.price}</td>
  <td>${product.description}</td>
  <td>
    <button class="btn btn-danger delete-btn" data-id="${product.id}">Delete</button>
    <button class="btn btn-warning edit-btn" data-id="${product.id}">Edit</button>
    <button class="btn btn-primary view-btn" data-id="${product.id}">View</button>
  </td>
</tr>
`;
}

function getFormData() {
    const name = document.getElementById('bookName').value?.trim();
    const priceStr = document.getElementById('price').value?.trim();
    const description = document.getElementById('description').value?.trim();

    const price = parseFloat(priceStr);
    return { name, price, description };
}

async function addProduct() {
    const { name, price, description } = getFormData();
    if (!name || Number.isNaN(price) || !description) {
        console.error('Invalid form data');
        return;
    }

    const body = { name, price, description };

    try {
        const res = await fetch(apiBaseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body),
        });
        await handleJsonResponse(res); // CreatedAtAction trả về product
        await fetchProducts();
        resetForm();
    } catch (error) {
        console.error('Error:', error.message);
    }
}

async function startEdit(productId) {
    try {
        const res = await fetch(`${apiBaseUrl}/${productId}`);
        const product = await handleJsonResponse(res);

        state.editingId = productId;

        document.getElementById('bookName').value = product.name ?? '';
        document.getElementById('price').value = product.price ?? '';
        document.getElementById('description').value = product.description ?? '';

        const btnUpdate = document.getElementById('btnUpdate');
        if (btnUpdate) btnUpdate.style.display = 'inline-block';
    } catch (error) {
        console.error('Error:', error.message);
    }
}

async function updateProduct() {
    if (!state.editingId) return;

    const { name, price, description } = getFormData();
    if (!name || Number.isNaN(price) || !description) {
        console.error('Invalid form data');
        return;
    }

    const body = {
        id: state.editingId,
        name,
        price,
        description
    };

    try {
        const res = await fetch(`${apiBaseUrl}/${state.editingId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body),
        });
        handleNoContentResponse(res); // expected 204
        await fetchProducts();
        resetForm();
    } catch (error) {
        console.error('Error:', error.message);
    }
}

async function deleteProduct(productId) {
    try {
        const res = await fetch(`${apiBaseUrl}/${productId}`, {
            method: 'DELETE'
        });
        handleNoContentResponse(res); // expected 204
        await fetchProducts();
        if (state.editingId === productId) resetForm();
    } catch (error) {
        console.error('Error:', error.message);
    }
}

async function viewProduct(productId) {
    try {
        const res = await fetch(`${apiBaseUrl}/${productId}`);
        const product = await handleJsonResponse(res);

        const idEl = document.querySelector('.txt-title.code');
        const nameEl = document.querySelector('.txt-title.dateOfBirth');
        const descEl = document.querySelector('.txt-title.gender');

        if (idEl) idEl.textContent = product.id ?? '';
        if (nameEl) nameEl.textContent = product.name ?? '';
        if (descEl) descEl.textContent = product.description ?? '';

        const modalEl = document.getElementById('modalViewDetailInfo');
        if (modalEl && window.bootstrap?.Modal) {
            const modal = new window.bootstrap.Modal(modalEl);
            modal.show();
        }
    } catch (error) {
        console.error('Error:', error.message);
    }
}

function resetForm() {
    state.editingId = null;
    document.getElementById('bookName').value = '';
    document.getElementById('price').value = '';
    document.getElementById('description').value = '';

    const btnUpdate = document.getElementById('btnUpdate');
    if (btnUpdate) btnUpdate.style.display = 'none';
}
