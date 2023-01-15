namespace API.Models
{
    public class BasketDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        // public int ProductStock { get; set; }
        public int Quantity { get; set; }
    }
}
