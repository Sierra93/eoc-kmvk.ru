using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace eoc_kmvk.ru.Models {
    public class GetWorks : IGetWorks {
        // Строка подключения к БД на хостинге
        string connectionString = "Server=37.140.192.41,1433; Initial Catalog=u0817454_EocDB; Persist Security Info=False; User ID=u0817_admin; Password=Qwerty2; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
        public int ID { get; set; }
        public string NameWork { get; set; }   // Название работы
        public string DetailsWork { get; set; }    // Детальное описание работы
        public string ImagePath { get; set; }  // Изображение работы
        public string Price { get; set; }  // Цена работы
        public string RubCountNotNds { get; set; } // Руб/шт(без НДС)
        public string TermsOfSale { get; set; }    // Условия продажи

        /// <summary>
        /// Реализация метода получения работ из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetWorksFromDB() {
            return null;
        }
        /// <summary>
        /// Метод получает список работ из БД
        /// </summary>
        /// <returns></returns>
        public List<GetWorks> GetImageFromDB() {
            List<GetWorks> collectionWorks = new List<GetWorks>();
            return collectionWorks;
        }
    }
}
