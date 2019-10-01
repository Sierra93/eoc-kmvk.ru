using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eoc_kmvk.ru.Models {
    /// <summary>
    /// Класс для загрузки файлов в папку
    /// </summary>
    public class FileManager {
        public async Task<bool> UploadFile(IFormFile file) {
            try {
                bool isCopied = false;
                // Проверяем если длина файла не равна 0
                if(file.Length > 0) {
                    string fileName = file.FileName;    // Имя файла
                    string extension = Path.GetExtension(fileName);     // Получаем расширение файла
                    if (extension == ".png" || extension == ".jpg") {
                        // Прописываем путь к папке, в которую будем сохранять новые изображения
                        string filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/photo_projects"));
                        using(var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create)) {
                            await file.CopyToAsync(fileStream);
                            isCopied = true;
                        }
                    }
                    else {
                        throw new Exception("Файл должен быть формата .png или .jpg");
                    }
                }
                return isCopied;
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}
