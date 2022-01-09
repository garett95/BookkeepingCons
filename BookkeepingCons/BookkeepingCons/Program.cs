using System;
using System.IO;
using System.Linq;

namespace BookkeepingCons
{
    class Program
    {
        public static string TextFromFile { get; set; } /*текст из файла*/
        public static string[] DataFromFile { get; set; } /*данные для обработки*/
        public static int IncomeMonth { get; set; } /*доход за месяц*/
        public static int SpendingMonth { get; set; } /*расход за месяц*/
        public static int IncomeYear { get; set; } /*доход за год*/
        public static int SpendingYear { get; set; } /*расход за год*/
        static void Main(string[] args)
        {
            //string[] report = new string[5];
            //for (int i = 1; i < 4; i++)
            //{
            //    string path = $"C:\\Users\\Fedor Andreevich\\Desktop\\ref\\m.20210{i}.csv";
            //    TextFromFile = FileReader(path);
            //    DataFromFile = TextToWords(TextFromFile);
            //    report = MonflyReport.MonthReport(DataFromFile, i);
            //    for (int j = 0; j < report.Length; j++)
            //    {
            //        Console.WriteLine($" {report[j]}");
            //    }
            //}
            string path1 = $"C:\\Users\\Fedor Andreevich\\Desktop\\ref\\y.2021.csv";
            TextFromFile = FileReader(path1);
            DataFromFile = TextToWords(TextFromFile);
            ReportsValue reportsValue = new ReportsValue();
            reportsValue = YearlyReport.YearReport(DataFromFile);
            //for (int j = 0; j < report.Length; j++)
            //{
            //    Console.WriteLine($" {report[j]}");
            //}
            Console.WriteLine(reportsValue.YearName);
            Console.WriteLine(reportsValue.AvgIncomeMonth);
            Console.WriteLine(reportsValue.AvgSpendingMonth);
            foreach (var item in reportsValue.ProfitMonth)
            {
                Console.WriteLine(item);
            }


        }
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
            return words.Split(new char[] {','});
        }
        

    }
}
