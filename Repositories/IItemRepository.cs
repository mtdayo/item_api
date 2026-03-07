using item_api.Models;

namespace item_api.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<List<Item>> GetPagedAsync(int page, int pageSize);

        Task<Item?> GetByIdAsync(int id);

        Task<Item> CreateAsync(Item item);

        Task<Item?> UpdateAsync(int id, Item item);

        Task<bool> DeleteAsync(int id);

        Task<List<Item>> SearchAsync(string name);
    }
}
