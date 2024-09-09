namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key (Auto-generated)
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime EntryDate { get; set; }
        public int StockQuantity { get; set; }
    }
}
