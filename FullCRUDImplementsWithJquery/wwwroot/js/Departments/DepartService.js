class DepartmentService {

    constructor() {

    }

    /*
    getDepartmentList() {
        $(document).ready(function () {

            $("#loading").html("Loading....");
            
            let url = "https://localhost:44386/departments/getdepartmentlist";
            let accesstoken = localStorage.getItem("token");

            $.ajax({
                type: "GET",
                crossDomain: true,
                url: url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
                },
                success: function (departments) {
                    navbarMenu();

                    $("#loading").html("");
                    const pageIcons = `
                <div class="container" style="margin-top:4%">
                    <div class="row">
                        <div class="col-md-6">
                            <button class="btn btn-info" onclick="addNewDepartment()">
                                Bölüm Ekle
                            </button>
                        </div>
                        <div class="col-md-5">
                            <input type="text" id="" onkeyup="" class="pull-right"/>
                            <label class="pull-right">
                                Bölüm Adı: 
                            </label>
                        </div>
                    </div>
                </div>`;
                    var table = `
                <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Bölüm Adı</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                </div>`;
                    if (departments.length > 0) {
                        $.each(departments, (key, val) => {
                            table += `
                            <tr>
                                <td>${val.id}</td>
                                <td>${val.departmentName}</td>
                                <td>
                                    <button value="${val.id}" class="btn btn-warning" onclick="">
                                        <span class="glyphicon glyphicon-edit"></span>
                                    </button>
                                </td>
                                <td>
                                    <button value="${val.id}" onclick="" class="btn btn-danger">
                                        <span class="glyphicon glyphicon-trash">
                                        </span>
                                    </button>
                                </td>
                            </tr>`
                        })
                        table += "</table>";
                        $("#pageIcons").html(pageIcons);
                        $("#departmentList").html(table);
                    }
                    else {
                        var emtyTable = `
                    <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Bölüm Adı</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                        <tr>
                            <td>Sonuç Bulunamadı</td>
                        </tr>
                    </div>`;
                        $("#pageIcons").html(pageIcons);
                        $("#departmentList").html(emtyTable);
                    }    
                },
                error: function (error) {
                    $("#loading").html("");
                    if (error.status == 401) {
                        swal({
                            title: "Lütfen Sisteme Güvenli Giriş Yapınız!",
                            text: "Giriş Sayfasına Yönlendiriliyorsunuz!",
                            icon: "error",
                            buttons: false
                        });
                        redirectToPage();
                    }
                    else if (error.responseJSON == 1) {
                        swal({
                            title: "Hata Oluştu!",
                            text: "Veriler Getirilirken Bir Hata Meydana Geldi Lütfen Daha Sonra Tekrar Deneyiniz",
                            icon: "error",
                        });
                    }
                },
                dataType: "json"
            });
        });     
    };
    */

    getAddDepartmentList() {
        $(document).ready(function () {

            let url = "https://localhost:44386/departments/getdepartmentlist";
            //let accesstoken = sessionStorage.getItem("token");
            let accesstoken = localStorage.getItem("token");

            $.ajax({
                type: "GET",
                crossDomain: true,
                url: url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
                },
                success: function (departments) {
                    $("#sel_department").empty();
                    for (let i = 0; i < departments.length; i++) {
                        let id = departments[i].id;
                        let name = departments[i].departmentName;

                        $("#sel_department").append("<option value='" + id + "'>" + name + "</option>");
                    }
                },
                error: function (error) {
                    if (error.status == 401) {
                        swal({
                            title: "Lütfen Sisteme Güvenli Giriş Yapınız!",
                            text: "Giriş Sayfasına Yönlendiriliyorsunuz!",
                            icon: "error",
                            buttons: false
                        });
                        redirectToPage();
                    }
                    else if (error.responseJSON == 1) {
                        swal({
                            title: "Hata Oluştu!",
                            text: "Veriler Getirilirken Bir Hata Meydana Geldi Lütfen Daha Sonra Tekrar Deneyiniz",
                            icon: "error",
                        });
                    }
                },
                //contentType: "application/json",
                dataType: "json"
            });
        });
    };

    getUpdateDepartmentList() {
        $(document).ready(function () {

            let url = "https://localhost:44386/departments/getdepartmentlist";
            let accesstoken = localStorage.getItem("token");

            $.ajax({
                type: "GET",
                crossDomain: true,
                url: url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
                },
                success: function (departments) {
                    $("#Sel_Department").empty();
                    for (let i = 0; i < departments.length; i++) {
                        let id = departments[i].id;
                        let name = departments[i].departmentName;

                        $("#Sel_Department").append("<option value='" + id + "'>" + name + "</option>");
                    }
                },
                error: function (error) {
                    if (error.status == 401) {
                        swal({
                            title: "Lütfen Sisteme Güvenli Giriş Yapınız!",
                            text: "Giriş Sayfasına Yönlendiriliyorsunuz!",
                            icon: "error",
                            buttons: false
                        });
                        redirectToPage();
                    }
                    else if (error.responseJSON == 1) {
                        swal({
                            title: "Hata Oluştu!",
                            text: "Veriler Getirilirken Bir Hata Meydana Geldi Lütfen Daha Sonra Tekrar Deneyiniz",
                            icon: "error",
                        });
                    }
                },
                //contentType: "application/json",
                dataType: "json"
            });
        });
    };

    giveMessage() {
        window.alert("hello world");
    };

    addNewDepartment() {
        resetForm();
        $("#ShowModal").modal();
        this.getAddDepartmentList();
    };

    resetForm() {
        document.getElementById("form").reset();
    };
};