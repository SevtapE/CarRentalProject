using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilsController : ControllerBase
    {


        [HttpPost("add")]
        public void Add([FromForm]IFormFile formFile)
        {
            string path = @"C:\Users\user\source\repos\CarRental\Business\Images\CarImages\d.jpg";
            FileStream stream = new FileStream(path, FileMode.Create);

            formFile.CopyTo(stream);
            stream.Close();
              
            
        }
    }
}
