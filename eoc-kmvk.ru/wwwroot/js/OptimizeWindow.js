// Скрипт добавляет классы при изменении масштабирования
window.onresize = function () {
    var blocks = document.querySelectorAll("div.main-block");   // Что будем оптимизировать масштабированием
    var optimize = window.outerWidth / window.innerWidth * 100; // Определяет текущее масштабирование
    console.log(optimize);
    switch (optimize) {
        // Перебор псевдоклассов с оптимизацией разрешения при масштабировании        
        case 90:
        case 80:
        case 70:
        case 60:
        case 40:
        case 30:
        case 20:
        case 10:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.remove("col-lg-3");
                item.classList.add("col-lg-8");
            });
            break;
        case 50:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.remove("col-lg-3");
                item.classList.add("col-lg-6");
            });
            break;
        case 100:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.remove("col-lg-3");
                item.classList.add("col-lg-10");
            });
            break;
        case 33.33333333333333:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.remove("col-lg-3");
                item.classList.add("col-lg-4");
            });
            break;
        case 75:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.remove("col-lg-3");
                item.classList.add("col-lg-8");
            });            
            break;
        case 25:
            blocks.forEach(function (item) {
                item.classList.remove("col-lg-8");
                item.classList.remove("col-lg-6");
                item.classList.remove("col-lg-10");
                item.classList.remove("col-lg-4");
                item.classList.add("col-lg-3");
            });
            break;
    }
};