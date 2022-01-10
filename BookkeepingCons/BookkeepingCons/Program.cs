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
            MonthReportsValue monthReportsValue = new MonthReportsValue();
            int sumSpendingYear = 0;
            int sumIncomeYear = 0;
            for (int i = 1; i < 4; i++)
            {
                string path = $"C:\\Users\\Fedor Andreevich\\Desktop\\ref\\m.20210{i}.csv";
                TextFromFile = Scaner.FileReader(path);
                DataFromFile = Scaner.TextToWords(TextFromFile);
                monthReportsValue = MonflyReport.MonthReport(DataFromFile, i);
                monthReportsValue.PrintMonthReport();
                sumSpendingYear += monthReportsValue.SumSpendingMonth;
                sumIncomeYear += monthReportsValue.SumIncomeMonth;
            }

            string path1 = $"C:\\Users\\Fedor Andreevich\\Desktop\\ref\\y.2021.csv";
            TextFromFile = Scaner.FileReader(path1);
            DataFromFile = Scaner.TextToWords(TextFromFile);
            string name = Path.GetFileNameWithoutExtension(path1);
            name = name.Substring(2);
            YearReportsValue yearReportsValue = new YearReportsValue();
            yearReportsValue = YearlyReport.YearReport(DataFromFile,name);
            yearReportsValue.PrintYearReport();
            Console.WriteLine(ExaminationMonthYear(yearReportsValue, sumSpendingYear, sumIncomeYear));
        }
        public static bool ExaminationMonthYear(
            YearReportsValue yearReportsValue, 
            int sumSpendingYear, 
            int sumIncomeYear)
        {
            return yearReportsValue.SumSpendingYear == sumSpendingYear &&
                yearReportsValue.SumIncomeYear == sumIncomeYear;
        }
    }
}
