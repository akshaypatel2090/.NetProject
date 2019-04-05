using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAST_Alumni_Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FAST_Alumni_Portal.Controllers.Tests
{
    [TestClass]
    public class TestsHomeController
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        /*
        [TestMethod()]
        public void AboutUsTest()
        {
            Assert.Fail();
        }
        
        [TestMethod()]
        public void MyAccountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContactUsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContactUsTest1()
        {
            Assert.();
        }*/
    }
}