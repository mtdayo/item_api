using item_api.Models;
using item_api.Repositories;

namespace item_api.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Item>> GetPagedAsync(int page, int pageSize)
        {
            return await _repository.GetPagedAsync(page, pageSize);
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Item> CreateAsync(Item item)
        {
            return await _repository.CreateAsync(item);
        }

        public async Task<Item?> UpdateAsync(int id, Item item)
        {
            return await _repository.UpdateAsync(id, item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);

        }

        public async Task<List<Item>> SearchAsync(string name)
        {
            return await _repository.SearchAsync(name);
        }
    }
}
