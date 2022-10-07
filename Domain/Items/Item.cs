using Domain.Base;
using System;

namespace Domain.Items
{
    public partial class Item : BaseEntity<short>
    {
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public DateTime ExpirationDate { get; internal set; }
    }
}