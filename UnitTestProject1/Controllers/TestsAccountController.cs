using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAST_Alumni_Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.MVC;
namespace FAST_Alumni_Portal.Controllers.Tests
{
    [TestClass()]
    public class TestsAccountController
    {
        [TestMethod()]
        public void CreateTest()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}