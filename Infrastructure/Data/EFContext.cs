using Domain.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public partial class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }
        public virtual DbSet<Item> Item { get; set; }

    }
}