using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    using InventoryService.API.DTO;
    using InventoryService.Domain.Entities;
    using InventoryService.Domain.Interfaces;
    using InventoryService.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AssetTransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public AssetTransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        //[HttpPost("checkout")]
        //public async Task<IActionResult> Checkout([FromBody] AssetTransactionRequest request)
        //{
        //    var transaction = new AssetTransaction
        //    {
        //        AssetId = request.AssetId,
        //        UserId = request.UserId,
        //        TransactionType = "Checkout",
        //        Timestamp = DateTime.UtcNow
        //    };

        //    await _transactionRepository.AddAsync(transaction);
        //    await _transactionRepository.SaveChangesAsync();

        //    return Ok(new { message = "Asset checked out successfully" });
        //}

        //[HttpPost("return")]
        //public async Task<IActionResult> Return([FromBody] AssetTransactionRequest request)
        //{
        //    var transaction = new AssetTransaction
        //    {
        //        AssetId = request.AssetId,
        //        UserId = request.UserId,
        //        TransactionType = "Return",
        //        Timestamp = DateTime.UtcNow
        //    };

        //    await _transactionRepository.AddAsync(transaction);
        //    await _transactionRepository.SaveChangesAsync();

        //    return Ok(new { message = "Asset returned successfully" });
        //}

        //// Optional: Get all transactions
        //[HttpGet]
        //public async Task<IActionResult> GetAllTransactions()
        //{
        //    var transactions = await _transactionRepository.GetAllAsync();
        //    return Ok(transactions);
        //}
    }

}
