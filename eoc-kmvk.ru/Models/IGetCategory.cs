using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Интерфейс общий для категорий работ
    /// </summary>
    interface IGetCategory {
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
        /// <returns></returns>
        IEnumerable GetCategoryFromDB(string id); 
    }
}
