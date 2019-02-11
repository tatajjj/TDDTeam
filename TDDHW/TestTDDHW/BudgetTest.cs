using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHW;

namespace TDDHWTest
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void SetValidBudgetTest()
        {
            DateTime setdate = new DateTime(2019, 3, 1);
            Budget b = new Budget();
            Assert.AreEqual(b.Set(setdate, 31), true);
        }

        [TestMethod]
        public void SetWrongBudgetTest()
        {
            DateTime setdate = new DateTime(2019, 3, 1);
            Budget b = new Budget();
            Assert.AreEqual(b.Set(setdate, 30), false);
        }

        [TestMethod]
        public void EmptyBudgetTest()
        {
            //Arrange
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            //Act
            Budget b = new Budget();
            //Assert
            Assert.AreEqual(b.Query(start, end), 0);
        }

        [TestMethod]
        public void SingleMonthBudgetTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 3, 1);
            DateTime enddate = new DateTime(2019, 3, 31);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 31);
            int v = b.Query(setdate, enddate);
            //Assert
            Assert.AreEqual(v, 31);
        }

        [TestMethod]
        public void SetSingleMonthBudgetAndQueryCrossMonthTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 3, 1);
            DateTime startdate = new DateTime(2019, 3, 1);
            DateTime enddate = new DateTime(2019, 4, 30);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 31);
            int v = b.Query(setdate, enddate);
            //Assert
            Assert.AreEqual(v, 31);
        }

        [TestMethod]
        public void MultiMonthBudgetAndQuerySingleMonthTest()
        {
            //Arrange
            DateTime startdate = new DateTime(2019, 3, 1);
            DateTime enddate = new DateTime(2019, 3, 31);
            //Act
            Budget b = new Budget();
            b.Set(new DateTime(2019, 2, 1), 28);
            b.Set(new DateTime(2019, 3, 1), 93);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 93);
        }

        [TestMethod]
        public void MultiMonthAndQueryCrossMonthTest()
        {
            //Arrange
            DateTime startdate = new DateTime(2019, 7, 15);
            DateTime enddate = new DateTime(2019, 4, 30);
            //Act
            Budget b = new Budget();
            b.Set(new DateTime(2019, 4, 1), 60);
            b.Set(new DateTime(2019, 6, 1), 120);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 122);
        }

        [TestMethod]
        public void SetOverwriteBudgetTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 3, 1);
            DateTime enddate = new DateTime(2019, 3, 31);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 31);
            b.Set(setdate, 62);
            int v = b.Query(setdate, enddate);
            //Assert
            Assert.AreEqual(v, 62);
        }
    }
}
