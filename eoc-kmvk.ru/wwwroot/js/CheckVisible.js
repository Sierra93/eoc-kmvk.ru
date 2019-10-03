// Проверка условия видимости контролов в админке
let onCheckVisible = () => {
    // Проверяем все ли формы изначально скрыты. Если нет, то скрываем все
    if (document.getElementById("addForm") &&
        document.getElementById("changeForm")
        /*document.getElementById("deleteForm").classList.contains("visible")*/) {
        document.getElementById("addForm").classList.replace("visible", "hidden");
        document.getElementById("changeForm").classList.replace("visible", "hidden");
        //document.getElementById("deleteForm").classList.replace("visible", "hidden");
    }
    let value = document.getElementById("checkSelect").value;   // Получаем значение селекта
    let visibleForm;    // Какую форму будем показывать
    // Показываем нужную форму
    switch (value) {
        // Добавление данных
        case "addData":
            visibleForm = document.getElementById("addForm");
            visibleForm.classList.replace("hidden", "visible");
            break;
        // Изменение данных
        case "changeData":
            visibleForm = document.getElementById("changeForm");
            //visibleForm = document.getElementsByClassName("category");
            visibleForm.classList.replace("hidden", "visible");
            break;
        // Удаление данных
        case "deleteData":
            visibleForm = document.getElementById("deleteForm");
            visibleForm.classList.replace("hidden", "visible");
            break;
        // Добавление миниатюр
    }
};
var change = () => {
    document.getElementsByTagName("p")[0].textContent = "abc";
};