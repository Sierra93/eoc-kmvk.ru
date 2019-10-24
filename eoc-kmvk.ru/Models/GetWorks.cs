using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Получение категорий работ из БД
    /// </summary>
    public class GetWorks : IGetWorks {
        // Строка подключения к БД на хостинге
        string connectionString = "Server=31.31.196.160,1433; Initial Catalog=u0818710_EocDB; Persist Security Info=False; User ID=u0818710_admin; Password=Qwerty22; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
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
        public int Category { get; set; }   // Категория работы
        public string ImagePathMiniature_1 { get; set; }
        public string ImagePathMiniature_2 { get; set; }
        public string ImagePathMiniature_3 { get; set; }
        public string ImagePathMiniature_4 { get; set; }
        public string ImagePathMiniature_5 { get; set; }
        public string ImagePathMiniature_6 { get; set; }
        public string ImagePathMiniature_7 { get; set; }
        public string ImagePathMiniature_8 { get; set; }
        public string ImageTable { get; set; }

        /// <summary>
        /// Реализация метода получения работ из БД
        /// </summary>
        /// <param name="id">Здесь не используется</param>
        /// <returns></returns>
        public IEnumerable GetWorksFromDB(string id) {
            var data = GetCategoryFromDB();
            return data;
        }
        /// <summary>
        /// ID работы с фронта. По нему получаем работу, которую хотим изменить
        /// </summary>
        /// <param name="change_data"></param>
        /// <returns></returns>
        public IEnumerable GetChangeData(string change_data, string number_category) {
            var data = GetChangeDataDB(change_data, number_category);
            return data;
        }
        /// <summary>
        /// Получаем из БД работу, которую хотим изменить
        /// </summary>
        /// <param name="change_data"></param>
        /// <returns></returns>
        public List<GetWorks> GetChangeDataDB(string change_data, string number_category) {
            List<GetWorks> collectionConcreteWork = new List<GetWorks>();
            string tableName = number_category == "0" ? "WORKS" : "ALL_WORKS";  // Получаем название таблицы по категории
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM " + tableName + " WHERE ID = " + change_data, con)) {
                    using (var reader = com.ExecuteReader()) {
                        if(reader.HasRows) {
                            while(reader.Read()) {
                                collectionConcreteWork.Add(new GetWorks {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    NameWork = reader["NAME_WORK"].ToString(),
                                    DetailsWork = reader["DETAILS_WORK"].ToString(),
                                    ImagePath = reader["IMAGE_PATH"].ToString(),
                                    //PriceRoznica = Convert.ToDouble(reader["PRICE_ROZNICE"]),
                                    //PriceOpt = Convert.ToDouble(reader["PRICE_OPT"]),
                                    //PriceBigOpt = Convert.ToDouble(reader["PRICE_BIG_OPT"]),
                                    //PriceSpec_1 = Convert.ToDouble(reader["PRICE_SPEC_1"]),
                                    //PriceSpec_2 = Convert.ToDouble(reader["PRICE_SPEC_2"]),
                                    RubCountNotNds = Convert.ToDouble(reader["RUB_COUNT_NOT_NDS"]),
                                    TermsOfSale = reader["TERMS_OF_SALE"].ToString(),
                                    Category = Convert.ToInt32(reader["CATEGORY"]),
                                    ImageTable = reader["IMAGE_TABLE"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return collectionConcreteWork;
        }
        /// <summary>
        /// Метод получает список изображений категорий из БД
        /// </summary>
        /// <returns></returns>
        public List<GetWorks> GetCategoryFromDB() {
            List<GetWorks> collectionWorks = new List<GetWorks>();  // Коллекция, в которой будем хранить полученные работы
            // Начинаем подключение к БД
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                // Команда sql-запроса
                using (var com = new SqlCommand("SELECT * FROM WORKS", con)) {
                    // Выполняем запрос
                    using (var reader = com.ExecuteReader()) {
                        // Проверяем есть ли строки в нашей выборке                    
                        if (reader.HasRows) {
                            // Пока идет чтение потока, добавляем в коллекцию то что нашли
                            while(reader.Read()) {
                                collectionWorks.Add(new GetWorks {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    NameWork = reader["NAME_WORK"].ToString(),
                                    DetailsWork = reader["DETAILS_WORK"].ToString(),
                                    ImagePath = reader["IMAGE_PATH"].ToString(),
                                    //PriceRoznica = Convert.ToDouble(reader["PRICE_ROZNICE"]),
                                    //PriceOpt = Convert.ToDouble(reader["PRICE_OPT"]),
                                    //PriceBigOpt = Convert.ToDouble(reader["PRICE_BIG_OPT"]),
                                    //PriceSpec_1 = Convert.ToDouble(reader["PRICE_SPEC_1"]),
                                    //PriceSpec_2 = Convert.ToDouble(reader["PRICE_SPEC_2"]),
                                    RubCountNotNds = Convert.ToDouble(reader["RUB_COUNT_NOT_NDS"]),
                                    TermsOfSale = reader["TERMS_OF_SALE"].ToString(),
                                    Category = Convert.ToInt32(reader["CATEGORY"])
                                    //ImageTable = reader["IMAGE_TABLE"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return collectionWorks;
        }
        /// <summary>
        /// Получаем конкретную строку, в которую будем добавлть новую миниатюру
        /// </summary>
        /// <param name="id_delete">Строка в БД в которую будем вставлять миниатюру</param>
        /// <returns></returns>
        public IEnumerable GetMiniature(string id_delete) { 
            var data = GetMiniatureList(id_delete);            
            return data;
        }
        /// <summary>
        /// Извлечение списка миниатюр для выбора конкретной
        /// </summary>
        public List<GetWorks> GetMiniatureList(string id_delete) {
            List<GetWorks> collectionMiniatures = new List<GetWorks>();
            string empty = "";
            // Подключаемся к БД
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                // Sql-запрос фильтрующий фото в зависимости от категории пришедшей с фронта
                using (var com = new SqlCommand("SELECT * " +
                    "FROM ALL_WORKS " +
                    "WHERE ID = " + id_delete, con)) {
                    // Выполняем запрос
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                // Добавляем отфильтрованные данные в коллекцию для вывода на фронт
                                collectionMiniatures.Add(new GetWorks {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    NameWork = reader["NAME_WORK"].ToString(),
                                    DetailsWork = reader["DETAILS_WORK"].ToString(),
                                    ImagePath = reader["IMAGE_PATH"].ToString(),
                                    //PriceRoznica = Convert.ToDouble(reader["PRICE_ROZNICE"]),
                                    //PriceOpt = Convert.ToDouble(reader["PRICE_OPT"]),
                                    //PriceBigOpt = Convert.ToDouble(reader["PRICE_BIG_OPT"]),
                                    //PriceSpec_1 = Convert.ToDouble(reader["PRICE_SPEC_1"]),
                                    //PriceSpec_2 = Convert.ToDouble(reader["PRICE_SPEC_2"]),
                                    RubCountNotNds = Convert.ToDouble(reader["RUB_COUNT_NOT_NDS"]),
                                    TermsOfSale = reader["TERMS_OF_SALE"].ToString(),
                                    Category = Convert.ToInt32(reader["CATEGORY"]),
                                    //TitlePage = reader["TITLE_PAGE"].ToString(),
                                    //DetailsPage = reader["DETAILS_PAGE"].ToString(),
                                    ImagePathMiniature_1 = reader["IMAGE_PATH_MINIATURE_1"].ToString(),
                                    ImagePathMiniature_2 = reader["IMAGE_PATH_MINIATURE_2"].ToString(),
                                    ImagePathMiniature_3 = reader["IMAGE_PATH_MINIATURE_3"].ToString(),
                                    ImagePathMiniature_4 = reader["IMAGE_PATH_MINIATURE_4"].ToString(),
                                    ImagePathMiniature_5 = reader["IMAGE_PATH_MINIATURE_5"].ToString(),
                                    ImagePathMiniature_6 = reader["IMAGE_PATH_MINIATURE_6"].ToString(),
                                    ImagePathMiniature_7 = reader["IMAGE_PATH_MINIATURE_7"].ToString(),
                                    ImagePathMiniature_8 = reader["IMAGE_PATH_MINIATURE_8"].ToString(),
                                    ImageTable = reader["IMAGE_TABLE"].ToString()
                                });
                            }
                        }
                    }
                }
            }            
            // Ищем пустой столбец в строке с id_delete, чтобы понять в какой вставлять миниатюру
            foreach (var item in collectionMiniatures) {
                // Ищем пустой столбец в объекте data
                if (item.ImagePathMiniature_1 == "") {
                    empty = "IMAGE_PATH_MINIATURE_1";
                }
                else if (item.ImagePathMiniature_2 == "") {
                    empty = "IMAGE_PATH_MINIATURE_2";
                }
                else if (item.ImagePathMiniature_3 == "") {
                    empty = "IMAGE_PATH_MINIATURE_3";
                }
                else if (item.ImagePathMiniature_4 == "") {
                    empty = "IMAGE_PATH_MINIATURE_4";
                }
                else if (item.ImagePathMiniature_5 == "") {
                    empty = "IMAGE_PATH_MINIATURE_5";
                }
                else if (item.ImagePathMiniature_6 == "") {
                    empty = "IMAGE_PATH_MINIATURE_6";
                }
                else if (item.ImagePathMiniature_7 == "") {
                    empty = "IMAGE_PATH_MINIATURE_7";
                }
                else if (item.ImagePathMiniature_8 == "") {
                    empty = "IMAGE_PATH_MINIATURE_8";
                }
                else {
                    throw new Exception("Нет ячейки для новой миниатюры");
                }
            }
            //AddMiniature(empty);
            return collectionMiniatures;
        }
        /// <summary>
        /// Вызываем метод вставки миниатюры в БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetListMiniatures(string catalog_miniature, string new_miniature, string category_name) {
            //string storePath;
            // Проверяем какую категорию выбрали в ту и сохраним
            //if (category_name == "0") {
            //    storePath = "wwwroot/images/photo_projects";
            //}
            //else if (category_name == "1") {
            //    storePath = "wwwroot/images/photo_kmvk_1";
            //}
            //else if (category_name == "2") {
            //    storePath = "wwwroot/images/photo_kmvk_2";
            //}
            //else if (category_name == "3") {
            //    storePath = "wwwroot/images/photo_kmvk_3";
            //}
            //else if (category_name == "4") {
            //    storePath = "wwwroot/images/photo_kmvk_4";
            //}
            //else if (category_name == "5") {
            //    storePath = "wwwroot/images/photo_kmvk_5";
            //}
            //else {
            //    storePath = "wwwroot/images/photo_kmvk_6";
            //}
            //// Полный локальный путь к файлу включая папку проекта wwwroot
            //var path = Path.Combine(Directory.GetCurrentDirectory(), storePath, catalog_miniature.Files[0].FileName);
            //var substrPath = path.Substring(path.IndexOf("wwwroot"));   // Обрезаю лишнюю часть пути и беру только с wwwroot
            //using (var stream = new FileStream(path, FileMode.Create)) {
            //    catalog_miniature.Files[0].CopyToAsync(stream);
            //}
            //AddMiniaturesDB(substrPath, new_miniature, category_name);
            return "Миниатюра успешно добавлена";
            ////AddMiniaturesDB(new_miniature, category_name);
            //return "OK";
        }
        /// <summary>
        /// Запись миниатюры в БД
        /// </summary>
        /// <param name="new_miniature">Новое название миниатюры</param>
        /// <param name="category_name">Номер категории</param>
        //public void AddMiniaturesDB(string new_miniature, string category_name, string substrPath) {
        //    if(new_miniature != null && category_name != null) {
        //        using (var con = new SqlConnection(connectionString)) {
        //            con.Open();
        //            using (var com = new SqlCommand("", con)) {

        //            }
        //        }
        //    }
        //}
    }
}
