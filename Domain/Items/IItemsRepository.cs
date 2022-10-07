using Domain.Interfaces;

namespace Domain.Items
{
    public interface IItemsRepository : IAsyncRepository<Item>
    {
    }
}