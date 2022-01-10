using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class MonflyReport
    {

        public static MonthReportsValue MonthReport(string[] dataFromFile, int monthNumber)
        {
            int spendingMonth = 0; /*траты за месяц*/
            int sumSpendingMonth = 0; /*сумма трат замесяц*/
            int maxMonthSpending = spendingMonth;
            int incomeMonth = 0; /*доход за месяц*/
            int sumIncomeMonth = incomeMonth;
            int maxIncomeMonth = 0; /*доходы за месяц */
            string monthName = MonthName(monthNumber);
            string itemSpendingName = null; /*самый расходный товар*/
            string itemIncomeName = null; /*самый доходный товар*/
            for (int i = 1; i < dataFromFile.Length; i = i + 4)
            {
                if (dataFromFile[i] == "TRUE") /* расход*/
                {
                    spendingMonth = int.Parse(dataFromFile[i + 1]) * int.Parse(dataFromFile[i + 2]);
                    if (spendingMonth > maxMonthSpending)
                    {
                        maxMonthSpending = spendingMonth;
                        itemSpendingName = dataFromFile[i - 1];
                    }
                    sumSpendingMonth += spendingMonth;
                }
                else if (dataFromFile[i] == "FALSE") /*приход*/
                {
                    incomeMonth = int.Parse(dataFromFile[i + 1]) * int.Parse(dataFromFile[i + 2]);
                    if (incomeMonth > maxIncomeMonth)
                    {
                        maxIncomeMonth = incomeMonth;
                        itemIncomeName = dataFromFile[i - 1];
                    }
                    sumIncomeMonth += incomeMonth;
                }
            }
            return new MonthReportsValue (
                monthName,
                itemSpendingName,
                maxMonthSpending,
                itemIncomeName,
                maxIncomeMonth,
                sumIncomeMonth,
                sumSpendingMonth);
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
    }
}
