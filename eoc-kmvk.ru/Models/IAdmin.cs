using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Общий интерфейс для алгоритмов по изменению содержимого страниц
    /// </summary>
    interface IAdmin {
        int ID { get; set; }
        string NameWork { get; set; }   // Название работы
        string DetailsWork { get; set; }    // Детальное описание работы
        string ImagePath { get; set; }  // Изображение работы
        double Price { get; set; }  // Цена работы
        double RubCountNotNds { get; set; } // Руб/шт(без НДС)
        string TermsOfSale { get; set; }    // Условия продажи
        int Category { get; set; }  // Категория работы
        string TitlePage { get; set; }  // Название категории страницы, на которую переходим после выбора конкретной категории
        string DetailsPage { get; set; }    // Описание работы

        /// <summary>
        /// Метод получения работ из БД
        /// </summary>
        /// <param name="id">Параметр с фронта</param>
        /// <returns></returns>
        IEnumerable GetCategoryFromDB(string id);
        /// <summary>
        /// Метод получения работ из БД
        /// </summary>
        /// <param name="id">Параметр с фронта</param>
        /// <returns></returns>
        IEnumerable GetWorksFromDB(string id);
    }
}
