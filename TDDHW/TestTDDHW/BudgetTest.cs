using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHW;

namespace TDDHWTest
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void AddRightBudgetTest()
        {
            //Act
            Budget budget = new Budget();

            //Assert
            Assert.AreEqual(budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 31 }
            }), true);
        }
        [TestMethod]
        public void AddWrongBudgetTest()
        {
            //Act
            Budget budget = new Budget();

            //Assert
            Assert.AreEqual(budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 100 }
            }), false);
        }
        [TestMethod]
        public void SetRightRangeTest()
        {
            //Act
            Budget budget = new Budget();

            //Assert
            Assert.AreEqual(budget.SetQueryRange(new DateTime(2019, 1, 1), new DateTime(2019, 1, 31)), true);
        }
        [TestMethod]
        public void SetWrongRangeTest()
        {
            //Act
            Budget budget = new Budget();

            //Assert
            Assert.AreEqual(budget.SetQueryRange(new DateTime(2019, 1, 31), new DateTime(2019, 1, 1)), false);
        }
        [TestMethod]
        public void GetSingleMonthBudget()
        {
            Budget budget = new Budget();
            budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 31 }
            });
            budget.SetQueryRange(new DateTime(2019, 1, 1), new DateTime(2019, 1, 31));

            Assert.AreEqual(budget.GetBudget(), 31);
        }
        [TestMethod]
        public void GetLessThanOneMonthBudget()
        {
            Budget budget = new Budget();
            budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 31 }
            });
            budget.SetQueryRange(new DateTime(2019, 1, 1), new DateTime(2019, 1, 10));

            Assert.AreEqual(budget.GetBudget(), 10);
        }
        [TestMethod]
        public void GetCrossMonthBudget()
        {
            Budget budget = new Budget();
            budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 31 }
            });
            budget.SetQueryRange(new DateTime(2019, 1, 1), new DateTime(2019, 2, 28));

            Assert.AreEqual(budget.GetBudget(), 31);
        }
        [TestMethod]
        public void GetMulitpleMonthBudget()
        {
            Budget budget = new Budget();
            budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 1, 1), 31 },
                { new DateTime(2019, 2, 1), 56 },
                { new DateTime(2019, 3, 1), 93 },
            });
            budget.SetQueryRange(new DateTime(2019, 1, 22), new DateTime(2019, 3, 10));

            Assert.AreEqual(budget.GetBudget(), 96);
        }
        [TestMethod]
        public void GetNotSettingMonthBudget()
        {
            Budget budget = new Budget();
            budget.SetMonthlyAmount(new Dictionary<DateTime, int>()
            {
                { new DateTime(2019, 2, 1), 28 }
            });
            budget.SetQueryRange(new DateTime(2019, 1, 1), new DateTime(2019, 1, 31));

            Assert.AreEqual(budget.GetBudget(), 0);
        }
    }
}
