﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Получение фото конкретных категорий
    /// </summary>
    public class GetCategory : IGetCategory {
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

        /// <summary>
        /// Метод для получения изображений
        /// </summary>
        /// <param name="id">Параметр с фронта по которому будем фильтровать</param>
        /// <returns></returns>
        public IEnumerable GetCategoryFromDB(string id) {
            var data = GetCategoryImage(id);
            return data;
        }
        /// <summary>
        /// Вызов метода получеия категории изображений для добавления миниатюры
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetMiniatureList(string id) {
            var data = GetListMiniatureDB(id);
            return data;
        }
        /// <summary>
        /// Получаем категорию изображений, в которой находится изображение, которому будем добавлять миниатюру
        /// </summary>
        /// <returns></returns>
        public List<GetCategory> GetListMiniatureDB(string id) {
            List<GetCategory> collectionCategoryMiniatures = new List<GetCategory>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM ALL_WORKS AS p2 " +
                    " JOIN WORKS AS p1 " +
                    " ON p2.CATEGORY = p1.CATEGORY " +
                    " WHERE p2.CATEGORY = " + id, con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                collectionCategoryMiniatures.Add(new GetCategory {
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
                                    TitlePage = reader["TITLE_PAGE"].ToString(),
                                    DetailsPage = reader["DETAILS_PAGE"].ToString(),
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
            return collectionCategoryMiniatures;
        }
        /// <summary>
        /// Получаем конкретные изображения
        /// </summary>
        /// <param name="id">Параметр с фронта по кторому будем фильтровать</param>
        /// <returns></returns>
        public List<GetCategory> GetCategoryImage(string id) {
            // Коллекция хранящая отфильтрованные изображения работ
            List<GetCategory> collectionFilterImage = new List<GetCategory>();
            // Подключаемся к БД
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                // Sql-запрос фильтрующий фото в зависимости от категории пришедшей с фронта
                using (var com = new SqlCommand("SELECT * " +
                    "FROM ALL_WORKS AS p2 " +
                    "JOIN WORKS AS p1 " +
                    "ON p2.CATEGORY = p1.CATEGORY " +
                    "WHERE p2.CATEGORY = " + id, con)) {
                    // Выполняем запрос
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                // Добавляем отфильтрованные данные в коллекцию для вывода на фронт
                                collectionFilterImage.Add(new GetCategory {
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
                                    TitlePage = reader["TITLE_PAGE"].ToString(),
                                    DetailsPage = reader["DETAILS_PAGE"].ToString(),
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
            return collectionFilterImage;
        }
    }
}
