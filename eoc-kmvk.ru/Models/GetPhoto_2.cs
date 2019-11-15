using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace eoc_kmvk.ru.Models {
    public class GetPhoto_2 : IGetPhoto {
        string connectionString = "Server=31.31.196.160,1433; Initial Catalog=u0818710_EocDB; Persist Security Info=False; User ID=u0818710_admin; Password=Qwerty22; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public object GetPhotoWork() {
            return null;
        }
        /// <summary>
        /// Получает фото 2 категории для галереи
        /// </summary>
        /// <returns></returns>
        public object GetPhotoWork_2() {
            var data = GetPhotoWork_2();
            return data;
        }
        public List<GetPhoto_2> GetPhotoGallery_2() {
            List<GetPhoto_2> collectionPhoto = new List<GetPhoto_2>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT TITLE, IMAGE_PATH FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 2", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                collectionPhoto.Add(new GetPhoto_2 {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Title = reader["TITLE"].ToString(),
                                    ImagePath = reader["IMAGE_PATH"].ToString(),
                                    Category = reader["CATEGORY"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return collectionPhoto;
        }
    }
}
