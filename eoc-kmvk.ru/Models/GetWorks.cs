using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        public double Price { get; set; }  // Цена работы
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
                                    Price = Convert.ToDouble(reader["PRICE"]),
                                    RubCountNotNds = Convert.ToDouble(reader["RUB_COUNT_NOT_NDS"]),
                                    TermsOfSale = reader["TERMS_OF_SALE"].ToString(),
                                    Category = Convert.ToInt32(reader["CATEGORY"])
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
                                    Price = Convert.ToDouble(reader["PRICE"]),
                                    RubCountNotNds = Convert.ToDouble(reader["RUB_COUNT_NOT_NDS"]),
                                    TermsOfSale = reader["TERMS_OF_SALE"].ToString(),
                                    Category = Convert.ToInt32(reader["CATEGORY"])
                                });
                            }
                        }
                    }
                }
            }
            return collectionWorks;
        }
        /// <summary>
        /// Получаем список миниатюр для возврата во вью
        /// </summary>
        /// <param name="id"></param>
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
                                    Price = Convert.ToDouble(reader["PRICE"]),
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
                                    ImagePathMiniature_8 = reader["IMAGE_PATH_MINIATURE_8"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return collectionMiniatures;
        }
    }
}
