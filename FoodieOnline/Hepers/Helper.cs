namespace FoodieOnline.Helpers
{
    public  class Helper
    {
        private readonly IWebHostEnvironment _env;
        public Helper(IWebHostEnvironment env)
        {
            _env = env;
        }


        /// <summary>
        /// Save base64 Image in Images folder under wwwroot
        /// </summary>
        /// <param name="imageModel"></param>
        /// <returns></returns>
        public string SaveImage(IFormFile Base64Image, string SaveToFolder, string ImageName)
        {
            try
            {
                var path = Path.Combine(_env.WebRootPath, SaveToFolder);
                //Check if directory exist
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                var imageName = ImageName + ".jpg";

                //set the image path
                var imgPath = Path.Combine(path, imageName);

                //byte[] imageBytes = Convert.FromBase64String(Base64Image.ToString());

               
                    if (Base64Image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            Base64Image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                           // string s = Convert.ToBase64String(fileBytes);
                        System.IO.File.WriteAllBytes(imgPath, fileBytes);
                        // act on the Base64 data
                    }
                    }
                

                //System.IO.File.WriteAllBytes(imgPath, imageBytes);

                return imageName;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



     
    }
}
