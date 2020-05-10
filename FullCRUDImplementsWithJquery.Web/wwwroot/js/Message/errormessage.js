function errorMessageWithButton(title,text) {
    swal({
        title: title,
        text: text,
        icon: "error",
        button: "Tamam"
    })
};
function errorMessageWithoutButton(title, text) {
    swal({
        title: title,
        text: text,
        icon: "error",
        button:false
    })
};