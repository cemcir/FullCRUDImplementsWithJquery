function navbarMenu() {
    const navbar = `
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <span class="navbar-brand">
                        Öğrenci Sistemi
                    </span>
                </div>
                <ul class="nav navbar-nav">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Verileri Listele <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="/Students/Index">
                                    Öğrencileri Listele
                                </a>
                            </li>
                            <li>
                                <a href="/Departments/Index">
                                    Bölümleri Listele
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li id="navbar-item" class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#"><span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            <li>
                                <a onclick="" href="/Users/Index">
                                    Profil
                                </a>
                            </li>
                            <li>
                                <a onclick="logOut()" href="/Logins/Index">
                                    Çıkış Yap
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>`;
    $("#navbarMenu").html(navbar);
};