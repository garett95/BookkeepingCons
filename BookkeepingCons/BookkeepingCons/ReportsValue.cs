using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookkeepingCons
{
    class ReportsValue
    {
        public ReportsValue(
            int yearName,
            int avgSpendingMonth,
            int avgIncomeMonth,
            List<int> profitMonth)
        {
            YearName = yearName;
            AvgSpendingMonth = avgSpendingMonth;
            AvgIncomeMonth = avgIncomeMonth;
            ProfitMonth = profitMonth;
        }
        public ReportsValue() { }
        public int YearName { get; set; }
        public int AvgSpendingMonth { get; set; }
        public int AvgIncomeMonth { get; set; }
        public List<int> ProfitMonth { get; set; }
    }
}
