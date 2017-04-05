using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.HtmlHelpers.Tests
{
    [TestClass()]
    public class PagingHelpersTests
    {
        [TestMethod()]
        public void PageLinksTest()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
           // Func<int, string> pageUrlDelegate = i => "Page" + i;
            string canuse (int value)
            {
                return "Page" + value;
            }

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, canuse);
            // Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
            + @"<a class=""selected"" href=""Page2"">2</a>"
            + @"<a href=""Page3"">3</a>");
        }
    }
}