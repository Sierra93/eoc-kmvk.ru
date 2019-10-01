using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eoc_kmvk.ru.Models;
using Microsoft.AspNetCore.Http;

namespace eoc_kmvk.ru.Controllers {
    /// <summary>
    /// Контроллер админки, в котором происходят все изменения
    /// </summary>
    public class AdminController : Controller {
        /// <summary>
        /// Метод, который принимает входной параметр с фронта и определяем, с какой страницей мы хотим работать
        /// </summary>
        /// <param name="changes">Параметр категории с фронта. По нему определяем с каким классом будем работать</param>
        /// <returns></returns>
        public IActionResult Index(string changes) {
            // Проверяем параметр с фронта, и в зависимости от него понимаем, с какой страницей будем работать 
            switch(changes) {
                case "main":
                    return RedirectToAction("MainPage");
                case "contacts":
                    return RedirectToAction("ContactsPage");
                case "photo_gallery":
                    break;
                case "documentation":
                    break;
            }
            return View();
        }
        /// <summary>
        /// Метод по работе с главной страницей
        /// </summary>
        /// <param name="form">Параметр для изображений</param>
        /// <param name="add">Параметр кнопки добавить</param>
        /// <param name="change_data">Параметр кнопки изменить</param>
        /// <param name="delete">Параметр кнопки удалить</param>
        /// <param name="user_title_image">Параметр заголовок изображения</param>
        /// <param name="user_details">Параметр описание изображения</param>
        /// <returns></returns>
        public IActionResult MainPage(IFormCollection form, string add, string change_data, string delete, string user_title_image, string user_details, string user_price, string user_nds, string user_category_image, AddMain addData) {
            // Проверяем на null каждый из параметров кнопок с фронта. Если null, то идет дальше, если не null, то возьмет значение
            var combineParam = add ?? change_data ?? delete;
            object data;  // Переменная для передачи измененных данных на страницу
            // В зависимости от нажатой кнопки, будем работать с конкретным классом
            switch (combineParam) {                
                case "Добавить":
                    addData.AddDataInDB(form, user_title_image, user_details, user_price, user_nds, user_category_image);
                    return Content("Данные успешно добавлены");
                case "Изменить":
                    break;
                case "Удалить":
                    break;
            }
            return View();
        }
        /// <summary>
        /// Метод по работе со страницей контакты
        /// </summary>
        /// <returns></returns>
        public IActionResult ContactsPage() {
            return View();
        }
    }
}