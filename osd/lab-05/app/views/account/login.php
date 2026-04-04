<?php include 'app/views/shares/header.php'; ?> <section class="vh-100 gradient-custom">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card bg-dark text-white" style="border-radius: 1rem;">
                    <div class="card-body p-5 text-center">
                        <form id="login-form">
                            <div id="login-container">
                                <h2 class="fw-bold mb-2 text-uppercase">Login</h2>
                                <p class="text-white-50 mb-5">Please enter your login and password!</p>
                                <div class="form-outline form-white mb-4"> <input type="text" name="username" class="form-control form-control-lg" /> <label class="form-label" for="typeEmailX">UserName</label> </div>
                                <div class="form-outline form-white mb-4"> <input type="password" name="password" class="form-control form-control-lg" /> <label class="form-label" for="typePasswordX">Password</label> </div>
                                <p class="small mb-5 pb-lg-2"><a class="text-white-50" href="#!">Forgot password?</a></p> <button class="btn btn-outline-light btn-lg px-5" type="submit">Login</button>
                                <div class="d-flex justify-content-center text-center mt-4 pt-1"> <a href="#!" class="text-white"><i class="fab fa-facebook-f fa-lg"></i></a> <a href="#!" class="text-white"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a> <a href="#!" class="text-white"><i class="fab fa-google fa-lg"></i></a> </div>
                            </div>
                            
                            <!-- Token Display container (Hidden by default) -->
                            <div id="token-display-container" style="display: none; padding: 20px;">
                                <h3 class="fw-bold mb-4 text-success">Đăng nhập thành công!</h3>
                                <p class="text-white-50 mb-2">Dưới đây là JWT Token của bạn để sử dụng API (với Postman):</p>
                                <div class="form-outline form-white mb-4">
                                    <textarea id="jwt-token-area" class="form-control form-control-lg bg-dark text-white" rows="4" readonly></textarea>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <button type="button" class="btn btn-info px-4" id="copy-token-btn">📋 Copy Token</button>
                                    <button type="button" class="btn btn-primary px-4" id="go-home-btn">Vào Cửa Hàng ➔</button>
                                </div>
                                <div id="copy-feedback" class="mt-3 text-success font-weight-bold" style="display:none;">Đã copy vào bộ nhớ tạm!</div>
                            </div>
                        </div>
                        <div id="signup-container">
                            <p class="mb-0">Don't have an account? <a href="#!" class="text-white-50 fw-bold">Sign Up</a> </p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
</section> <?php include 'app/views/shares/footer.php'; ?> <script>
    document.getElementById('login-form').addEventListener('submit', function(event) {
        event.preventDefault();
        const formData = new FormData(this);
        const jsonData = {};
        formData.forEach((value, key) => {
            jsonData[key] = value;
        });
        fetch('/webbanhang/account/checkLogin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(jsonData)
        }).then(response => response.json()).then(data => {
            if (data.token) {
                localStorage.setItem('jwtToken', data.token);
                // Hide login form and show token
                document.getElementById('login-container').style.display = 'none';
                document.getElementById('signup-container').style.display = 'none';
                
                const tokenContainer = document.getElementById('token-display-container');
                tokenContainer.style.display = 'block';
                document.getElementById('jwt-token-area').value = data.token;
                
            } else {
                alert('Đăng nhập thất bại');
            }
        });
    });

    document.getElementById('copy-token-btn').addEventListener('click', function() {
        const tokenArea = document.getElementById('jwt-token-area');
        tokenArea.select();
        document.execCommand('copy');
        document.getElementById('copy-feedback').style.display = 'block';
        setTimeout(() => {
            document.getElementById('copy-feedback').style.display = 'none';
        }, 3000);
    });

    document.getElementById('go-home-btn').addEventListener('click', function() {
        location.href = '/webbanhang/Product';
    });
</script>