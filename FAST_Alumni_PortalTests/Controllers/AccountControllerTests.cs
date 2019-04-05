using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAST_Alumni_Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using System.Fakes;

namespace FAST_Alumni_Portal.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void SignOutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveLinkedinUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MyAccountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void studentloginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowdataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveLinkedinDataTest()
        {
            AccountController ac = new AccountController();
            

            bool ActualResult;

            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2014, 01, 01);
                var autualdate = DateTime.Now;

            }

            
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}