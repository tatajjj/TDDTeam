using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHW;
using System.Collections.Generic;

namespace TDDHWTest
{
    [TestClass]
    public class BudgetTest
    {
        Budget budget = new Budget();

        [TestMethod]
        public void TestDctData() //測試預算是否能整除月份天數
        {
            //Arrange
            Dictionary<int, int> dctMonthlyBudget = new Dictionary<int, int>();
            dctMonthlyBudget.Add(2, 56);
            dctMonthlyBudget.Add(3, 31);
            budget.MonthlyBudget(dctMonthlyBudget);

            bool verified = budget.VeriftyDctBudgetData();

            //Assert
            Assert.AreEqual(verified, true);
        }

        [TestMethod]
        public void TestSingleMonth()
        {
            //Arrange
            Dictionary<int, int> dctMonthlyBudget = new Dictionary<int, int>();
            dctMonthlyBudget.Add(2, 28);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 02, 01);
            DateTime dEnd = new DateTime(2019, 02, 28);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 0);
        }
    }
}
