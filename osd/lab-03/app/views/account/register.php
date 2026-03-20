<?php include 'app/views/shares/header.php'; ?>

<div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card shadow-lg">
                <div class="card-header text-center">
                    <h3>Register</h3>
                </div>

                <div class="card-body">

                    <!-- Hiển thị lỗi -->
                    <?php if (isset($errors) && count($errors) > 0): ?>
                        <div class="alert alert-danger">
                            <ul class="mb-0">
                                <?php foreach ($errors as $err): ?>
                                    <li><?= $err ?></li>
                                <?php endforeach; ?>
                            </ul>
                        </div>
                    <?php endif; ?>

                    <form action="/webbanhang/account/save" method="post">

                        <!-- Username -->
                        <div class="form-group mb-3">
                            <label>Username</label>
                            <input type="text" class="form-control"
                                name="username"
                                value="<?= $username ?? '' ?>">
                        </div>

                        <!-- Fullname -->
                        <div class="form-group mb-3">
                            <label>Full Name</label>
                            <input type="text" class="form-control"
                                name="fullname"
                                value="<?= $fullName ?? '' ?>">
                        </div>

                        <!-- Password -->
                        <div class="form-group mb-3">
                            <label>Password</label>
                            <input type="password" class="form-control"
                                name="password">
                        </div>

                        <!-- Confirm Password -->
                        <div class="form-group mb-3">
                            <label>Confirm Password</label>
                            <input type="password" class="form-control"
                                name="confirmpassword">
                        </div>

                        <!-- Button -->
                        <div class="text-center">
                            <button class="btn btn-primary w-100">
                                Register
                            </button>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

<?php include 'app/views/shares/footer.php'; ?>