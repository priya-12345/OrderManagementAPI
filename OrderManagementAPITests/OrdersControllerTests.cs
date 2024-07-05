using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrderManagementAPI.Controllers;
using OrderManagementAPI.Models;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPITests
{
    [TestFixture]
    public class OrdersControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            // Initialize any necessary objects or variables.
        }

        [Test]
        public void GetOrders_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);

            // Act
            var result = controller.GetAllOrders();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetOrder_ReturnsNotFoundResult_WhenOrderDoesNotExist()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);

            // Act
            var result = controller.GetOrder(0);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddOrder_ReturnsCreatedResult()
        {
            // Arrange
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);
            var order = new Order { FirstName = "John", LastName = "Doe", Description = "Test order", Quantity = 1 };

            // Act
            var result = controller.AddOrder(order);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void DeleteOrder_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IOrderRepository>();
            var controller = new OrdersController(mockRepository.Object);
            var orderId = 1;

            // Act
            var result = controller.DeleteOrder(orderId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
