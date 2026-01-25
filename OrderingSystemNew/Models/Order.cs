namespace OrderingSystemNew.Models
{
    public class Order
    {
        public string? Id { get; set; }
        public string CustomerName { get; set; } = default!;
        public decimal Total { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "New";

        public Order()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}