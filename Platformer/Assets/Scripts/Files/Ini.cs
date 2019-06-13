using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Ini
{
    /// 
    /// Функция сохраняет данные в ini файл
    /// 
    /// имя файла в директории Data приложения (в редакторе используется папка Assets)
    /// данные в виде словаря
    public static void Save(string fileName, Dictionary<string, string> data)
    {
        // используем построитель строк для получения полного текста файла
        StringBuilder sb = new StringBuilder();

        // для каждой пары ключ-значение добавляем строку
        foreach (var keyValuePair in data)
        {
            sb.AppendLine(keyValuePair.Key.Encript() + "=" + keyValuePair.Value.Encript());
        }

        // получаем полный путь
        string path = GetFullPath(fileName);

        // сохраняем
        File.WriteAllText(path, sb.ToString());
    }

    /// 
    /// Функция читает данные из ini файла
    /// 
    /// имя файла в директории Data приложения (в редакторе используется папка Assets)
    /// 
    public static Dictionary<string, string> Load(string fileName)
    {
        // создаем словарь
        var data = new Dictionary<string, string>();

        // получаем полный путь к файлу
        string path = GetFullPath(fileName);

        if (File.Exists(path))
        {
            // читаем файл в массив строк
            string[] lines = File.ReadAllLines(path);

            // выполняем получение данных из кадой строки
            foreach (string line in lines)
            {
                string dataString = line.Trim();

                // пустые строки пропускаем
                if (string.IsNullOrEmpty(dataString)) continue;

                // так же пропускаем строки, не содержащие равно
                if (dataString.Contains("="))
                {
                    // находим позицию первого равно
                    int pos = dataString.IndexOf("=");

                    // получаем данные
                    string key = dataString.Substring(0, pos).Trim();
                    string value = "";
                    if ((pos + 1) < dataString.Length)
                    {
                        value = dataString.Substring(pos + 1, dataString.Length - pos - 1).Trim();
                    }
                    // сохраняем данные в коллекцию
                    data.Add(key.Decript(), value.Decript());
                }

            }
        }
        else
        {
            return null;
        }

        
        return data;
    }

    /// 
    /// Функция получаения полного пути в папке Data приложения (Assets в режиме редактора)
    /// 
    /// Относительный путь к файлу
    /// Полный путь
    public static string GetFullPath(string localPath)
    {
        string basePath = Application.dataPath.Trim();
        if (!(basePath.EndsWith("/") || basePath.EndsWith("\\")))
        {
            basePath += "/";
        }

        localPath = localPath.Trim();
        if (localPath.StartsWith("/") || localPath.StartsWith("\\"))
        {
            localPath = localPath.Substring(1);
        }

        return basePath + localPath;
    }
}