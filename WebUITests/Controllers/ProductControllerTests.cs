using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domain;
using Domain.Abstract;
using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void ListTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
             new Product {ProductID = 1, Name = "P1"},
             new Product {ProductID = 2, Name = "P2"},
             new Product {ProductID = 3, Name = "P3"},
             new Product {ProductID = 4, Name = "P4"},
             new Product {ProductID = 5, Name = "P5"}
             }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Product> result =
            (IEnumerable<Product>)controller.List(2).Model;

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
           

        }
    }
}