namespace InventoryService.Domain.Entities
{
    public class AssetTransaction
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CheckoutDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
    }
}
