using System.ComponentModel.DataAnnotations.Schema;

namespace FoodieOnline.Model
{
    public class Product: Entity
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("catagoeryId")]
        public int CatagoeryId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string? Images { get; set; }
        public string Ingredients { get; set; }
        public string Weight { get; set; }
        public string Taste { get; set; }
        public string Type { get; set; }
        public string SpecialProductType { get; set; }
        public string ProductBacking { get; set; } 
        public decimal Price { get; set; }
        public int Discount { get; set; } = 0;
        public bool IsSpecial { get; set; }
        public bool IsHotFavorite { get; set; }
        public int Rating { get; set; }

    }

    public class ProductViewModel
    {

        public int Count { get; set; }
        public List<Product> product { get; set; }
    }

    public class ProductImageUpload
    {
        public int ProductId { get; set; }
        public int CatagoeryId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string? Images { get; set; }
        public string Ingredients { get; set; }
        public string Weight { get; set; }
        public string Taste { get; set; }
        public string Type { get; set; }
        public string SpecialProductType { get; set; }
        public string ProductBacking { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; } = 0;
        public bool IsSpecial { get; set; }
        public bool IsHotFavorite { get; set; }
        public int Rating { get; set; }
        public IFormFile Image { get; set; }
        public string? SaveToFolder { get; set; }
        public string ImageName { get; set; }
    }
}
