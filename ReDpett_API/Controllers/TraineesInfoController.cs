using ReDpett_API.Service;
using Microsoft.AspNetCore.Mvc;
using ReDpett_API.Modal;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;
using System.Drawing;

namespace ReDpett_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesInfoController : ControllerBase
    {
        private readonly REcontext _context;
        private readonly IMapper _mapper;       
        public TraineesInfoController(REcontext context, IMapper _mapper)
        {
            _context = context;
            this._mapper = _mapper;          
        }

        [HttpPost("AddTraineeInfo")]
        public async Task<ActionResult<bool>> AddTraineesInfo(TraineeInformation6 traineeInfoVM)
        {
            if (traineeInfoVM != null)
            {
                _context.TraineeInformation6.Add(traineeInfoVM);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateTraineeInfo(int id, TraineeInformation6 traineeInfo)
        {
            try
            {
                TraineeInformation6 result = _context.TraineeInformation6.First(x => x.RegisterID == id);
                _mapper.Map(traineeInfo, result);
                _context.TraineeInformation6.Update(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet("{id}")]
        public TraineeInformation6 GetTraineeInfo(int id)
        {
            var info = _context.TraineeInformation6.First(x => x.GlobalRecordId == id);
            return info;
        }

        [HttpGet("GetAllTraineeInfo")]
        public List<TraineeInformation6> GetAllTraineeInfo()
        {
            var info = _context.TraineeInformation6.ToList();
            return info;
        }
        
        [HttpGet("GetCodeCurrentProfession")]
        public List<string> GetCodeCurrentProfession()
        {
            var profession = _context.codecurrentprofession1.Select(x=>x.currentprofession).ToList();
            return profession;
        } 
        
        [HttpGet("GetMentors")]
        public List<string> GetMentors()
        {
            var profession = _context.TraineeInformation6.Where(x=>x.Mentor==true).Select(x=>x.FullName).ToList();
            return profession;
        } 
        [HttpGet("GetCodeInstituteAff")]
        public List<string> GetCodeInstituteAff()
        {
            var info = _context.codeinstituteaff1.Select(x=>x.instituteaff).ToList();
            return info;
        }
        [HttpGet("GetOrganizationType")]
        public List<string> GetOrganizationType()
        {
            var info = _context.codeorganizationtype1.Select(x=>x.organizationtype).ToList();
            return info;
        }

        [HttpPost]
        public async Task GetProfilePicUrl([FromBody] TraineeInformation6 data)
        {
            var email = HttpContext.Request.Headers["username"].ToString();
            email = email.Replace("\"", "");
            var registerId = _context.Registers.First(x => x.Email == email.ToString()).RegisterID;
            var imgpath= ConvertAndSaveImage(data.ProfilePicture);
            data.ProfilePicture = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}/{imgpath}";
            var result = await _context.TraineeInformation6.AnyAsync(x => x.RegisterID == registerId);
            if (!result)
            {
                data.RegisterID=registerId;
                _context.TraineeInformation6.Add(data);
                await _context.SaveChangesAsync();
            }
            else
            {
                var traineeInfo = await _context.TraineeInformation6.Where(x => x.RegisterID == registerId).FirstAsync();
                traineeInfo.ProfilePicture = data.ProfilePicture;
                _context.TraineeInformation6.Update(traineeInfo);
                await _context.SaveChangesAsync();
            }          
        }


        [HttpGet]
        public string ConvertAndSaveImage(string base64String)
        {
            try
            {
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                byte[] imageBytes = Convert.FromBase64String(base64String);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    string uniqueFileName = Guid.NewGuid().ToString() + ".png";
                    var fullPath = Path.Combine(pathToSave, uniqueFileName);
                    var dbPath = Path.Combine(folderName, uniqueFileName);                                     
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), uniqueFileName);
                    image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);                                 
                    return dbPath;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProfilePictureUrl/{email}")]
        public async Task<string> GetProfilePictureUrl(string email)
        {
            var registerId = await _context.Registers.FirstOrDefaultAsync(x => x.Email == email);
            if (registerId!= null)
            {
                var traineeInfo = _context.TraineeInformation6.FirstOrDefault(x => x.RegisterID == registerId.RegisterID);
                if (traineeInfo != null && !string.IsNullOrEmpty(traineeInfo.ProfilePicture))
                {
                    return traineeInfo.ProfilePicture;
                }
            }
            return "" ;
        }
    }
}

