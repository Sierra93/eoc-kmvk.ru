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
                    return RedirectToAction("Contacts");
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
        /// Запрашиваем категорию, которую будем изменять и выведем на форму админки
        /// </summary>
        /// <param name="id">Номер категории</param>
        /// <returns></returns>
        public IActionResult ChangePage(GetCategory category, string id) { 
            var data = category.GetCategoryFromDB(id);
            return View(data);
        }
        /// <summary>
        /// Выведем конкретную работу для ее редактирования
        /// </summary>
        /// <param name="change_data"></param>
        /// /// <param name="number_category">Номер категории</param>
        /// <returns></returns>
        public IActionResult GetChangeData(string change_data, string number_category, GetWorks work) {
            var data = work.GetChangeData(change_data, number_category);
            return View(data);
        }
        /// <summary>
        /// Изменение данных
        /// </summary>
        /// <param name="old_id">Старый id нужен чтобы обновить данные в таблицах</param>
        /// <param name="user_title_image">Заголовок работы</param>
        /// <param name="user_details">Описание</param>
        /// <param name="user_image">Новое изображение</param>
        /// <param name="user_price">Ценаparam>
        /// <param name="user_nds">Цена без НДС</param>
        /// <param name="user_category_image">Номер новой категории</param>
        /// <returns></returns> 
        public IActionResult EditData(string old_id, string user_title_image, string user_details, IFormCollection substrPath, string user_price, string user_nds, string user_category_image, EditData edit) {
            if(old_id != null) {
                edit.StartEditData(old_id, user_title_image, user_details, substrPath, user_price, user_nds, user_category_image);
                return Content("Данные успешно изменены");
            }
            return View();
        }
        /// <summary>
        /// Удаление данных(получаем всю категорию, среди которой та, которую будем удалять)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public IActionResult DeletePage(string id, GetCategory category) {
            var data = category.GetCategoryFromDB(id);
            return View(data);
        }
        /// <summary>
        /// Удаляем конкретную работу
        /// </summary>
        /// <param name="old_id"></param>
        /// <param name="user_title_image"></param>
        /// <param name="user_details"></param>
        /// <param name="substrPath"></param>
        /// <param name="user_price"></param>
        /// <param name="user_nds"></param>
        /// <param name="user_category_image"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        public IActionResult GetDeleteData(string change_data, string number_category, GetWorks work) {
            var data = work.GetChangeData(change_data, number_category);
            return View(data);
        }
        public IActionResult DeleteData(string old_id, string user_category_image, DeleteData delete) {
            if(old_id != null) {
                delete.StartDeleteData(old_id, user_category_image);
                return Content("Данные успешно удалены");
            }
            return View();
        }
    }
}