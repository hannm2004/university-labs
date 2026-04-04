<style>
/* Homepage specific styles */
.hero-section {
    position: relative;
    padding: 100px 0;
    overflow: hidden;
    background: linear-gradient(135deg, rgba(99, 102, 241, 0.1) 0%, rgba(236, 72, 153, 0.1) 100%);
    border-radius: 20px;
    margin-top: 2rem;
    margin-bottom: 4rem;
}

.hero-bg-shapes {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: -1;
    overflow: hidden;
}

.shape-1 {
    position: absolute;
    top: -10%;
    right: -5%;
    width: 300px;
    height: 300px;
    background: radial-gradient(circle, var(--primary-color) 0%, rgba(99, 102, 241, 0) 70%);
    opacity: 0.2;
    border-radius: 50%;
    filter: blur(40px);
}

.shape-2 {
    position: absolute;
    bottom: -10%;
    left: 5%;
    width: 250px;
    height: 250px;
    background: radial-gradient(circle, var(--secondary-color) 0%, rgba(236, 72, 153, 0) 70%);
    opacity: 0.2;
    border-radius: 50%;
    filter: blur(40px);
}

.hero-text {
    z-index: 10;
    position: relative;
}

.hero-title {
    font-size: 3.5rem;
    font-weight: 800;
    line-height: 1.2;
    color: var(--text-main);
    margin-bottom: 1.5rem;
}

.hero-title span {
    background: linear-gradient(135deg, var(--primary-color), var(--secondary-color));
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
}

.hero-subtitle {
    font-size: 1.25rem;
    color: var(--text-muted);
    margin-bottom: 2rem;
    font-weight: 400;
}

/* Product Cards */
.section-title {
    font-size: 2rem;
    font-weight: 700;
    margin-bottom: 2rem;
    text-align: center;
    position: relative;
}

.section-title::after {
    content: '';
    display: block;
    width: 60px;
    height: 4px;
    background: var(--primary-color);
    margin: 10px auto 0;
    border-radius: 2px;
}

.product-card {
    background: rgba(255, 255, 255, 0.9);
    border: 1px solid rgba(255, 255, 255, 0.5);
    border-radius: 16px;
    padding: 20px;
    box-shadow: 0 10px 30px -10px rgba(0, 0, 0, 0.05);
    transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275);
    height: 100%;
    display: flex;
    flex-direction: column;
    position: relative;
    overflow: hidden;
    backdrop-filter: blur(10px);
}

.product-card:hover {
    transform: translateY(-10px);
    box-shadow: 0 20px 40px -10px rgba(99, 102, 241, 0.2);
}

.product-img-wrapper {
    width: 100%;
    padding-top: 100%; /* 1:1 Aspect Ratio */
    position: relative;
    margin-bottom: 1rem;
    border-radius: 12px;
    overflow: hidden;
    background: #fff;
    box-shadow: inset 0 0 10px rgba(0,0,0,0.02);
}

.product-img-wrapper img {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    object-fit: contain;
    padding: 10px;
    transition: transform 0.5s ease;
}

.product-card:hover .product-img-wrapper img {
    transform: scale(1.1);
}

.product-category {
    font-size: 0.8rem;
    text-transform: uppercase;
    letter-spacing: 1px;
    color: var(--secondary-color);
    font-weight: 600;
    margin-bottom: 0.5rem;
}

.product-name {
    font-size: 1.2rem;
    font-weight: 700;
    color: var(--text-main);
    margin-bottom: 0.5rem;
    display: -webkit-box;
    -webkit-line-clamp: 2;
    -webkit-box-orient: vertical;
    overflow: hidden;
}

.product-price {
    font-size: 1.4rem;
    font-weight: 800;
    color: var(--primary-color);
    margin-top: auto;
    margin-bottom: 1rem;
}

.btn-card-action {
    width: 100%;
    border-radius: 8px;
    font-weight: 600;
    padding: 10px;
    text-transform: uppercase;
    font-size: 0.9rem;
    letter-spacing: 0.5px;
}

/* Feature tags */
.feature-badge {
    position: absolute;
    top: 10px;
    right: 10px;
    background: linear-gradient(135deg, #f59e0b, #ea580c);
    color: white;
    padding: 4px 10px;
    border-radius: 20px;
    font-size: 0.75rem;
    font-weight: 700;
    z-index: 2;
    box-shadow: 0 4px 10px rgba(234, 88, 12, 0.3);
}
</style>

<div class="container">
    <!-- Hero Section -->
    <div class="hero-section text-center">
        <div class="hero-bg-shapes">
            <div class="shape-1"></div>
            <div class="shape-2"></div>
        </div>
        <div class="hero-text mx-auto" style="max-width: 800px;">
            <h1 class="hero-title">Khám phá thế giới <span>Công Nghệ</span> đỉnh cao</h1>
            <p class="hero-subtitle">Mua sắm các thiết bị điện tử chính hãng với giá tốt nhất thị trường. Laptop, điện thoại và phụ kiện thời thượng đang chờ bạn khám phá.</p>
            <div>
                <a href="/webbanhang/Product/" class="btn btn-custom btn-lg mr-3 px-5 py-3 rounded-pill">Mua sắm ngay</a>
            </div>
        </div>
    </div>

    <!-- Featured Products -->
    <div class="mb-5">
        <h2 class="section-title">Sản Phẩm Nổi Bật</h2>
        
        <?php if (!empty($products)): ?>
            <div class="row">
                <?php 
                // Display up to 8 products on homepage
                $count = 0;
                foreach ($products as $product): 
                    if($count >= 8) break;
                ?>
                    <div class="col-12 col-sm-6 col-md-4 col-lg-3 mb-4">
                        <div class="product-card">
                            <?php if($count < 2): // Add "Hot" badge to first two items ?>
                                <span class="feature-badge">HOT</span>
                            <?php endif; ?>
                            
                            <div class="product-img-wrapper">
                                <?php 
                                    $imagePath = !empty($product->image) ? '/webbanhang/' . $product->image : 'https://via.placeholder.com/300x300?text=No+Image';
                                ?>
                                <img src="<?= $imagePath ?>" alt="<?= htmlspecialchars($product->name) ?>">
                            </div>
                            
                            <div class="product-category"><?= htmlspecialchars($product->category_name ?? 'Phụ kiện') ?></div>
                            <h3 class="product-name" title="<?= htmlspecialchars($product->name) ?>">
                                <?= htmlspecialchars($product->name) ?>
                            </h3>
                            
                            <div class="product-price">
                                <?= number_format($product->price, 0, ',', '.') ?> VNĐ
                            </div>
                            
                            <div class="d-flex justify-content-between mt-auto">
                                <a href="/webbanhang/Product/show/<?= $product->id ?>" class="btn btn-outline-custom btn-card-action mr-2">Chi tiết</a>
                                <a href="/webbanhang/Product/addToCart/<?= $product->id ?>" class="btn btn-custom btn-card-action ml-2">Thêm</a>
                            </div>
                        </div>
                    </div>
                <?php 
                $count++;
                endforeach; 
                ?>
            </div>
        <?php else: ?>
            <div class="alert alert-info text-center py-5 rounded-lg border-0 shadow-sm" style="background-color: rgba(99, 102, 241, 0.1); color: var(--primary-color); font-weight: 500;">
                <h4 class="mb-3">Oops!</h4>
                Chưa có sản phẩm nào được đăng bán. Mời quản trị viên thêm sản phẩm mới!
            </div>
        <?php endif; ?>
    </div>
</div>
