using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAST_Alumni_Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net;
using FAST_Alumni_Portal.Models;
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

        [TestMethod()]
        public void ContactUsTest()
        {
            ContactUsModel c = new ContactUsModel();
            string actualresult = "akshaypate@gmail.com";
            bool b = false;
            if (actualresult.Contains(".com"))
            {
                b = true;
            }
            Assert.AreEqual(b, true);

        }
    }
}