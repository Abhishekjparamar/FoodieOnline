namespace FoodieOnline.Interface
{
    public interface ICatagoeryRepository
    {
        Task<CatagoeryViewModel> GetCatagoery();
        Task<Catagoery> GetCatagoeryById(int CatagoeryId);
        Task<APIResult> AddCatagoery(Catagoery catagoery);
        Task<APIResult> UpdateCatagoery(Catagoery catagoery);
        Task<APIResult> DeleteCatagoery(int CatagoeryId);

    }
}
