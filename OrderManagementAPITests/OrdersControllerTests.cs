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

        [Fact]
        public void InvalidOrderModel_ReturnsBadRequest()
        {
        // Arrange
        var order = new Order { Id = 0, FirstName = null, LastName = null };
        var controller = new OrdersController(new OrderRepository());

        // Act
        var result = controller.AddOrder(order);

        // Assert
        Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void MissingRequiredFields_ReturnsBadRequest()
        {
        // Arrange
        var order = new Order { Id = 1, FirstName = "", LastName = null };
        var controller = new OrdersController(new OrderRepository());

        // Act
        var result = controller.AddOrder(order);

        // Assert
        Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void InvalidOrderId_ReturnsBadRequest()
        {
        // Arrange
        var order = new Order { Id = -1, FirstName = "John", LastName = "Doe" };
        var controller = new OrdersController(new OrderRepository());

        // Act
        var result = controller.AddOrder(order);

        // Assert
        Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DuplicateOrder_ReturnsConflict()
        {
        // Arrange
        var order = new Order { Id = 1, FirstName = "John", LastName = "Doe" };
        var controller = new OrdersController(new OrderRepository());

        // Act
        var result = controller.AddOrder(order);

        // Assert
        Assert.IsType<ConflictResult>(result);
        }

        [Fact]
        public void UnauthorizedAccess_ReturnsUnauthorized()
        {
        // Arrange
        var order = new Order { Id = 1, FirstName = "John", LastName = "Doe" };
        var controller = new OrdersController(new OrderRepository());

        // Act
        var result = controller.AddOrder(order);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
