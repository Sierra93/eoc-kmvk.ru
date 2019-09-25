using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eoc_kmvk.ru.Models;

namespace eoc_kmvk.ru.Controllers {
    /// <summary>
    /// Метод получения работ из БД
    /// </summary>
    public class GetWorksController : Controller {
        public IActionResult Index(GetWorks works) {
            // Вызываем метод получающий работы из БД
            var model = works.GetWorksFromDB();
            return View();
        }
    }
}