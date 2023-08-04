using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReDpett.Common.Modal;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReDpett_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilePictureController : ControllerBase
    {

        private readonly IWebHostEnvironment env;

        private readonly REcontext _context;

        public ProfilePictureController(REcontext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }


        // GET: api/<ProfilePictureController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProfilePictureController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var buf = Convert.FromBase64String(id);
             System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + "m.png", buf);

            return "value";
        }

        // POST api/<ProfilePictureController>
        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile([FromForm] IEnumerable<IFormFile> files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();

            foreach (IFormFile file in files)
            {
                string email = file.FileName.ToString().Split("*")[1];

                var uploadResult = new UploadResult();

                var trustedFileNameFordisplay = WebUtility.HtmlEncode(file.FileName);

                string trustedFileNameForFileStorage = Path.GetRandomFileName();

                string nf = Guid.NewGuid().ToString();

                string root = Path.Combine(env.ContentRootPath, "StaticFiles", "Images");

                nf += file.ContentType == "image/jpeg" ? ".jpeg" : ".png";

                root += "/"+nf;

                await using FileStream fileStream = new(root, FileMode.Create);

                await file.CopyToAsync(fileStream);

                uploadResult.StoredFileName = "StaticFiles/Images/" + nf;
                uploadResults.Add(uploadResult);

                var registerId = await _context.Registers.FirstOrDefaultAsync(x => x.Email == email);
                if (registerId != null)
                {
                    TraineeInformation6 traineeInfo = _context.TraineeInformation6.FirstOrDefault(x => x.RegisterID == registerId.RegisterID);

                    if (traineeInfo != null)
                    {
                        traineeInfo.ProfilePicture = uploadResult.StoredFileName;
                        _context.SaveChanges();
                    }
                }

                uploadResult.StoredFileName = "data:image/jpeg;base64,"+Convert.ToBase64String(System.IO.File.ReadAllBytes(root));

            }

            return Ok(uploadResults);
        }

        // PUT api/<ProfilePictureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfilePictureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
