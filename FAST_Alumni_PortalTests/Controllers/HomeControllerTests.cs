using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAST_Alumni_Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using System.Net;

namespace FAST_Alumni_Portal.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ContactUsTest()
        {
            HomeController hc = new HomeController();
            bool ExpectedResult = true;
            ShimContext.
            ViewResult ActualResult = hc.ContactUs as ViewResult;



            Assert.Fail();
        }

        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}