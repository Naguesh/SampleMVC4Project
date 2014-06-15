using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TimesheetWeb.Controllers;
using TimesheetWeb.Models;

namespace TimesheetWeb.Tests.Controllers
{
    [TestClass]
    public class TimesheetControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            TimesheetController controller = new TimesheetController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Timesheet()
        {
            // Arrange
            IEmployeeTimesheetRepository testRepository = new EmployeeTimesheetTestRepository();
            TimesheetController controller = new TimesheetController(testRepository);
            
            // Act
            JsonResult timesheetJSONData = controller.Timesheet() as JsonResult;

            // Assert
            Assert.IsNotNull(timesheetJSONData.Data, "returns JSON data");
        }
        [TestMethod]
        public void Test_If_Route_Works()
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = null;

            // Act
            var expectedRoute = "{controller}/{action}/{id}";
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();

            routeData = MockUtils.GetRouteDataForUrl("~/Timesheet/Index", routes);
            TimesheetController controller = new TimesheetController();

            // Assert
            Assert.AreEqual(((Route)routeData.Route).Url, expectedRoute);
        }


    }
    public static class MockUtils
    {
        public static RouteData GetRouteDataForUrl(string url, RouteCollection routes)
        {
            var httpContectMock = new Mock<HttpContextBase>();
            httpContectMock.Setup(k => k.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            var routeData = routes.GetRouteData(httpContectMock.Object);

            Assert.IsNotNull(routeData, "Timesheet route found");
            return routeData;
        }
    }
}
