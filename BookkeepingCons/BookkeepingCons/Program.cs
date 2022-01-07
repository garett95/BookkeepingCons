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
            string[] report = new string[3];
            for (int i = 1; i < 4; i++)
            {
                string path = $"C:\\Users\\Fedor Andreevich\\Desktop\\ref\\m.20210{i}.csv";
                TextFromFile = FileReader(path);
                DataFromFile = TextToWords(TextFromFile);
                report = MonthReport(DataFromFile, i);
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
        public static string MonthName(int monthNumber)
        {
            string month = null;
            switch (monthNumber)
            {
                case 1:
                    month = "Январь";
                    break;
                case 2:
                    month = "Февраль";
                    break;
                case 3:
                    month = "Март";
                    break;
                case 4:
                    month = "Апрель";
                    break;
                case 5:
                    month = "Май";
                    break;
                case 6:
                    month = "Июнь";
                    break;
                case 7:
                    month = "Июль";
                    break;
                case 8:
                    month = "Август";
                    break;
                case 9:
                    month = "Сентябрь";
                    break;
                case 10:
                    month = "Октябрь";
                    break;
                case 11:
                    month = "Ноябрь";
                    break;
                case 12:
                    month = "Декабрь";
                    break;
                default:
                    break;
            }
            return month;
        }
        public static string[] MonthReport(string[] dataFromFile, int monthNumber)
        {
            int spendingMonth = 0; /*траты за месяц*/
            int sumSpendingMonth = 0; /*сумма трат замесяц*/
            int maxMonthSpending = spendingMonth;
            int incomeMonth = 0; /*доход за месяц*/
            int sumIncomeMonth = incomeMonth;
            int maxIncomeMonth = 0; /*доходы за месяц */
            string monthName = MonthName(monthNumber);
            string itemSpendingName = null; /*самый расходный товар*/
            string itemIncomeName=null; /*самый доходный товар*/
            for (int i=1; i < dataFromFile.Length;i=i+4)
            {
                if (dataFromFile[i] == "TRUE") /* расход*/
                {
                    spendingMonth = int.Parse(dataFromFile[i + 1]) * int.Parse(dataFromFile[i + 2]);
                    if(spendingMonth > maxMonthSpending)
                    {
                        maxMonthSpending = spendingMonth;
                        itemSpendingName = dataFromFile[i - 1];
                    }
                    sumSpendingMonth += spendingMonth;
                }
                else if (dataFromFile[i] == "FALSE") /*приход*/
                {
                    incomeMonth = int.Parse(dataFromFile[i + 1]) * int.Parse(dataFromFile[i + 2]);
                    if(incomeMonth > maxIncomeMonth)
                    {
                        maxIncomeMonth = incomeMonth;
                        itemIncomeName = dataFromFile[i - 1];
                    }
                    sumIncomeMonth += incomeMonth;
                }
            }
            return new string[] {
                monthName,
                itemSpendingName,
                maxMonthSpending.ToString(),
                itemIncomeName,
                maxIncomeMonth.ToString()};
        }
        public static void YearReport()
        {
            int i;
            for (i = 0; i < DataFromFile.Length; i++)
            {
                if (i.ToString() == "TRUE") /* расход*/
                {
                    int spendingYear = int.Parse(DataFromFile[i - 1].ToString());
                    SpendingYear = SpendingYear - spendingYear;
                }
                else if (i.ToString() == "FALSE") /*приход*/
                {
                    int incomeYear = int.Parse(DataFromFile[i - 1].ToString());
                    IncomeYear = IncomeYear + incomeYear;
                }
            }
        }

    }
}
