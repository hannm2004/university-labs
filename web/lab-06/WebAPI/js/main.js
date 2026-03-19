document.addEventListener('DOMContentLoaded', function () {
    fetchProducts();
    document.getElementById('btnAdd').addEventListener('click',
        addProduct);
});
function fetchProducts() {
    const apiUrl = 'https://localhost:7112/api/ProductApi';
    fetch(apiUrl)
        .then(handleResponse)
        .then(data => displayProducts(data))
        .catch(error => console.error('Fetch error:',
            error.message));
}
// Handle fetch response, check for error, and parse JSON
function handleResponse(response) {
    if (!response.ok) throw new Error('Network response was not ok');
    return response.json();
}
// Display products in the HTML table
function displayProducts(products) {
    const bookList = document.getElementById('bookList');
    bookList.innerHTML = ''; // Clear existing products
    products.forEach(product => {
        bookList.innerHTML += createProductRow(product);
    });
}
// Create HTML table row for a product
function createProductRow(product) {
    return `
 <tr>
 <td>${product.id}</td>
 <td>${product.name}</td>
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
// Add a new product
function addProduct() {
    const productData = {
        name: document.getElementById('bookName').value,
        price: document.getElementById('price').value,
        description: document.getElementById('description').value,
    };
    fetch('https://localhost:7112/api/ProductApi', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(productData),
    }).then(handleResponse)
        .then(data => {
            console.log('Product added:', data);
            fetchProducts(); // Refresh the product list
        })
        .catch(error => console.error('Error:', error));
}
// Thay {id} bằng ID cụ thể của sản phẩm
const productId = 1;
fetch(`https://localhost:7112/api/ProductApi/${productId}`)
    .then(response => response.json())
    .then(product => {
        // Xử lý thông tin chi tiết sản phẩm
        console.log(product);
    })
    .catch(error => console.error('Error:', error));
// Thay {id} và cập nhật thông tin sản phẩm
const productIdToUpdate = 1;
const updatedProduct = {
    id: productIdToUpdate,
    name: 'Updated Product',
    price: 150,
    description: 'An updated product',
    // Thêm các thông tin khác
};
fetch(`https://localhost:7112/api/ProductApi/${productIdToUpdate}`, {
    method: 'PUT',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(updatedProduct),
})
    .then(response => {
        if (response.status === 204) {
            console.log('Product updated successfully.');
        } else {
            console.error('Failed to update product.');
        }
    })
    .catch(error => console.error('Error:', error));
// Thay {id} bằng ID cụ thể của sản phẩm cần xóa
const productIdToDelete = 1;
fetch(`https://localhost:7112/api/ProductApi/${productIdToDelete}`, {
    method: 'DELETE',
})
    .then(response => {
        if (response.status === 204) {
            console.log('Product deleted successfully.');
        } else {
            console.error('Failed to delete product.');
        }
    })
    .catch(error => console.error('Error:', error));
