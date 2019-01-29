using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHW;

namespace TDDHWTest
{
    [TestClass]
    public class BudgetTest
    {
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
        public void SetBudgetTest()
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
        public void FebDoubleValueTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 2, 1);
            DateTime enddate = new DateTime(2019, 2, 28);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 56);
            int v = b.Query(setdate, enddate);
            //Assert
            Assert.AreEqual(v, 56);
        }

        [TestMethod]
        public void HalfMonthQueryTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 2, 1);
            DateTime startdate = new DateTime(2019, 2, 15);
            DateTime enddate = new DateTime(2019, 2, 28);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 28);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 14);
        }

        [TestMethod]
        public void CrossMonthQueryTest()
        {
            //Arrange
            DateTime setdate = new DateTime(2019, 2, 1);
            DateTime startdate = new DateTime(2019, 2, 15);
            DateTime enddate = new DateTime(2019, 3, 15);
            //Act
            Budget b = new Budget();
            b.Set(setdate, 28);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 14);
        }

        [TestMethod]
        public void MultiMonthQueryTest()
        {
            //Arrange
            DateTime startdate = new DateTime(2019, 2, 28);
            DateTime enddate = new DateTime(2019, 3, 1);
            //Act
            Budget b = new Budget();
            b.Set(new DateTime(2019, 2, 1), 28);
            b.Set(new DateTime(2019, 3, 1), 93);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 4);
        }

        [TestMethod]
        public void GapInMonthQueryTest()
        {
            //Arrange
            DateTime startdate = new DateTime(2019, 4, 30);
            DateTime enddate = new DateTime(2019, 7, 15);
            //Act
            Budget b = new Budget();
            b.Set(new DateTime(2019, 4, 1), 60);
            b.Set(new DateTime(2019, 6, 1), 120);
            int v = b.Query(startdate, enddate);
            //Assert
            Assert.AreEqual(v, 122);
        }
    }
}
