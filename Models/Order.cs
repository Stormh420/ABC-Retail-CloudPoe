using System.Collections.Generic;

namespace ABC_Retail_CloudPoe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public List<int>? ProductIds { get; set; } 
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
    }
}

