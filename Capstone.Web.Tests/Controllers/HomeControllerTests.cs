////using Microsoft.VisualStudio.TestTools.UnitTesting;
////using Capstone.Web.Controllers;
////using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using Capstone.Web.DAL;

//namespace Capstone.Web.Controllers.Tests
//{
//    [TestClass()]
//    public class HomeControllerTests
//    {
//        private INationalParkDAL _dal;

//        public HomeControllerTests(INationalParkDAL dal)
//        {
//            _dal = dal;
//        }

//        [TestMethod()]
//        public void HomeController_IndexAction_ReturnIndexView()
//        {

//            //Arrange
//            HomeController controller = new HomeController(_dal);

//            //Act
//            ViewResult result = controller.Index() as ViewResult;

//            //Assert
//            Assert.AreEqual("Index", result.ViewName);
//        }
//    }
//}