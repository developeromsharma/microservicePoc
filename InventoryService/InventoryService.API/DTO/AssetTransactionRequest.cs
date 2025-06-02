namespace InventoryService.API.DTO
{
    public class AssetTransactionRequest
    {
        public int AssetId { get; set; }
        public string UserId { get; set; } = string.Empty;  // For now pass userId explicitly
    }

}
