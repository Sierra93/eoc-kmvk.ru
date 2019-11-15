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
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 1", con)) {
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
        public object GetPhotoWork_3() {
            var data = GetPhotoWork_3();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_3() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 3", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
        public object GetPhotoWork_4() {
            var data = GetPhotoWork_4();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_4() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 4", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
        public object GetPhotoWork_5() {
            var data = GetPhotoWork_5();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_5() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 5", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
        public object GetPhotoWork_6() {
            var data = GetPhotoWork_6();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_6() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 6", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
        public object GetPhotoWork_7() {
            var data = GetPhotoWork_7();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_7() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 7", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
        public object GetPhotoWork_8() {
            var data = GetPhotoWork_8();
            return data;
        }
        public List<GetPhoto> GetPhotoGallery_8() { 
            List<GetPhoto> collectionPhoto = new List<GetPhoto>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM PHOTO_GALLERY " +
                    "WHERE CATEGORY = 8", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
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
