using InventoryService.Domain.Entities;

namespace InventoryService.Domain.Interfaces
{
	public interface ITransactionRepository
	{
        Task<IEnumerable<AssetTransaction>> GetAllAsync();
        Task<AssetTransaction?> GetByIdAsync(int id);
        Task AddAsync(AssetTransaction transaction);
        Task<IEnumerable<AssetTransaction>> GetByUserIdAsync(string userId);
        Task SaveChangesAsync();
    }
}
