using API.DTOs.Items;
using API.Services.Inventory;
using Domain.Interfaces;
using Domain.Items;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Test.Services
{
    public class InventoryServviceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task get_error_message_when_expiration_date_Expired()
        {
            var expectedValue = new GetItemResponse() { ErrorMessage = "El producto ha caducado" };
            var repo = new Mock<IAsyncRepository<Item>>();
            repo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Item, bool>>>()))
                .ReturnsAsync(new Item("Illán", "Description test", DateTime.UtcNow.AddMinutes(-1)));
            var repository = new Mock<IUnitOfWork>();
            repository.Setup(u => u.AsyncRepository<Item>()).Returns(repo.Object);

            var service = new InventoryService(repository.Object);
            var response = await service.SearchAsync(new GetItemRequest() { Id = 1 });

            Assert.AreEqual(expectedValue.ErrorMessage, response.ErrorMessage);
        }
        [Test]
        public async Task get_item_when_search_by_id()
        {
            var expectedValue = new GetItemResponse()
            {
                Name = "Illán"
            };
            var repo = new Mock<IAsyncRepository<Item>>();
            repo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Item, bool>>>()))
                .ReturnsAsync(new Item("Illán", "Description test", DateTime.UtcNow.AddMinutes(5)));
            var repository = new Mock<IUnitOfWork>();
            repository.Setup(u => u.AsyncRepository<Item>()).Returns(repo.Object);

            var service = new InventoryService(repository.Object);
            var response = await service.SearchAsync(new GetItemRequest() { Id = 1 });

            Assert.AreEqual(expectedValue.Name, response.Name);
        }
    }
}