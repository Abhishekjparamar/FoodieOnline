using FoodieOnline.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepository context;
        private readonly IWebHostEnvironment env;

        public ProductController(IProductRepository context,IWebHostEnvironment env)
        {
            this.env = env;
            this.context = context;
        }

        /// <summary>
        /// Get the list of products from product table 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            var data = await context.GetProduct();
            if (data.Count > 0)
            {
                return Ok(data);
            }
            return NotFound("No Data Avilable");
        }


        /// <summary>
        /// Get the single product from product table on behalf of productId 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {

            var data = await context.GetProductById(productId);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("No Data Avilable");
        }


        /// <summary>
        /// Add new product into product table 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductImageUpload Obj)
        {
            Helper helper = new Helper(env);
            var ImageUpload = helper.SaveImage(Obj.Image, Obj.SaveToFolder = "ProductImages", Obj.ImageName);

            Product product = new Product();
            product.ProductId = Obj.ProductId;
            product.CatagoeryId = Obj.CatagoeryId;
            product.ProductName = Obj.ProductName;
            product.ShortDescription = Obj.ShortDescription;
            product.Description = Obj.Description;
            product.Ingredients = Obj.Ingredients;
            product.Weight = Obj.Weight;
            product.Taste = Obj.Taste;
            product.Type = Obj.Type;
            product.SpecialProductType = Obj.SpecialProductType;
            product.ProductBacking = Obj.ProductBacking;
            product.Price = Obj.Price;
            product.Discount = Obj.Discount;
            product.IsSpecial = Obj.IsSpecial;
            product.IsHotFavorite = Obj.IsHotFavorite;
            product.Rating = Obj.Rating;
            product.Images = ImageUpload;

            var data = await context.AddProduct(product);
            if (data.Status == "200")
            {
                return Ok(data);
            }
            return BadRequest();
        }


        /// <summary>
        /// Update  product into product table
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductImageUpload Obj)
        {
            Helper helper = new Helper(env);
            var ImageUpload = helper.SaveImage(Obj.Image, Obj.SaveToFolder = "ProductImages", Obj.ImageName);

            Product product = new Product();
            product.ProductId = Obj.ProductId;
            product.CatagoeryId=Obj.CatagoeryId;
            product.ProductName = Obj.ProductName;
            product.ShortDescription = Obj.ShortDescription;
            product.Description = Obj.Description;
            product.Ingredients=Obj.Ingredients;
            product.Weight=Obj.Weight;
            product.Taste=Obj.Taste;
            product.Type=Obj.Type;
            product.SpecialProductType=Obj.SpecialProductType;
            product.ProductBacking = Obj.ProductBacking;
            product.Price=Obj.Price;
            product.Discount=Obj.Discount;
            product.IsSpecial=Obj.IsSpecial;
            product.IsHotFavorite=Obj.IsHotFavorite;
            product.Rating=Obj.Rating;
            product.Images = ImageUpload;
            var data = await context.UpdateProduct(product);
            if (data.Status == "200")
            {
                return Ok(data);
            }
            return BadRequest();
        }


        /// <summary>
        /// Delete product from product table
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var data = await context.DeleteProduct(productId);
            return Ok(data.Message);
        }

        /// <summary>
        /// Get the single product from product table on behalf of catagoeryId 
        /// </summary>
        /// <param name="catagoeryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductByCatagoeryId")]
        public async Task<IActionResult> GetProductByCatagoeryId(int catagoeryId)
        {

            var data = await context.GetProductByCatagoeryId(catagoeryId);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("No Data Avilable");
        }


    }
}
