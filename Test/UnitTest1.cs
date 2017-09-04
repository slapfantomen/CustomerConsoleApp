using System;
using CustomerConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateEmail()
        {
            Assert.IsTrue(Validator.ValidateEmail("ulf@gmail.com"));
        }
        [TestMethod]
        public void ValidateIncorrectEmail()
        {
            Assert.IsFalse(Validator.ValidateEmail("kalle@"));
        }
    }
}
