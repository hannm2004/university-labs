</main>

<footer style="
    background: rgba(15,23,42,0.95);
    border-top: 1px solid rgba(255,255,255,0.07);
    padding: 24px;
    text-align: center;
    color: #475569;
    font-size: 13px;
    margin-top: auto;
">
    © 2024 ShopHub – Hệ thống quản lý sản phẩm. Bảo mật bằng
    <span style="color:#6366f1; font-weight:600;">JWT HS256</span>
</footer>

<script>
// Mã JWT Token lấy từ localStorage để dùng demo/debug
(function(){
    const t = localStorage.getItem('jwtToken');
    if (t) {
        console.log('%c[ShopHub JWT] Token:', 'color:#6366f1;font-weight:bold', t);
    }
})();
</script>
</body>
</html>