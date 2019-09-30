﻿using System;
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
        public IActionResult GetDetailsImage(GetCategory category, string id) {
            // Проверяем входной параметр id с фронта и в зависимости от него выполняем действия
            switch (id) {
                case "main":
                    return RedirectToAction("Index");
                case "contacts":
                    return RedirectToAction("Contacts");
                case "documentation":
                    return RedirectToAction("Documentation");
                case "foto_collection":
                    return RedirectToAction("PhotoGallery");
            }
            var data = category.GetCategoryFromDB(id);
            return View(data);
        }
        /// <summary>
        /// Страница контактов
        /// </summary>
        /// <returns></returns>
        public IActionResult Contacts() {
            return View();
        }
        /// <summary>
        /// Страница документации
        /// </summary>
        /// <returns></returns>
        public IActionResult Documentation() { 
            return View();
        }
        /// <summary>
        /// Страница фотогалереи
        /// </summary>
        /// <returns></returns>
        public IActionResult PhotoGallery() {
            return View();
        }
    }
}