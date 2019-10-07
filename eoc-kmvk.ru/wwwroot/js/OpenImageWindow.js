// Скрипт для увеличение изображения на весь экран при клике по нему
let openImageWindow = (src) => {
    var image = new Image();
    image.src = src;
    var width = image.width;
    var height = image.height;
    window.open(src, "Image", "width=" + width + ",height=" + height);
};