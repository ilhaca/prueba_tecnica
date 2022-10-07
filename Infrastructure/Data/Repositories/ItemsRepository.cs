using Domain.Items;

namespace Infrastructure.Data.Repositories
{
    public class ItemsRepository : RepositoryBase<Item>
        , IItemsRepository
    {
        public ItemsRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}