using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data.SqlClient;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Класс для удаления данных
    /// </summary>
    public class DeleteData : IAdmin {
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
        public string ImagePathMiniature_1 { get; set; }
        public string ImagePathMiniature_2 { get; set; }
        public string ImagePathMiniature_3 { get; set; }
        public string ImagePathMiniature_4 { get; set; }
        public string ImagePathMiniature_5 { get; set; }
        public string ImagePathMiniature_6 { get; set; }
        public string ImagePathMiniature_7 { get; set; }
        public string ImagePathMiniature_8 { get; set; }

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
        /// Метод удаления данных
        /// </summary>
        /// <param name="old_id"></param>
        /// <param name="user_title_image"></param>
        /// <param name="user_details"></param>
        /// <param name="user_image"></param>
        /// <param name="user_price"></param>
        /// <param name="user_nds"></param>
        /// <param name="user_category_image"></param> 
        /// <returns></returns>
        public IEnumerable StartDeleteData(string old_id, string user_category) {
            //string storePath;
            //// Проверяем какую категорию выбрали в ту и сохраним
            //if (user_category_image == "0") {
            //    storePath = "wwwroot/images/photo_projects";
            //}
            //else if (user_category_image == "1") {
            //    storePath = "wwwroot/images/photo_kmvk_1";
            //}
            //else if (user_category_image == "2") {
            //    storePath = "wwwroot/images/photo_kmvk_2";
            //}
            //else if (user_category_image == "3") {
            //    storePath = "wwwroot/images/photo_kmvk_3";
            //}
            //else if (user_category_image == "4") {
            //    storePath = "wwwroot/images/photo_kmvk_4";
            //}
            //else if (user_category_image == "5") {
            //    storePath = "wwwroot/images/photo_kmvk_5";
            //}
            //else {
            //    storePath = "wwwroot/images/photo_kmvk_6";
            //}
            //// Полный локальный путь к файлу включая папку проекта wwwroot
            //var path = Path.Combine(Directory.GetCurrentDirectory(), storePath, user_image.Files[0].FileName);
            //var substrPath = path.Substring(path.IndexOf("wwwroot"));   // Обрезаю лишнюю часть пути и беру только с wwwroot
            //using (var stream = new FileStream(path, FileMode.Create)) {
            //    user_image.Files[0].CopyToAsync(stream);
            //}
            DeleteDataInDB(old_id, user_category);
            return "Данные успешно изменены";
        }
        /// <summary>
        /// Удаляем данные из БД
        /// </summary>
        /// <param name="old_id"></param>
        /// <param name="user_title_image"></param>
        /// <param name="user_details"></param>
        /// <param name="user_image"></param>
        /// <param name="user_price"></param>
        /// <param name="user_nds"></param>
        /// <param name="user_category_image"></param>
        /// <returns></returns>
        public void DeleteDataInDB(string old_id, string user_category) { 
            string tableName = "";
            //substrPath = substrPath.Replace("\\", "/"); // Убираю лишнюю часть пути
            // Определяем название таблицы по категории
            if (user_category == "0") {
                tableName = "WORKS";
            }
            else {
                tableName = "ALL_WORKS";
            }
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("DELETE FROM " + tableName + " WHERE ID = " + old_id, con)) {
                    try {
                        com.ExecuteNonQuery();
                    }
                    catch(Exception ex) {
                        throw new Exception(ex.Message.ToString());
                    }
                }
            }
        }
        public IEnumerable FinalDeleteMiniature(string value, string id, string category) {
            DeleteMiniature(value, id, category);
            return "OK";
        }
        /// <summary>
        /// Удаляем выбранную миниатюру
        /// </summary>
        /// <param name="value">Номер столбца ImagePathMiniature в БД, в который будем записывать NULL для удаления</param>
        /// <param name="id">id изображения в таблице</param>
        /// <param name="category">Номер категории</param>
        public void DeleteMiniature(string value, string id, string category) {
            string tableName = "";
            // Проверяем категорию и получаем название таблицы
            if (category == "0") {
                tableName = "WORKS";
            }
            else {
                tableName = "ALL_WORKS";
            }
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("UPDATE " + tableName + 
                    " SET IMAGE_PATH_MINIATURE_" + value + " = 'NULL'" +
                    " WHERE ID = " + id, con)) {
                    try {
                        com.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        throw new Exception(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
