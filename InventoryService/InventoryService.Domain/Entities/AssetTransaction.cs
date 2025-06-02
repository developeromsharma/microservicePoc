namespace InventoryService.Domain.Entities
{
    public class AssetTransaction
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty; // "Checkout" or "Return"
        public DateTime Timestamp { get; set; }

        // Navigation property
        public Asset? Asset { get; set; }
    }
}
