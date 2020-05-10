function getDepartmentList(unauthorized, errorcreated, pageurl, time) {
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
                                    <button value="${val.id}" class="btn btn-warning" onclick="giveMessage()">
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
                    // $("#pageIcons").html(pageIcons);
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
                    //$("#pageIcons").html(pageIcons);
                    $("#departmentList").html(emtyTable);
                }
            },
            error: function (error) {
                $("#loading").html("");
                if (error.status == unauthorized) {
                    swal({
                        title: "Lütfen Sisteme Güvenli Giriş Yapınız!",
                        text: "Giriş Sayfasına Yönlendiriliyorsunuz!",
                        icon: "error",
                        buttons: false
                    });
                    redirectToPage(pageurl, time);
                }
                else if (error.responseJSON == errorcreated) {
                    swal({
                        title: "Hata Oluştu!",
                        text: "Veriler Getirilirken Bir Hata Meydana Geldi Lütfen Daha Sonra Tekrar Deneyiniz",
                        icon: "error",
                    });
                    redirectToPage(pageurl, time);
                }
            },
            dataType: "json"
        });
    });
};
function addNewDepartment() {
    resetForm();
    $("#ShowModal").modal();
};
function addDepartment(unauthorized,errorcreated,entityexist,pageurl,time) {
    let department = { "Id": $("#Id").val(), "DepartmentName": $("#Name").val() };

    let url = "https://localhost:44386/departments/adddepartment";
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "POST",
        crossDomain: true,
        url: url,
        async: false,
        data: JSON.stringify(department),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            successMessage();
            getDepartmentList(unauthorized, errorcreated, pageurl,time);
        },
        error: function (error) {
            console.log(error);
            if (error.status == unauthorized) {
                errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                redirectToPage(pageurl,time);
            }
            else if (error.responseJSON == entityexist) {
                errorMessageWithButton("Giriş Hatası!", "Bölüm Zaten Sistemde Kayıtlı");
            }
            else if (error.responseJSON == errorcreated) {
                errorMessageWithoutButton("Hata Oluştu İşlem Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                redirectToPage(pageurl, time);
            }
            else {
                errorMessageWithButton("İşlem Başarıyla Gerçekleştirilemedi", "Girdiğiniz Değerlerden Emin Olunuz!");
            }
        },
        contentType: "application/json",
        dataType: "json"
    });
};
function getByDepartmentId(id,unauthorized,errorcreated,pageurl,time) {

    let department = { "identityKey": id };

    let url = "https://localhost:44386/departments/getbyid";
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "POST",
        crossDomain: true,
        url: url,
        async: false,
        data: JSON.stringify(department),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            $("#ShowUpdateModal").modal();
            document.getElementById("DepartmentId").value = data.id;
            document.getElementById("DepartName").value = data.departmentName;
        },
        error: function (error) {
            console.log(error);
            if (error.status == unauthorized) {
                errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                redirectToPage(pageurl, time);
            }
            else if (error.responseJSON == errorcreated) {
                errorMessageWithoutButton("Hata Oluştu İşlem Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                redirectToPage(pageurl,time);
            }
        },
        contentType: "application/json",
        dataType: "json"
    });
}
function editDepartment(unauthorized,errorcreated,pageurl,time) {
    $(document).ready(function () {
        /*
        $(document).ajaxStart(function () {
            $("#loading").html("Loading....");
        });
        */
        let department = { "Id": $("#DepartmentId").val(), "DepartmentName": $("#DepartName").val() };

        let url = "https://localhost:44386/departments/updatedepartment";

        let accesstoken = localStorage.getItem("token");

        $.ajax({
            type: "PUT",
            crossDomain: true,
            url: url,
            async: false,
            data: JSON.stringify(department),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (departments) {
                $("#loading").html("");
                getDepartmentList(unauthorized, errorcreated, pageurl,time);
            },
            error: function (error) {
                $("#loading").html("");
                if (error.status == unauthorized) {
                    errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız!", "Giriş Sayfasına Yönlendiriliyorsunuz!");
                    redirectToPage(pageurl, time);
                }
                else if (error.responseJSON == errorcreated) {
                    errorMessageWithoutButton("Hata Oluştu İşlem Başarıyla Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                    localStorage.setItem("token", null);
                    redirectToPage(pageurl, time);
                }
            },
            dataType: "json",
            contentType:"application/json"
        });
    });     
};
function removeDepartment(id, unauthorized, errorcreated) {
    let url = "";
};
