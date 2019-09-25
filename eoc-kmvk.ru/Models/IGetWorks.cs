using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Интерфейс, содержащий реализацию с получением работ из БД
    /// </summary>
    interface IGetWorks {
        int ID { get; set; }
        string NameWork { get; set; }   // Название работы
        string DetailsWork { get; set; }    // Детальное описание работы
        string ImagePath { get; set; }  // Изображение работы
        string Price { get; set; }  // Цена работы
        string RubCountNotNds { get; set; } // Руб/шт(без НДС)
        string TermsOfSale { get; set; }    // Условия продажи

        /// <summary>
        /// Метод получения работ из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable GetWorksFromDB();
    }
}
