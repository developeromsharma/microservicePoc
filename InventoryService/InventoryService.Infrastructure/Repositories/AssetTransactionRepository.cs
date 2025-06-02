using InventoryService.Domain.Entities;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Repositories
{
    public class AssetTransactionRepository : ITransactionRepository
    {
        private readonly InventoryDbContext _context;

        public AssetTransactionRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AssetTransaction transaction)
        {
            await _context.AssetTransactions.AddAsync(transaction);
        }

        public async Task<IEnumerable<AssetTransaction>> GetAllAsync()
        {
            return await _context.AssetTransactions.Include(t => t.Asset).ToListAsync();
        }

        public async Task<AssetTransaction?> GetByIdAsync(int id)
        {
            return await _context.AssetTransactions.Include(t => t.Asset).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<AssetTransaction>> GetByUserIdAsync(string userId)
        {
            return await _context.AssetTransactions
                .Where(t => t.UserId == userId)
                .Include(t => t.Asset)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
