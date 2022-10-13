namespace FoodieOnline.Interface
{
    public interface IProductRepository
    {
        Task<ProductViewModel> GetProduct();
        Task<Product> GetProductById(int productId);
        Task<APIResult> AddProduct(Product product);
        Task<APIResult> UpdateProduct(Product product);
        Task<APIResult> DeleteProduct(int productId);
        Task<ProductViewModel> GetProductByCatagoeryId(int catagoeryId);
    }
}
