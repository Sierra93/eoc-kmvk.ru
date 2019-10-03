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
        double Price { get; set; }  // Цена работы
        double RubCountNotNds { get; set; } // Руб/шт(без НДС)
        string TermsOfSale { get; set; }    // Условия продажи
        int Category { get; set; }  // Категория работы
        string ImagePathMiniature_1 { get; set; }
        string ImagePathMiniature_2 { get; set; }
        string ImagePathMiniature_3 { get; set; }
        string ImagePathMiniature_4 { get; set; }
        string ImagePathMiniature_5 { get; set; } 
        string ImagePathMiniature_6 { get; set; }
        string ImagePathMiniature_7 { get; set; }
        string ImagePathMiniature_8 { get; set; }

        /// <summary>
        /// Метод получения работ из БД
        /// </summary>
        /// <returns></returns>
        IEnumerable GetWorksFromDB(string id);
    }
}
