using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Интерфейс фотогалереи
    /// </summary>
    interface IGetPhoto {
        int ID { get; set; }
        string Title { get; set; }  // Заголовок
        string ImagePath { get; set; }  // Путь изображения
        string Category { get; set; }   // Категория

        object GetPhotoWork();
    }
}
