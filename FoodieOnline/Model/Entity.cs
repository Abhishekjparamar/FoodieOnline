namespace FoodieOnline.Model
{
    public class Entity
    {
        public DateTime? CreatedDate { get; set; }= DateTime.Now;
        public DateTime? UpdatedDate { get; set; }=DateTime.Now;
        public bool IsAvailable { get; set; }=true;
    }
}
