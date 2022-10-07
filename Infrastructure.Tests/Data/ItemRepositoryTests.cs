using Domain.Items;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Tests.Data
{
    public class ItemRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] 
        public async Task get_item_by_id_get_same_item()
        {
            var itemExpected = new Item("Illán", "Description Test", new DateTime(2022,10,10));
            itemExpected.Id = 1;
  
            var dbSetMock = new Mock<DbSet<T>>();

            var options = new DbContextOptionsBuilder<EFContext>()
                .UseInMemoryDatabase(databaseName: "BoardGames")
                .Options;

            using (var context = new EFContext(options))
            {
                context.Item.Add(itemExpected);
                context.SaveChanges();
            }

            using (var context = new EFContext(options))
            {
                var unitOfWork = new UnitOfWork(context);
                var repository = unitOfWork.AsyncRepository<Item>();
                var response = await repository.GetAsync(i => i.Id == 1);

                Assert.AreEqual(itemExpected.Name, response.Name);
            }            
        }
    }
}