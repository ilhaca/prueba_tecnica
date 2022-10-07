using Domain.Items;
using NUnit.Framework;
using System;

namespace Domain.Tests.Items
{
    public class ItemsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void item_maintains_expirationdate_if_have()
        {
            var item = new Item("nombre", "descripción test", new DateTime(2022, 10, 10));
            Assert.True(item.ExpirationDate == new DateTime(2022, 10, 10));
        }
        [Test]
        public void item_generate_expirationdate_if_not_have()
        {
            var item = new Item("nombre", "descripción test", null);
            Assert.True(item.ExpirationDate > DateTime.UtcNow);
        }
    }
}