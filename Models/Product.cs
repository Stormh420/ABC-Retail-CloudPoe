namespace ABC_Retail_CloudPoe.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } // For storing image URLs or file paths
    }
}

