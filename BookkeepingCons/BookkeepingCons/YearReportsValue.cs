using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class YearReportsValue
    {
        public YearReportsValue(
            string yearName,
            int avgSpendingMonth,
            int avgIncomeMonth,
            List<int> profitMonth,
            int sumSpendingYear,
            int sumIncomeYear)
        {
            YearName = yearName;
            AvgSpendingMonth = avgSpendingMonth;
            AvgIncomeMonth = avgIncomeMonth;
            ProfitMonth = profitMonth;
            SumSpendingYear = sumSpendingYear;
            SumIncomeYear = sumIncomeYear;
        }
        public YearReportsValue() { }
        public string YearName { get; set; }
        public int AvgSpendingMonth { get; set; }
        public int AvgIncomeMonth { get; set; }
        public int SumSpendingYear { get; set; }
        public int SumIncomeYear { get; set; }
        public List<int> ProfitMonth { get; set; }
        public  void PrintYearReport()
        {
            Console.WriteLine($"Год - {YearName}");
            Console.WriteLine($"Среднемесячный доход - {AvgIncomeMonth}");
            Console.WriteLine($"Среднемесячный расход - {AvgSpendingMonth}");
            for (int i = 0; i < ProfitMonth.Count; i++)
            {
                Console.WriteLine($"Прибыль за 0{i+1} - {ProfitMonth[i]}");
            }
        }
    }
}
