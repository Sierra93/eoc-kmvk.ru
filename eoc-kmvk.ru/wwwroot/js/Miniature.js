// Передаем на бэк номер миниатюры изображения и id текущего изображения
var PostIdMiniature = (value, id, category) => {
    return $.ajax({
        url: '/Admin/FinallyDeleteMiniature/',
        type: "POST",
        dataType: "json",
        data: { value, id, category },
        success: (data) => {
            console.log("ok");
        },
        error: (XMLHttpRequest, textStatus, errorThrown) => {
            console.log("error");
        }
    });
};