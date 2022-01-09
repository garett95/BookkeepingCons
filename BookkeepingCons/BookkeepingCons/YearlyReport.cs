using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class YearlyReport
    {
        public static ReportsValue YearReport(string[] dataFromFile)
        {
            int yearName = 0;
            //int profitMonth = 0;
            int avgSpendingMonth = 0;
            int avgIncomeMonth = 0;
            int sumSpendingYear = 0;
            int sumIncomeYear = 0;
            List<int> incomMonth = new List<int>();
            List<int> spendMonth = new List<int>();
            List<int> profitMonth = new List<int>();
            for (int i = 2; i < dataFromFile.Length; i=i+3)
            {

                if (dataFromFile[i].ToLower() == "true") /* расход*/
                {
                    int spendingMonth = int.Parse(dataFromFile[i - 1]);
                    sumSpendingYear += spendingMonth;
                    spendMonth.Add(spendingMonth);
                }
                else if (dataFromFile[i].ToLower() == "false") /*приход*/
                {
                    int incomeMonth = int.Parse(dataFromFile[i - 1]);
                    sumIncomeYear  += incomeMonth;
                    incomMonth.Add(incomeMonth);
                }
            }
            for (int i = 0; i < incomMonth.Count; i++)
            {
                profitMonth.Add(incomMonth[i] - spendMonth[i]);
            }

            avgIncomeMonth = sumIncomeYear / dataFromFile.Length * 6;
            avgSpendingMonth = sumSpendingYear / dataFromFile.Length * 6;
            return new ReportsValue (
                yearName,
                avgSpendingMonth,
                avgIncomeMonth,
                profitMonth);
        }
    }
}
