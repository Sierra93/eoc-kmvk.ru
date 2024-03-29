﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Общий класс для админки
    /// </summary>
    public abstract class Admin : IGetCategory, IGetWorks {
        public int ID { get; set; }
        public string NameWork { get; set; }   // Название работы
        public string DetailsWork { get; set; }    // Детальное описание работы
        public string ImagePath { get; set; }  // Изображение работы
        public double PriceRoznica { get; set; }  // Цена работы
        public double PriceOpt { get; set; }
        public double PriceBigOpt { get; set; }
        public double PriceSpec_1 { get; set; }
        public double PriceSpec_2 { get; set; }
        public double RubCountNotNds { get; set; } // Руб/шт(без НДС)
        public string TermsOfSale { get; set; }    // Условия продажи
        public int Category { get; set; }  // Категория работы
        public string TitlePage { get; set; }  // Название категории страницы, на которую переходим после выбора конкретной категории
        public string DetailsPage { get; set; }    // Описание работы
        public string ImagePathMiniature_1 { get; set; }
        public string ImagePathMiniature_2 { get; set; }
        public string ImagePathMiniature_3 { get; set; }
        public string ImagePathMiniature_4 { get; set; } 
        public string ImagePathMiniature_5 { get; set; }
        public string ImagePathMiniature_6 { get; set; }
        public string ImagePathMiniature_7 { get; set; }
        public string ImagePathMiniature_8 { get; set; }
        public string ImageTable { get; set; }

        // Метод получения изображений работ из БД
        public abstract IEnumerable GetWorksFromDB(string id);
        // Метод получения категорий работ из БД
        public abstract IEnumerable GetCategoryFromDB(string id);
    }
}
