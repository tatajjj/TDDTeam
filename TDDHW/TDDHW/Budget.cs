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
        Dictionary<int, int> BudgetData = new Dictionary<int, int>();

        public void MonthlyBudget(Dictionary<int, int> monthlyBudget)
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
                int month = item.Key;
                int budget = item.Value;
                days = DateTime.DaysInMonth(2019, month);
                if (budget % days != 0)
                {
                    verified = false;
                }   
            }
            return verified;
        }

        public int GetBudgetResult()
        {
            return 0;
        }
    }
}
