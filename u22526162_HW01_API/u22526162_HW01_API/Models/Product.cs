using System.ComponentModel.DataAnnotations;

namespace u22526162_HW01_API.Models
{
    public class Product
    {
        [Key]

        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public string ProductDescription { get; set; } = string.Empty;

    }
}
