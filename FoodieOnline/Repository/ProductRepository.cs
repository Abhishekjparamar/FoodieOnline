namespace FoodieOnline.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodieContext context;

        public ProductRepository(FoodieContext context)
        {
            this.context = context;
        }
        public async Task<APIResult> AddProduct(Product product)
        {
            try
            {
                product.UpdatedDate = null;
                var data = await context.Product.AddAsync(product);
                var LastInserted = await context.Product.OrderBy(x => x.ProductId).LastOrDefaultAsync();
                await context.SaveChangesAsync();
                return new APIResult
                {
                    Message = "New Product Added Successfully",
                    Status = "200",
                    Id = "Last Inserted Id Value Is:" + LastInserted.ProductId,
                    CurrentId = "Current Inserted Id Value Is:" + product.ProductId

                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status = "400"
                };
            }
        }

        public async Task<APIResult> DeleteProduct(int producId)
        {
            try
            {
                var product = await context.Product.SingleOrDefaultAsync(x => x.ProductId == producId);
                if (product != null)
                {
                    var data = context.Product.Remove(product);
                    await context.SaveChangesAsync();
                }
                else
                {
                    return new APIResult
                    {
                        Message = "No Data Found For Given Id"
                    };
                }

                return new APIResult
                {
                    Message = "Product Deleted Successfully"
                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status = "400"
                };
            }
        }

        public async Task<ProductViewModel> GetProduct()
        {
            try
            {
                var data = await context.Product.ToListAsync();
               
                if (data == null)
                {
                    return null;
                }
                return new ProductViewModel { Count=data.Count,product=data};
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductViewModel> GetProductByCatagoeryId(int catagoeryId)
        {
            try
            {
                var data = context.Product.Where(x => x.CatagoeryId == catagoeryId).ToListAsync();
                if (data == null)
                {
                    return null;
                }
                return new ProductViewModel { Count=data.Result.Count,product=data.Result};
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            try
            {
                var data = await context.Product.SingleOrDefaultAsync(x => x.ProductId == productId);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<APIResult> UpdateProduct(Product product)
        {
            try
            {
                product.UpdatedDate=DateTime.Now;
                var data = context.Product.Update(product);
                await context.SaveChangesAsync();
                return new APIResult
                {
                    Message = "Product Updated Successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {

                return new APIResult
                {
                    Message = ex.Message,
                    Status = "400"
                };
            }
        }
    }
}
