using FoodieOnline.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoeryController : ControllerBase
    {
       //private readonly Helper helper;
        private readonly ICatagoeryRepository context;
        private readonly IWebHostEnvironment env;
        public CatagoeryController(ICatagoeryRepository context,IWebHostEnvironment env)
        {
            
            this.context = context;
            this.env = env;
        }


        /// <summary>
        /// Get all the products from product table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCatagoery")]
        public async Task<IActionResult> GetCatagoery()
        {
            var data = await context.GetCatagoery();
            if(data.Count > 0)
            {
                return Ok(data);
            }
            return NotFound("No Data Avilable");
        }


        /// <summary>
        /// Get single product on behalf of CatagoeryId 
        /// </summary>
        /// <param name="CatagoeryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCatagoeryById")]
        public async Task<IActionResult> GetCatagoeryById(int CatagoeryId)
        {

            var data = await context.GetCatagoeryById(CatagoeryId);
            if(data!=null)
            {
                return Ok(data);
            }
            return NotFound("No Data Avilable");
        }


        /// <summary>
        /// Create new catagory into Catagoery table
        /// </summary>
        /// <param name="catagoery"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCatagoery")]
        public async Task<IActionResult> AddCatagoery([FromForm] CatagoeryImageUpload Object)
        {
            Helper helper = new Helper(env);
            var ImageUpload = helper.SaveImage(Object.Image,Object.SaveToFolder="CatagoeryImages", Object.ImageName);

            Catagoery catagoery = new Catagoery();
            catagoery.catagoeryName = Object.catagoeryName;
            catagoery.Images = ImageUpload;
            catagoery.Description = Object.Description;
            var data = await context.AddCatagoery(catagoery);
            if(data.Status == "200")
            {
                return Ok(data);
            }
           return BadRequest(data.Message);
        }

        /// <summary>
        /// Update catagory into Catagoery table
        /// </summary>
        /// <param name="catagoery"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCatagoery")]
        public async Task<IActionResult> UpdateCatagoery([FromForm]CatagoeryImageUpload Object)
        {

            Helper helper = new Helper(env);
            var ImageUpload = helper.SaveImage(Object.Image, Object.SaveToFolder = "CatagoeryImages", Object.ImageName);

            Catagoery catagoery = new Catagoery();
            catagoery.catagoeryId = Object.catagoeryId;
            catagoery.catagoeryName = Object.catagoeryName;
            catagoery.Images = ImageUpload;
            catagoery.Description=Object.Description;
            var data = await context.UpdateCatagoery(catagoery);
            if(data.Status=="200")
            {
                return Ok(data);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete catagory from Catagoery table
        /// </summary>
        /// <param name="catagoery"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCatagoery")]
        public async Task<IActionResult> DeleteCatagoery(int CatagoeryId)
        {
            var data = await context.DeleteCatagoery(CatagoeryId);
            return Ok(data.Message);
        }
    }
}
