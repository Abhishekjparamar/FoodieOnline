using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http.Headers;

namespace FoodieOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Property
        private readonly IAccountRepository Repo;
        private readonly IWebHostEnvironment env;
        #endregion

        #region Const
        public AccountController(IAccountRepository Repo,IWebHostEnvironment env)
        {
            this.Repo = Repo;
            this.env = env;

        }
        #endregion


        #region Method

       

        /// <summary>
        /// check the user is valid or not on behalf of Email and Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var data=Repo.Login(model);
            if(data.Result.StatusCode==200)
            {
                return Ok(data.Result);
            }
            else
            {
                return Ok(data.Result);
            }
              
        }

        /// <summary>
        /// Craete new user 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel  model)
        {
            var data = await Repo.Register(model);
            if(data.StatusCode==200)
            {
                return Ok(data);
            }
            else
            { 
                return Ok(data);
            }
           
        }
        #endregion


    }
}
