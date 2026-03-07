using Microsoft.EntityFrameworkCore;
using item_api.Models;
using item_api.Data;

namespace item_api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Item>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Items
                .Where(x => !x.IsDeleted)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<Item> CreateAsync(Item item)
        {
            _context.Items.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item?> UpdateAsync(int id, Item updatedItem)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null) return null;

            item.Name = updatedItem.Name;

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null) return false;

            item.IsDeleted = true;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Item>> SearchAsync(string name)
        {
            return await _context.Items
                .Where(x => !x.IsDeleted && x.Name.Contains(name))
                .ToListAsync();
        }
    }
}
