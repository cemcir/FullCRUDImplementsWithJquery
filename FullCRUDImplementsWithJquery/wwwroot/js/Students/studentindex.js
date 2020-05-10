function getStudentList() {
    $(document).ready(function () {
        /*
        $(document).ajaxStart(function () {
            $("#loading").html("Loading....");
        });
        */
        let url = "https://localhost:44386/students/getstudentlist";
        //let accesstoken = sessionStorage.getItem("token");
        let accesstoken = localStorage.getItem("token");

        $.ajax({
            type: "GET",
            crossDomain: true,
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (students) {
                $("#loading").html("");
                navbarMenu();

                const pageIcons = `
                <div class="container" style="margin-top:4%">
                    <div class="row">
                        <div class="col-md-6">
                            <button class="btn btn-info" onclick="addNewStudent()">
                                Öğrenci Ekle
                            </button>
                        </div>
                        <div class="col-md-5">
                            <input type="text" id="StuName" onkeyup="getByStudentName()" class="pull-right"/>
                            <label class="pull-right">Adınız: </label>
                        </div>
                    </div>
                </div>`;
                var table = `
                <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Öğrenci No</th>
                            <th>Öğrenci Adı</th>
                            <th>Bölüm</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                </div>`;
                if (students.length > 0) {
                    $.each(students, (key, val) => {
                        table += `<tr>
                                    <td>${val.id}</td>
                                    <td>${val.studentNo}</td>
                                    <td>${val.studentName}</td>
                                    <td>${val.department.departmentName}</td>
                                    <td>
                                        <button value="${val.id}" class="btn btn-warning" onclick="getStudentById(this.value)">
                                            <span class="glyphicon glyphicon-edit"></span>
                                        </button>
                                    </td>
                                    <td>
                                        <button value="${val.id}" onclick="removeStudent(this.value)" class="btn btn-danger">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </td>
                                  </tr>`
                    })
                    table += "</table>";
                    $("#pageIcons").html(pageIcons);
                    $("#studentList").html(table);
                }
                else {
                    var emtyTable = `
                    <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Öğrenci No</th>
                            <th>Öğrenci Adı</th>
                            <th>Bölüm</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                        <tr>
                            <td>Sonuç Bulunamadı</td>
                        </tr>
                    </div>`;
                    $("#pageIcons").html(pageIcons);
                    $("#studentList").html(emtyTable);
                }
                //$("#pageIcons").html(pageIcons);
                //$("#studentList").html(table);
            },
            error: function (error) {
                $("#loading").html("");
                console.log(error);
                //$("#studentList").html("öğrenci listesi getirilemedi");
                //swal("Hatalı Giriş!", "Yönlendiriliyorsunuz", "error");
                if (error.status == 401) {
                    errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                    redirectToPage();
                }
                else if (error.responseJSON == 1) {
                    /*
                    swal({
                        title: "Hata Oluştu!",
                        text: "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz!",
                        icon: "error",
                        buttons: false
                    })
                    */
                    errorMessageWithoutButton("Hata Oluştu Veriler Getirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                    localStorage.setItem("token", null);
                    redirectToPage();
                }
            },
            contentType: "application/json",
            dataType: "json"
        });
    });
};
function getStudentList(unauthorized,errorcreated,pageurl,time) {
    $(document).ready(function () {
        /*
        $(document).ajaxStart(function () {
            $("#loading").html("Loading....");
        });
        */
        let url = "https://localhost:44386/students/getstudentlist";
        //let accesstoken = sessionStorage.getItem("token");
        let accesstoken = localStorage.getItem("token");

        $.ajax({
            type: "GET",
            crossDomain: true,
            url: url,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (students) {
                $("#loading").html("");
               
                var table = `
                <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Öğrenci No</th>
                            <th>Öğrenci Adı</th>
                            <th>Bölüm</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                </div>`;
                if (students.length > 0) {
                    $.each(students, (key, val) => {
                        table += `<tr>
                                    <td>${val.id}</td>
                                    <td>${val.studentNo}</td>
                                    <td>${val.studentName}</td>
                                    <td>${val.department.departmentName}</td>
                                    <td>
                                        <button value="${val.id}" class="btn btn-warning" onclick="getStudentById(this.value)">
                                            <span class="glyphicon glyphicon-edit"></span>
                                        </button>
                                    </td>
                                    <td>
                                        <button value="${val.id}" onclick="removeStudent(this.value)" class="btn btn-danger">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </td>
                                  </tr>`
                    })
                    table += "</table>";
                    $("#studentList").html(table);
                }
                else {
                    var emtyTable = `
                    <div class="container" style="margin-top:3%">
                    <table class="table table-striped">
                        <tr>
                            <th>Id</th>
                            <th>Öğrenci No</th>
                            <th>Öğrenci Adı</th>
                            <th>Bölüm</th>
                            <th>Güncelle</th>
                            <th>Sil</th>
                        </tr>
                        <tr>
                            <td>Sonuç Bulunamadı</td>
                        </tr>
                    </div>`;
                    $("#studentList").html(emtyTable);
                }
            },
            error: function (error) {
                $("#loading").html("");
                console.log(error);
                if (error.status == unauthorized) {
                    errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                    redirectToPage(pageurl,time);
                }
                else if (error.responseJSON == errorcreated) {
                    errorMessageWithoutButton("Hata Oluştu Veriler Getirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                    localStorage.setItem("token", null);
                    redirectToPage(pageurl, time);
                }
            },
            contentType: "application/json",
            dataType: "json"
        });
    });
};
function addNewStudent(unauthorized,errorcreated,pageurl,time) {
    resetForm();
    $("#ShowModal").modal();
    getAddDepartmentList(unauthorized, errorcreated, pageurl,time);
};
function addStudent(unauthorized,errorcreated,entityexist,pageurl,time) {

    let student = { "Id": $("#Id").val(), "StudentName": $("#Name").val(), "StudentNo": $("#StudentNo").val(), "DepartmentId": $("#sel_department").val() };

    let url = "https://localhost:44386/students/addstudent";
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "POST",
        crossDomain: true,
        url: url,
        async: false,
        data: JSON.stringify(student),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            successMessage();
            //window.location.reload();
            getStudentList(unauthorized, errorcreated, pageurl, time);
        },
        error: function (error) {
            console.log(error);
            if (error.status == unauthorized) {
                errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                redirectToPage(pageurl, time);
            }
            else if (error.responseJSON == entityexist) {
                errorMessageWithButton("Giriş Hatası!", "Öğrenci Zaten Sistemde Kayıtlı");
            }
            else if (error.responseJSON == errorcreated) {
                errorMessageWithoutButton("Hata Oluştu İşlem Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                localStorage.setItem("token", null);
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
function resetUpdateForm() {
    document.getElementById("update_form").reset();
};        
function getStudentById(id,unauthorized,errorcreated,pageurl,time) {

    $("#ShowUpdateModal").modal();
    $(document).ready(function () {
        let url = "https://localhost:44386/students/getbystudentid?id=" + id;

        let accesstoken = localStorage.getItem("token");
        $.ajax({
            type: "GET",
            url: url,
            async: false,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
            },
            success: function (student) {
                document.getElementById("StudentId").value = student.id;
                document.getElementById("StudentName").value = student.studentName;
                document.getElementById("StudentNumber").value = student.studentNo;
                getUpdateDepartmentList(unauthorized, errorcreated, pageurl, time);
            },
            error: function (error) {
                if (error.status == unauthorized) {
                    errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız!", "Giriş Sayfasına Yönlendiriliyorsunuz");
                    localStorage.setItem("token", null);
                    redirectToPage(pageurl, time);
                }
                else if (error.responseJSON == errorcreated) {
                    errorMessageWithoutButton("Hata Oluştu", "Veriler Getirilemedi Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                    localStorage.setItem("token", null);
                    redirectToPage(pageurl, time);
                }
            },
            dataType: "json"
        })
    })
};
function editStudent(unauthorized,errorcreated,pageurl,time) {
    let student = { "Id": $("#StudentId").val(), "StudentName": $("#StudentName").val(), "StudentNo": $("#StudentNumber").val(), "DepartmentId": $("#Sel_Department").val() };

    let url = "https://localhost:44386/students/updatestudent";
    let accesstoken = localStorage.getItem("token");

    $.ajax({
        type: "PUT",
        crossDomain: true,
        url: url,
        async: false,
        data: JSON.stringify(student),
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            //window.alert("işlem başarılı");
            //swal({
            //  title: "İşlem Başarılı",
            //icon: "success",
            //});
            successMessage();

            getStudentList(unauthorized, errorcreated, pageurl,time);
        },
        error: function (error) {
            console.log(error);
            if (error.status == unauthorized) {
                errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız!", "Giriş Sayfasına Yönlendiriliyorsunuz");
                redirectToPage(pageurl, time);
            }
            else if (error.responseJSON == errorcreated) {
                errorMessageWithoutButton("Hata Oluştu İşlem Başarıyla Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                localStorage.setItem("token", null);
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
function removeStudent(id,unauthorized,errorcreated,pageurl,time) {
    swal({
        title: "Emin misiniz?",
        text: "Geçerli Kayıdı Silmek İstiyormu sunuz?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if (willDelete) {
            $(document).ready(function () {
                let url = "https://localhost:44386/students/deletestudent";
                let student = { "IdentityKey": id };
                let accesstoken = localStorage.getItem("token");
                $.ajax({
                    type: 'DELETE',
                    url: url,
                    async: false,
                    data: JSON.stringify(student),
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
                    },
                    success: function (data) {
                        successMessage();
                        getStudentList(unauthorized, errorcreated, pageurl,time);  
                    },
                    error: function (error) {
                        if (error.status == unauthorized) {
                            errorMessageWithoutButton("Lütfen Sisteme Güvenli Giriş Yapınız", "Giriş Sayfasına Yönlendiriliyorsunuz");
                            localStorage.setItem("token", null);
                            redirectToPage(pageurl, time);
                        }
                        else if (error.responseJSON == errorcreated) {
                            errorMessageWithoutButton("Hata Oluştu İşlem Başarıyla Gerçekleştirilemedi", "Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz");
                        }
                        localStorage.setItem("token", null);
                        redirectToPage(pageurl, time);
                    },
                    contentType: "application/json",
                });
            });
        }
    });
};
function getAddDepartmentList(unauthorized,errorcreated,pageurl,time) {

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
                if (error.status == unauthorized) {
                    swal({
                        title: "Lütfen Sisteme Güvenli Giriş Yapınız!",
                        text: "Giriş Sayfasına Yönlendiriliyorsunuz!",
                        icon: "error",
                        buttons: false
                    });
                    redirectToPage(pageurl,time);
                }
                else if (error.responseJSON == errorcreated) {
                    swal({
                        title: "Hata Oluştu!",
                        text: "Veriler Getirilirken Bir Hata Meydana Geldi Giriş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz",
                        icon: "error",
                    });
                    redirectToPage(pageurl,time);
                }
            },
            //contentType: "application/json",
            dataType: "json"
        });
    });
};
function getUpdateDepartmentList(unauthorized,errorcreated,pageurl,time) {
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
                $("#Sel_Department").empty();
                for (let i = 0; i < departments.length; i++) {
                    let id = departments[i].id;
                    let name = departments[i].departmentName;

                    $("#Sel_Department").append("<option value='" + id + "'>" + name + "</option>");
                }
            },
            error: function (error) {
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
                        text: "Veriler Getirilirken Bir Hata Meydana Geldi Girş Sayfasına Yönlendiriliyorsunuz Lütfen Daha Sonra Tekrar Deneyiniz",
                        icon: "error",
                    });
                    redirectToPage(pageurl, time);
                }
            },
            //contentType: "application/json",
            dataType: "json"
        });
    });
};