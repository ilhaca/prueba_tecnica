using Domain.Base;
using System;

namespace Domain.Items
{
    public partial class Item : IAggregateRoot
    {
        private readonly int _expirationTimeInMinutes = 1;
        public Item()
        {
        }

        public Item(string name
            , string description
            , DateTime? expirationDate) : this()
        {
            this.Update(name, description, expirationDate);
        }

        public void Update(string name
            , string description
            , DateTime? expirationDate)
        {

            Name = name;
            Description = description;
            ExpirationDate = expirationDate ?? getExpirationDate(_expirationTimeInMinutes);
        }

        private DateTime getExpirationDate(int Minutes) => DateTime.UtcNow.AddMinutes(Minutes);
    }
}