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
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 2, 1), 56);
            dctMonthlyBudget.Add(new DateTime(2019, 3, 1), 31);
            budget.MonthlyBudget(dctMonthlyBudget);

            bool verified = budget.VeriftyDctBudgetData();

            //Assert
            Assert.AreEqual(verified, true);
        }

        [TestMethod]
        public void TestSingleMonth()
        {
            //Arrange
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 3, 1), 31);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 03, 01);
            DateTime dEnd = new DateTime(2019, 03, 31);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 31);
        }

        [TestMethod]
        public void TestSingleMonth2()
        {
            //Arrange
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 3, 1), 31);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 03, 01);
            DateTime dEnd = new DateTime(2019, 03, 01);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 1);
        }

        [TestMethod]
        public void TestCrossMonth()
        {
            //Arrange
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 2, 1), 28);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 02, 15);
            DateTime dEnd = new DateTime(2019, 03, 15);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 14);
        }

        [TestMethod]
        public void TestCrossMonth2()
        {
            //Arrange
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 2, 1), 28);
            dctMonthlyBudget.Add(new DateTime(2019, 3, 1), 93);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 02, 28);
            DateTime dEnd = new DateTime(2019, 03, 01);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 4);
        }

        [TestMethod]
        public void TestCrossMonth3()
        {
            //Arrange
            Dictionary<DateTime, int> dctMonthlyBudget = new Dictionary<DateTime, int>();
            dctMonthlyBudget.Add(new DateTime(2019, 4, 1), 60);
            dctMonthlyBudget.Add(new DateTime(2019, 6, 1), 120);
            budget.MonthlyBudget(dctMonthlyBudget);

            DateTime dStart = new DateTime(2019, 04, 30);
            DateTime dEnd = new DateTime(2019, 07, 15);
            budget.DateStart(dStart);
            budget.DateEnd(dEnd);

            int periodBudget = budget.GetBudgetResult();

            //Assert
            Assert.AreEqual(periodBudget, 122);
        }
    }
}
