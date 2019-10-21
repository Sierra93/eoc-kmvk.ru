using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Класс реализует фотогалерею
    /// </summary>
    public class GetPhoto : IGetPhoto {
        string connectionString = "Server=31.31.196.160,1433; Initial Catalog=u0818710_EocDB; Persist Security Info=False; User ID=u0818710_admin; Password=Qwerty22; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

        /// <summary>
        /// Метод для фотогалереи
        /// </summary>
        /// <returns></returns>
        public object GetPhotoWork() {
            var data = GetPhotoGallery();
            return data;
        }
        /// <summary>
        /// Получает фото
        /// </summary>
        /// <returns></returns>
        public List<GetPhoto> GetPhotoGallery() {
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if(reader.HasRows) {
                            while(reader.Read()) {
                                collectionPhoto.Add(new GetPhoto {
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
