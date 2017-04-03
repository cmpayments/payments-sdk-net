using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CM.Payments.Client.Model;
using CM.Payments.Client.SampleWebApp.Context;
using CM.Payments.Client.SampleWebApp.Controllers;
using CM.Payments.Client.SampleWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CM.Payments.Client.SampleWebApp.Tests
{
    [TestClass]
    public sealed class OrderTest
    {
        [TestMethod]
        public void Add_ExistingProductToCart_IncreasesQuantity()
        {
            var existingItem = new List<OrderItem> {new OrderItem {OrderId = 1, ProductId = 1, AddedOn = DateTime.Now, Quantity = 1}};

            var mockItemSet = this.GetMockDbSet(existingItem.AsQueryable());

            var mockContext = new Mock<SampleAppContext>();
            mockContext.Setup(x => x.OrderItems).Returns(mockItemSet.Object);

            var service = new DataRepository(mockContext.Object);
            var result = service.AddProductToOrder();

            Assert.AreEqual(2, result.Quantity);
        }

        [TestMethod]
        public void Add_ProductToCart()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var mock = new List<OrderItem>();
            var mockItemSet = this.GetMockDbSet(mock.AsQueryable());

            var mockContext = new Mock<SampleAppContext>();
            mockContext.Setup(x => x.OrderItems).Returns(mockItemSet.Object);

            var service = new DataRepository(mockContext.Object);
            service.AddProductToOrder();

            mockItemSet.Verify(m => m.Add(It.IsAny<OrderItem>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Get_AllOrderItems()
        {
            var data =
                new List<OrderItem>
                {
                    new OrderItem {OrderId = 1, ProductId = 1, AddedOn = DateTime.Now, Quantity = 1},
                    new OrderItem {OrderId = 1, ProductId = 2, AddedOn = DateTime.Now, Quantity = 1},
                    new OrderItem {OrderId = 1, ProductId = 3, AddedOn = DateTime.Now, Quantity = 1}
                }.AsQueryable();

            var mockSet = new Mock<DbSet<OrderItem>>();
            mockSet.As<IQueryable<OrderItem>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<OrderItem>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<OrderItem>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<OrderItem>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<SampleAppContext>();
            mockContext.Setup(c => c.OrderItems).Returns(mockSet.Object);

            var service = new DataRepository(mockContext.Object);
            var blogs = service.GetAllItems();

            Assert.AreEqual(3, blogs.Count);
        }

        [TestMethod]
        public async Task Pay_OrderWithIdeal()
        {
            var controller = new CheckoutController();
            var charge = new ChargeRequest
            {
                Amount = 70.0,
                Currency = "EUR",
                Payments =
                    new List<PaymentRequest>
                    {
                        new IdealPaymentRequest
                        {
                            Amount = 70.0,
                            Currency = "EUR",
                            Details =
                                new IdealDetailsRequest
                                {
                                    IssuerId = "RABONL2U",
                                    SuccessUrl = "",
                                    FailedUrl = "",
                                    CancelledUrl = "",
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N"),
                                    Description = "Test description."
                                }
                        }
                    }
            };
            var response = await controller.ProceedPaymentAsync(charge);
            Assert.AreEqual(70m, response.Amount);
            Assert.AreEqual("Open", response.Status);
        }

        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }
    }
}