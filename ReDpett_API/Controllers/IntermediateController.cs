using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using System.Data;
using System.Reflection;

namespace ReDpett_API.Controllers
{
    public class IntermediateController : ControllerBase
    {
        private IDBService _db;
        private string? _guid;
        private readonly REcontext _context;


        public IntermediateController(IDBService dBService, REcontext context)
        {
            _db = dBService;
            _context = context;
        }

        [Route("/Intermediate/Insert")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> PostIntermediate([FromBody] IntermediateResidentData project)
        {
            try
            {
                _guid = Guid.NewGuid().ToString();
                _db.InsertIntermediateResidents(project, _guid);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Intermediate/Update")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> UpdateTransaction([FromBody] IntermediateResidentData project)
        {
            try
            {
                _guid = Guid.NewGuid().ToString();
                _db.UpdateNewIntermediateResidents(project, _guid);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Intermediate/GetProjectStatus")]
        [HttpGet]
        public async Task<List<codeprojectstatus1>> GetProjectStatus()
        {
            DataTable dt = _db.Getcodeprojectstatus1();
            List<codeprojectstatus1> modelList = new List<codeprojectstatus1>();
            foreach (DataRow row in dt.Rows)
            {
                codeprojectstatus1 model = new codeprojectstatus1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codeprojectstatus1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        } 
        [Route("/Intermediate/GetProjStatus")]
        [HttpGet]
        public async Task<List<codeprojectstatus1>> GetProjStatus()
        {
            DataTable dt = _db.Getprojectstatus();
            List<codeprojectstatus1> modelList = new List<codeprojectstatus1>();
            foreach (DataRow row in dt.Rows)
            {
                codeprojectstatus1 model = new codeprojectstatus1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codeprojectstatus1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/Getcodediseaseenglish")]
        [HttpGet]
        public async Task<List<codediseaseenglish>> Getcodediseaseenglish()
        {
            DataTable dt = _db.Getcodediseaseenglish();
            List<codediseaseenglish> modelList = new List<codediseaseenglish>();
            foreach (DataRow row in dt.Rows)
            {
                codediseaseenglish model = new codediseaseenglish();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codediseaseenglish).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/Getcodesetting1")]
        [HttpGet]
        public async Task<List<codesetting1>> Getcodesetting1()
        {
            DataTable dt = _db.Getcodesetting1();
            List<codesetting1> modelList = new List<codesetting1>();
            foreach (DataRow row in dt.Rows)
            {
                codesetting1 model = new codesetting1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codesetting1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/Getcodefieldsites123university_training")]
        [HttpGet]
        public async Task<List<codefieldsites123university_training>> Getcodefieldsites123university_training()
        {
            DataTable dt = _db.getAllTiers();
            List<codefieldsites123university_training> modelList = new List<codefieldsites123university_training>();
            foreach (DataRow row in dt.Rows)
            {
                codefieldsites123university_training model = new codefieldsites123university_training();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codefieldsites123university_training).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/getRegions")]
        [HttpGet]
        public async Task<List<codefieldsites123university_training>> GetRegions()
        {
            DataTable dt = _db.getRegions();
            List<codefieldsites123university_training> modelList = new List<codefieldsites123university_training>();
            foreach (DataRow row in dt.Rows)
            {
                codefieldsites123university_training model = new codefieldsites123university_training();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codefieldsites123university_training).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/getAllTrainings")]
        [HttpGet]
        public async Task<List<codefieldsites123university_training>> getAlltrainings()
        {
            DataTable dt = _db.getAlltrainings();
            List<codefieldsites123university_training> modelList = new List<codefieldsites123university_training>();
            foreach (DataRow row in dt.Rows)
            {
                codefieldsites123university_training model = new codefieldsites123university_training();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codefieldsites123university_training).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/Getcodeexposure1")]
        [HttpGet]
        public async Task<List<codeexposure1>> Getcodeexposure1()
        {
            DataTable dt = _db.Getcodeexposure1();
            List<codeexposure1> modelList = new List<codeexposure1>();
            foreach (DataRow row in dt.Rows)
            {
                codeexposure1 model = new codeexposure1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codeexposure1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/GetcodeType")]
        [HttpGet]
        public async Task<List<codetype2>> GetcodeType()
        {
            DataTable dt = _db.GetCodetype2();
            List<codetype2> modelList = new List<codetype2>();
            foreach (DataRow row in dt.Rows)
            {
                codetype2 model = new codetype2();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codetype2).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/GetToolTips")]
        [HttpGet]
        public async Task<List<ToolTips>> GetToolTips()
        {
            DataTable dt = _db.GetToolTips();
            List<ToolTips> modelList = new List<ToolTips>();
            foreach (DataRow row in dt.Rows)
            {
                ToolTips model = new ToolTips();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(ToolTips).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/UpdateResid")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> UpdateNewIntermediate([FromBody] IntermediateResidentData project)
        {
            try
            {
                _guid = Guid.NewGuid().ToString();
                _db.UpdateNewIntermediateResidents(project, _guid);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Intermediate/Getcodeprojectclassification")]
        [HttpGet]
        public async Task<List<codeprojectclassification1>> Getcodeprojectclassification1()
        {
            DataTable dt = _db.Getcodeprojectclassification1();
            List<codeprojectclassification1> modelList = new List<codeprojectclassification1>();
            foreach (DataRow row in dt.Rows)
            {
                codeprojectclassification1 model = new codeprojectclassification1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codeprojectclassification1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }

        [HttpPost("/Intermediate/GetLeadResidents")]
        public async Task<ActionResult<List<string>>> GetLeadResidents([FromBody] string email)
        {
            var i = await _context.Registers.Where(x => x.Email == email).FirstOrDefaultAsync();
            return await _context.Registers
      .Where(x => x.FETPProgramId == i.FETPProgramId && x.RoleId == 2)
      .Select(x => string.Format("{0}, {1}", x.LastName, x.Name))
      .ToListAsync();           //return await _context.Registers.Where(x => x.CountryId == i.CountryId && x.FETPProgramId == i.FETPProgramId && x.RoleId == 2).Select(x => x.Name).ToListAsync();
        }
        [HttpPost("/Intermediate/GetSuperVisors")]
        public async Task<ActionResult<List<string>>> GetSuperVisors([FromBody] string email)
        {
            var i = await _context.Registers.Where(x => x.Email == email).FirstOrDefaultAsync();
            return await _context.TraineeInformation6
      .Where(x => x.Country == i.Country && x.FETP == i.FETP && x.Supervisor == true)
      .Select(x => string.Format("{0}", x.FullName))
      .ToListAsync();         //return await _context.Registers.Where(x => x.CountryId == i.CountryId && x.FETPProgramId == i.FETPProgramId && x.RoleId == 2).Select(x => x.Name).ToListAsync();
        }
        [HttpPost("/Intermediate/GetMembers")]
        public async Task<ActionResult<List<string>>> GetMembers([FromBody] string email)
        {
            var i = await _context.Registers.Where(x => x.Email == email).FirstOrDefaultAsync();
            return await _context.TraineeInformation6
      .Where(x => x.Country == i.Country && x.FETP == i.FETP && x.Supervisor != true && x.completeFETP == "No")
      .Select(x => string.Format("{0}", x.FullName))
      .ToListAsync();           //return await _context.Registers.Where(x => x.CountryId == i.CountryId && x.FETPProgramId == i.FETPProgramId && x.RoleId == 2).Select(x => x.Name).ToListAsync();
        }  [HttpPost("/Intermediate/GetMentors")]
        public async Task<ActionResult<List<string>>> GetMentors([FromBody] string email)
        {
            var i = await _context.Registers.Where(x => x.Email == email).FirstOrDefaultAsync();
            return await _context.TraineeInformation6
      .Where(x => x.Country == i.Country && x.FETP == i.FETP)
      .Select(x => string.Format("{0}", x.FullName))
      .ToListAsync();           //return await _context.Registers.Where(x => x.CountryId == i.CountryId && x.FETPProgramId == i.FETPProgramId && x.RoleId == 2).Select(x => x.Name).ToListAsync();
        }
        [HttpPost("/Intermediate/GetMentor")]
        public async Task<ActionResult<List<string>>> GetMentor([FromBody] string email)
        {
            var i = await _context.Registers.Where(x => x.Email == email).FirstOrDefaultAsync();
            return await _context.Registers.Where(x => x.FETPProgramId == i.FETPProgramId && x.NonResidentId == 4).Select(x => string.Format("{0}, {1}", x.LastName, x.Name)).ToListAsync();
        }
        [HttpGet("/Intermediate/GetWritingType")]
        public async Task<List<string>> GetCodReqwritingType()
        {
            var data = await _context.codereqwritingtype1.Select(x => x.Commprod).ToListAsync();
            return data;
        }
        [Route("/Intermediate/GetcodeTargetPopulation")]
        [HttpGet]
        public async Task<List<CodeTargetPopulation1>> GetcodeTargetPopulation()
        {
            DataTable dt = _db.GetcodeTargetPopulation();
            List<CodeTargetPopulation1> modelList = new List<CodeTargetPopulation1>();
            foreach (DataRow row in dt.Rows)
            {
                CodeTargetPopulation1 model = new CodeTargetPopulation1();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(CodeTargetPopulation1).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Intermediate/GetCodeCdcRoles")]
        [HttpGet]
        public async Task<List<CodeCdcRole>> GetCodeCdcRoles()
        {
            DataTable dt = _db.GetCodeCdcRoles();
            List<CodeCdcRole> modelList = new List<CodeCdcRole>();
            foreach (DataRow row in dt.Rows)
            {
                CodeCdcRole model = new CodeCdcRole();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(CodeCdcRole).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [HttpGet("/Intermediate/GetOneHealth11")]
        public async Task<List<string>> GetOneHealth11()
        {

            var data = await _context.codeonehealth11.Select(x => x.onehealth1).ToListAsync();
            return data;
        }
        [HttpGet("/Intermediate/GetOneHealth21")]
        public async Task<List<string>> GetOneHealth21()
        {

            var data = await _context.codeonehealth21.Select(x => x.onehealth2).ToListAsync();
            return data;
        }

    }
}
