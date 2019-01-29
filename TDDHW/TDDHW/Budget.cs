using System;
using System.Collections.Generic;

namespace TDDHW
{
    public class Budget
    {
        Dictionary<DateTime, int> DailyValues = new Dictionary<DateTime, int>();

        public int Query(DateTime start, DateTime end)
        {
            int Result = 0;
            foreach (KeyValuePair<DateTime, int> DailyValue in DailyValues)
            {
                if (DailyValue.Key >= new DateTime(start.Year, start.Month, 1) &&
                    DailyValue.Key <= end)
                {
                    int LastDay = DateTime.DaysInMonth(DailyValue.Key.Year, DailyValue.Key.Month);

                    TimeSpan tsStart = new TimeSpan(Math.Max(DailyValue.Key.Ticks, start.Ticks));
                    TimeSpan tsEnd = new TimeSpan(Math.Min(
                        new DateTime(DailyValue.Key.Year, DailyValue.Key.Month, LastDay).Ticks, 
                        end.Ticks));

                    Result += DailyValue.Value * ((tsEnd - tsStart).Days + 1);
                }
            }

            return Result;
        }

        public bool Set(DateTime d, int v)
        {
            DateTime Setdate = new DateTime(d.Year, d.Month, 1);

            if (v % DateTime.DaysInMonth(Setdate.Year, Setdate.Month) == 0)
            {
                DailyValues[Setdate] = v / DateTime.DaysInMonth(Setdate.Year, Setdate.Month);
                return true;
            }
            return false;
        }
    }
}
