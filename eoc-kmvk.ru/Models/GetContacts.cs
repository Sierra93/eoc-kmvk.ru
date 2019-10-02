using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using eoc_kmvk.ru.Models;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Класс получения контактов из БД
    /// </summary>
    public class GetContacts {
        // Строка подключения к БД на хостинге
        string connectionString = "Server=31.31.196.160,1433; Initial Catalog=u0818710_EocDB; Persist Security Info=False; User ID=u0818710_admin; Password=Qwerty22; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30";
        public int ID { get; set; }
        public string Title { get; set; }   // Заголовок компании
        public string UrAddress { get; set; }   // Юридический адрес 
        public string PochAddress { get; set; } // Почтовый адрес
        public string INN { get; set; }     // ИНН
        public string KPP { get; set; }     // КПП
        public string Boss { get; set; }    // Имя руководителя
        public string Number { get; set; }  // Номер телефона
        public string TimeWork { get; set; }    // Время работы
        public string Email { get; set; }   // Почта

        /// <summary>
        /// Получение контактов
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetContact() {
            var data = GetContactsDB();
            return data;
        }
        /// <summary>
        /// Получаем контакты из БД
        /// </summary>
        /// <returns></returns>
        public List<GetContacts> GetContactsDB() {
            List<GetContacts> collectionContacts = new List<GetContacts>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM CONTACTS", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if(reader.HasRows) {
                            while (reader.Read()) {
                                collectionContacts.Add(new GetContacts {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Title = reader["TITLE"].ToString(),
                                    UrAddress = reader["UR_ADDRESS"].ToString(),
                                    PochAddress = reader["POCT_ADDRESS"].ToString(),
                                    INN = reader["INN"].ToString(),
                                    KPP = reader["KPP"].ToString(),
                                    Boss = reader["BOSS"].ToString(),
                                    Number = reader["NUMBER"].ToString(),
                                    TimeWork = reader["TIME_WORK"].ToString(),
                                    Email = reader["EMAIL"].ToString()
                                });
                                    
                            }
                        }
                    }
                }
            }
            return collectionContacts;
        }
    }
}
