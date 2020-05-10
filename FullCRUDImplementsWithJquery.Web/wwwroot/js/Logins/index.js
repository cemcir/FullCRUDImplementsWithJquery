function login() {
    let UserName = $("#UserName").val();
    let Password = $("#Password").val();

    let user = { "UserName": UserName, "Password": Password };

    let url = "https://localhost:44386/api/logins";

    $.ajax({
        type: "POST",
        crossDomain: true,
        url: url,
        data: JSON.stringify(user),
        success: function (data) {
            //sessionStorage.setItem("token", data.token);
            localStorage.setItem("token", data.token);
            document.getElementById("errormessage").innerHTML = "";
            window.location = "/Students/Index";
        },
        error: function (error) {
            console.log(error);
            if (error.responseJSON == 2) {
                document.getElementById("errormessage").innerHTML = "kullanıcı adı veya şifre yanlış";
            }
            document.getElementById("errormessage").innerHTML = "kullanıcı adı veya şifre yanlış";
        },
        contentType: "application/json",
        dataType: "json"
    });
};
function logOut() {

    let url = "https://localhost:44386/api/logins";
    let accesstoken = localStorage.getItem("token");
    $.ajax({
        type: "DELETE",
        crossDomain: true,
        url: url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + accesstoken);
        },
        success: function (data) {
            localStorage.setItem("token", data.token);
            window.location = "/Logins/Index";
        },
        error: function (error) {
            
        },
        dataType: "json"
    });
};
