namespace FoodieOnline.Model
{
    public class Catagoery:Entity
    {
        public int catagoeryId { get; set; }
        public string catagoeryName { get; set; }
        public string? Images { get; set; }
        public string Description { get; set; }
    }
    public class CatagoeryViewModel
    {
        public int Count { get; set; }
        public List<Catagoery> CatagoeryList { get; set; }
    }
    public class CatagoeryImageUpload
    {
        //public Catagoery catagoery { get; set; }
        public int catagoeryId { get; set; }
        public string catagoeryName { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? SaveToFolder { get; set; }
        public string ImageName { get; set; }
    }
}
