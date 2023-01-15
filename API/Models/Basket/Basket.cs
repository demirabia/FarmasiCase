using System;

namespace API.Models
{
    public class Basket
    {
        public string Id { get; set; } = $"basket:{Guid.NewGuid()}"; // Sepet her oluştuğunda benzersiz bir id oluşturur.
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
