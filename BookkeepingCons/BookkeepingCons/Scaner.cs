using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class Scaner
    {
        public static string FileReader(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                //Console.WriteLine($"Текст из файла: {textFromFile}");
                //TextFromFile = textFromFile;
                return textFromFile;
            }
        }
        public static string[] TextToWords(string textFromFile)
        {
            string[] strings = textFromFile.Split(new char[] { '\n', '\r' });
            var stringsList = strings.ToList();
            stringsList.RemoveAt(0);
            string words = string.Join(",", stringsList.ToArray());
            return words.Split(new char[] { ',' });
        }
    }
}
