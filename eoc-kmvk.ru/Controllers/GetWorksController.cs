using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eoc_kmvk.ru.Models;

namespace eoc_kmvk.ru.Controllers {
    /// <summary>
    /// Получение работ из БД
    /// </summary>
    public class GetWorksController : Controller {
        /// <summary>
        /// Выгружаем изображения работ на главную
        /// </summary>
        /// <param name="works">Через объект класса получаем доступ к методам класса</param>
        /// /// <param name="id">Здесь не используется</param>
        /// <returns></returns>
        public IActionResult Index(GetWorks works, string id) {
            // Выгружаем изображения категорий на главную станицу
            var model = works.GetWorksFromDB(id);
            return View(model);
        }
        /// <summary>
        /// Выгружаем изображения конкретной категории
        /// </summary>
        /// <param name="category">Используем объект класса для получения доступа к его методам</param>
        /// <param name="categoryId">Номер категории с фронта, по которому будем фильтровать изображения работ</param>
        /// <returns></returns>
        public IActionResult GetDetailsImage(GetCategory category, GetPhoto photo, string id) {
            // Проверяем входной параметр id с фронта и в зависимости от него выполняем действия
            switch (id) {
                case "main":
                    return RedirectToAction("Index");
                case "contacts":
                    return RedirectToAction("Contacts");
                case "documentation":
                    return RedirectToAction("Documentation");
                //case "foto_collection":
                //    var model = GetPhotoGal(photo);
                //    return View(model);
                    //return RedirectToAction("PhotoGallery");
            }
            var data = category.GetCategoryFromDB(id);
            return View(data);
        }
        /// <summary>
        /// Страница документации
        /// </summary>
        /// <returns></returns>
        public IActionResult Documentation() { 
            return View();
        }
        public IActionResult Contacts(GetContacts contact) {
            var data = contact.GetContact();
            return View(data);
        }
        /// <summary>
        /// Страница фотогалереи
        /// </summary>
        /// <returns></returns>
        public IActionResult PhotoGallery() {
            return View();
        }
        /// <summary>
        /// Получает фото для фото галереи
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public IActionResult GetPhotoGal(GetPhoto photo) { 
            var model = photo.GetPhotoWork();
            return View(model);
        }
        /// <summary>
        /// Получает фото 2 категории для галереи 
        /// </summary>
        /// <returns></returns>
        public IActionResult GetPhotoGal_2(GetPhoto_2 photo) {
            var model = photo.GetPhotoWork_2();
            return View(model);
        }
        public IActionResult GetPhotoGal_3(GetPhoto photo) {
            var model = photo.GetPhotoWork_3();
            return View(model);
        }
        public IActionResult GetPhotoGal_4(GetPhoto photo) { 
            var model = photo.GetPhotoWork_4();
            return View(model);
        }
        public IActionResult GetPhotoGal_5(GetPhoto photo) {
            var model = photo.GetPhotoWork_5(); 
            return View(model);
        }
        public IActionResult GetPhotoGal_6(GetPhoto photo) {
            var model = photo.GetPhotoWork_6();
            return View(model);
        }
        public IActionResult GetPhotoGal_7(GetPhoto photo) {
            var model = photo.GetPhotoWork_7(); 
            return View(model);
        }
        public IActionResult GetPhotoGal_8(GetPhoto photo) {
            var model = photo.GetPhotoWork_8();
            return View(model);
        }
    }
}