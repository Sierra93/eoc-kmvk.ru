using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Класс для изменения данных
    /// </summary>
    public class EditData : IAdmin {
        string connectionString = "Server=31.31.196.160,1433; Initial Catalog=u0818710_EocDB; Persist Security Info=False; User ID=u0818710_admin; Password=Qwerty22; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
        public int ID { get; set; }
        public string NameWork { get; set; }   // Название работы
        public string DetailsWork { get; set; }    // Детальное описание работы
        public string ImagePath { get; set; }  // Изображение работы
        public double Price { get; set; }  // Цена работы
        public double RubCountNotNds { get; set; } // Руб/шт(без НДС)
        public string TermsOfSale { get; set; }    // Условия продажи
        public int Category { get; set; }  // Категория работы
        public string TitlePage { get; set; }  // Название категории страницы, на которую переходим после выбора конкретной категории
        public string DetailsPage { get; set; }    // Описание работы

        // Метод получения изображений работ из БД
        public IEnumerable GetWorksFromDB(string id) {
            return null;
        }
        // Метод получения категорий работ из БД
        public IEnumerable GetCategoryFromDB(string id) {
            return null;
        }
        public IEnumerable AddDataInDB(IFormCollection form, string user_title_image, string user_details, string user_price, string user_nds, string user_category_image) {
            return null;
        }
        /// <summary>
        /// Метод изменения данных
        /// </summary>
        /// <param name="old_id"></param>
        /// <param name="user_title_image"></param>
        /// <param name="user_details"></param>
        /// <param name="user_image"></param>
        /// <param name="user_price"></param>
        /// <param name="user_nds"></param>
        /// <param name="user_category_image"></param>
        /// <returns></returns>
        public IEnumerable StartEditData(string old_id, string user_title_image, string user_details, IFormCollection user_image, string user_price, string user_nds, string user_category_image) {
            string storePath;
            // Проверяем какую категорию выбрали в ту и сохраним
            if (user_category_image == "0") {
                storePath = "wwwroot/images/photo_projects";
            }
            else if (user_category_image == "1") {
                storePath = "wwwroot/images/photo_kmvk_1";
            }
            else if (user_category_image == "2") {
                storePath = "wwwroot/images/photo_kmvk_2";
            }
            else if (user_category_image == "3") {
                storePath = "wwwroot/images/photo_kmvk_3";
            }
            else if (user_category_image == "4") {
                storePath = "wwwroot/images/photo_kmvk_4";
            }
            else if (user_category_image == "5") {
                storePath = "wwwroot/images/photo_kmvk_5";
            }
            else {
                storePath = "wwwroot/images/photo_kmvk_6";
            }
            // Полный локальный путь к файлу включая папку проекта wwwroot
            var path = Path.Combine(Directory.GetCurrentDirectory(), storePath, user_image.Files[0].FileName);
            var substrPath = path.Substring(path.IndexOf("wwwroot"));   // Обрезаю лишнюю часть пути и беру только с wwwroot
            using (var stream = new FileStream(path, FileMode.Create)) {
                user_image.Files[0].CopyToAsync(stream);
            }
            EditDataInDB(old_id, user_title_image, user_details, substrPath, user_price, user_nds, user_category_image);
            return "Данные успешно изменены";
        }
        /// <summary>
        /// Изменяем данные в БД
        /// </summary>
        /// <param name="old_id"></param>
        /// <param name="user_title_image"></param>
        /// <param name="user_details"></param>
        /// <param name="user_image"></param>
        /// <param name="user_price"></param>
        /// <param name="user_nds"></param>
        /// <param name="user_category_image"></param>
        /// <returns></returns>
        public void EditDataInDB(string old_id, string user_title_image, string user_details, string substrPath, string user_price, string user_nds, string user_category_image) {
            List<EditData> collectionEditData = new List<EditData>();
            string tableName = "";
            substrPath = substrPath.Replace("\\", "/");
            if (user_category_image == "0") {
                tableName = "WORKS";
            }
            else {
                tableName = "ALL_WORKS";
            }
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("UPDATE " + tableName + " SET NAME_WORK = " + "'" + user_title_image + "'" +
                    " WHERE ID = " + old_id, con)) {
                    using (var com2 = new SqlCommand("UPDATE " + tableName + " SET DETAILS_WORK = " + "'" + user_details + "'" +
                        " WHERE ID = " + old_id, con)) {
                        using (var com3 = new SqlCommand("UPDATE " + tableName + " SET IMAGE_PATH = " + "'" + substrPath + "'" +
                            " WHERE ID = " + old_id, con)) {
                            using (var com4 = new SqlCommand("UPDATE " + tableName + " SET PRICE = " + user_price +
                                " WHERE ID = " + old_id, con)) {
                                using (var com5 = new SqlCommand("UPDATE " + tableName + " SET RUB_COUNT_NOT_NDS = " + user_nds +
                                    " WHERE ID = " + old_id, con)) {
                                    using (var com6 = new SqlCommand("UPDATE " + tableName + " SET CATEGORY = " + user_category_image + " WHERE ID = " + old_id, con)) {
                                        try {
                                            com.ExecuteNonQuery();
                                            com2.ExecuteNonQuery();
                                            com3.ExecuteNonQuery();
                                            com4.ExecuteNonQuery();
                                            com5.ExecuteNonQuery();
                                            com6.ExecuteNonQuery();
                                        }
                                        catch (Exception ex) {
                                            throw new Exception(ex.Message.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
