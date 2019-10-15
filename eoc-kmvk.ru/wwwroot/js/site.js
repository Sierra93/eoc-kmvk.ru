window.onload = function () {
    let el = document.getElementById("back");   // Инпут с паролем
    el.addEventListener("click", onClick);  // Кнопка войти
};
function onClick() {
    let password = document.querySelectorAll("input.password")[0].value;
    return $.ajax({
        url: '/Admin/Check',
        dataType: "json",     
        data: {
            password
        },
        success: function (data) {
            // В админку
            window.location.href = "http://eoc-kmvk.ru/Admin/Index";
            console.log("ok");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            // Пароль неверный ругаемся
            alert("Неверный пароль");
            console.log("error");
        }
    });
}




