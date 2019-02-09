using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHW
{
    public class Budget
    {
        private DateTime dateStart;
        private DateTime dateEnd;
        Dictionary<DateTime, int> BudgetData = new Dictionary<DateTime, int>();

        public void MonthlyBudget(Dictionary<DateTime, int> monthlyBudget)
        {
            BudgetData = monthlyBudget;
        }

        public void DateStart(DateTime dDateStart)
        {
            dateStart = dDateStart;
        }

        public void DateEnd(DateTime dDateEnd)
        {
            dateEnd = dDateEnd;
        }

        public bool VeriftyDctBudgetData()
        {
            bool verified = true;
            int days = 0;
            foreach (var item in BudgetData)
            {
                DateTime month = item.Key;
                int budget = item.Value;
                days = DateTime.DaysInMonth(item.Key.Year, item.Key.Month);
                if (budget % days != 0)
                {
                    verified = false;
                }   
            }
            return verified;
        }

        public int GetBudgetResult()
        {
            /*
             *loop 檢查 "預算X月份"是否小於等於 使用者輸入endDate 並且 "預算X月份"最後一天是否大於等於 使用者輸入startDate
             *變數MonthTotalDays 取得"預算X月份"總天數, 目的取得每日預算
             *dtStart: 預算日期 與 使用者輸入查詢起始日取大
             *dtpEnd: 預算日期最後一天日期 與 使用者輸入查詢結束日取小
             */
            int result = 0;
            foreach (var item in BudgetData)
            {
                if (item.Key <= dateEnd && item.Key.AddMonths(1).AddDays(-1) >= dateStart)
                {
                    int MonthTotalDays = DateTime.DaysInMonth(item.Key.Year, item.Key.Month);
                    DateTime dtStart = new DateTime(Math.Max(item.Key.Ticks, dateStart.Ticks));
                    DateTime dtpEnd = new DateTime(Math.Min(item.Key.AddMonths(1).AddDays(-1).Ticks, dateEnd.Ticks));
                    result += ((item.Value / MonthTotalDays) * ((dtpEnd - dtStart).Days + 1));
                }
            }
            return result;
        }
    }
}
