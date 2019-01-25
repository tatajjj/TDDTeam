using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHW;

namespace TDDHWTest
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void AddBudgetTest()
        {
            //Arrange
            //Act
            Budget b = new Budget();
            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}
