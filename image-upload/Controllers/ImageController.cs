using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace image.upload
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
       private readonly IDbContext _dbContext = null;

       public ImageController(IDbContext dbContext)
       {
          this._dbContext = dbContext;
       }

        [HttpPost("uploadimage"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    byte[] bytes = memoryStream.ToArray();
                    User user = new User();
                    user.Image=  bytes;
                    await _dbContext.Users.InsertOneAsync(user);
                }

                 var result = new  {message = "Image uploaded successfully!"};
                return Ok(result);   
            }
            catch (Exception ex)
            { 
                return BadRequest();
            }

            return Ok();
        }
    }
}
