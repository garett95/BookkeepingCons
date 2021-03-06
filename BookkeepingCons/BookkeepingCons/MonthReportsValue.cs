using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class MonthReportsValue
    {
        public MonthReportsValue(
            string monthName,
            string itemSpendingName,
            int maxMonthSpending,
            string itemIncomeName,
            int maxIncomeMonth,
            int sumIncomeMonth,
            int sumSpendingMonth)
        {
            MonthName = monthName;
            ItemSpendingName = itemSpendingName;
            MaxMonthSpending = maxMonthSpending;
            ItemIncomeName = itemIncomeName;
            MaxIncomeMonth = maxIncomeMonth;
            SumIncomeMonth = sumIncomeMonth;
            SumSpendingMonth = sumSpendingMonth;
        }
        public MonthReportsValue () {}
        public string MonthName {get;set;}
        public string ItemSpendingName { get; set; }
        public int MaxMonthSpending { get; set; }
        public string ItemIncomeName { get; set; }
        public int MaxIncomeMonth { get; set; }
        public int SumIncomeMonth { get; set; }
        public int SumSpendingMonth { get; set; }
        public void PrintMonthReport()
        {
            Console.WriteLine($"Название месяца:{MonthName}");
            Console.WriteLine($"Самый прибыльный товар: {ItemIncomeName} сумма {MaxIncomeMonth}");
            Console.WriteLine($"Самая большая трата: {ItemSpendingName} сумма {MaxMonthSpending}");
        }
    }
}
