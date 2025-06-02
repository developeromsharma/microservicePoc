using InventoryService.Domain.Entities;

namespace InventoryService.Domain.Interfaces
{
	public interface ITransactionRepository
	{
		Task<IEnumerable<AssetTransaction>> GetByUserIdAsync(int userId);
		Task<AssetTransaction?> GetByIdAsync(int id);
		Task AddAsync(AssetTransaction transaction);
		Task UpdateAsync(AssetTransaction transaction);
	}
}
