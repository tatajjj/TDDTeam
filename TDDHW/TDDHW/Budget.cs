using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHW
{
    public class Budget
    {
        // key: 預算月份, value: 每日預算
        private Dictionary<DateTime, int> BudgetList = new Dictionary<DateTime, int>();

        private DateTime QueryStart { get; set; }
        private DateTime QueryEnd { get; set; }

        public bool SetMonthlyAmount(Dictionary<DateTime, int> dictionary)
        {
            bool isRightAmount = false;
            foreach (KeyValuePair<DateTime, int> pair in dictionary)
            {
                // 預算必須整除當月天數
                isRightAmount = (pair.Value % DateTime.DaysInMonth(pair.Key.Year, pair.Key.Month) == 0);
                if (isRightAmount)
                {
                    BudgetList.Add(pair.Key, pair.Value / DateTime.DaysInMonth(pair.Key.Year, pair.Key.Month));
                }
            }

            return isRightAmount;
        }

        public bool SetQueryRange(DateTime start, DateTime end)
        {
            bool isRightRange = false;
            // 起始時間需小於結束時間
            if (start <= end)
            {
                isRightRange = true;
            }

            if (isRightRange)
            {
                QueryStart = start;
                QueryEnd = end;
            }
            return isRightRange;
        }

        public int GetBudget()
        {
            int totalBudget = 0;
            foreach (KeyValuePair<DateTime, int> pair in BudgetList)
            {
                // check overlap 
                if (pair.Key <= QueryEnd && QueryStart <= pair.Key.AddMonths(1).AddDays(-1))
                {
                    DateTime overlapStart = new DateTime(Math.Max(pair.Key.Ticks, QueryStart.Ticks));
                    DateTime overlapEnd = new DateTime(Math.Min(pair.Key.AddMonths(1).AddDays(-1).Ticks, QueryEnd.Ticks));
                    totalBudget += (pair.Value * ((overlapEnd - overlapStart).Days + 1));
                }
            }
            return totalBudget;
        }
    }
}
