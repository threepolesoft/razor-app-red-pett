using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using System.Data;
using System.Reflection;

namespace ReDpett_API.Controllers
{
    public class ProjectsController : ControllerBase
    {
        private IDBService _db;
        private string? _guid;
        private string? pk_Id;
        private readonly REcontext _context;


        public ProjectsController(IDBService dBService, REcontext context)
        {
            _db = dBService;
            _context = context;
        }

        [Route("/Projects/Insert")]
        [HttpPost]
        public async Task<ActionResult<AppDataService>> PostProjects([FromBody] AppDataService project)
        {
            try
            {
                _guid = Guid.NewGuid().ToString();
                pk_Id = Guid.NewGuid().ToString();
                project.Pk_Id = pk_Id;
                _db.InserTransaction(project, _guid);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/UpdateFull")]
        [HttpPost]
        public async Task<ActionResult<AppDataService>> UpdateProjects([FromBody] AppDataService project)
        {
            try
            {
                _guid = project.GUID;
                _db.UpdateTransaction(project, _guid);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/InsertIntermediateResidents")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> PostIntermediateResidents([FromBody] IntermediateResidentData project)
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
        [Route("/Projects/Update")]
        [HttpPost]
        public async Task<ActionResult<AppDataService>> UpdateTransaction([FromBody] AppDataService project)
        {
            try
            {
                _db.UpdateTransaction(project);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/Delete")]
        [HttpPost]
        public async Task<ActionResult<AppDataService>> DeleteProject([FromBody] AppDataService project)
        {
            try
            {
                _db.DeleteTransaction(project);
                return Ok("Data Deleted..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/DeleteIntermediateResidents")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> DeleteIntermediateResidents([FromBody] IntermediateResidentData project)
        {
            try
            {
                _db.DeleteIntermediateResidents(project);
                return Ok("Data Deleted..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/UpdateIntermediateResidents")]
        [HttpPost]
        public async Task<ActionResult<IntermediateResidentData>> UpdateIntermediateResidents([FromBody] IntermediateResidentData project)
        {
            try
            {
                _db.UpdateIntermediateResidents(project);
                return Ok("Data Updated..");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("/Projects/Get")]
        [HttpGet]
        public async Task<ListAppDataService> getprjects()
        {


            DataTable dt = _db.getprojects();
            ListAppDataService modelList = new ListAppDataService();
            modelList.appDataServices = new List<AppDataService>();
            foreach (DataRow row in dt.Rows)
            {
                AppDataService model = new AppDataService();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(AppDataService).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.appDataServices.Add(model);
            }
            return modelList;



        }
        [Route("/Projects/GetIntermediateResidents")]
        [HttpGet]
        public async Task<ListIntermediateResidentData> GetIntermediateResidents(string country, string leadResident)
        {

            DataTable dt = _db.getintermediateResidents(country, leadResident);
            ListIntermediateResidentData modelList = new ListIntermediateResidentData();
            modelList.intermediateResidents = new List<IntermediateResidentData>();
            foreach (DataRow row in dt.Rows)
            {
                IntermediateResidentData model = new IntermediateResidentData();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(IntermediateResidentData).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.intermediateResidents.Add(model);
            }
            return modelList;



        }
        [Route("/Projects/GetIntermediateResidents2")]
        [HttpGet]
        public async Task<ListIntermediateResidentData> getintermediateResidents2()
        {

            DataTable dt = _db.getintermediateResidents2();
            ListIntermediateResidentData modelList = new ListIntermediateResidentData();
            modelList.intermediateResidents = new List<IntermediateResidentData>();
            foreach (DataRow row in dt.Rows)
            {
                IntermediateResidentData model = new IntermediateResidentData();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(IntermediateResidentData).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.intermediateResidents.Add(model);
            }
            return modelList;



        }
        [Route("/Projects/GetPEPFAR")]
        [HttpGet]
        public async Task<ListIntermediateResidentData> getPEPFAR()
        {

            DataTable dt = _db.getPAPFAR();
            ListIntermediateResidentData modelList = new ListIntermediateResidentData();
            modelList.intermediateResidents = new List<IntermediateResidentData>();
            foreach (DataRow row in dt.Rows)
            {
                IntermediateResidentData model = new IntermediateResidentData();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(IntermediateResidentData).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.intermediateResidents.Add(model);
            }
            return modelList;
        }
        [Route("/Projects/GetGeneralComments")]
        [HttpGet]
        public async Task<List<CommentsTab>> getComments()
        {

            DataTable dt = _db.getGComments();
            List<CommentsTab> modelList = new List<CommentsTab>();
            foreach (DataRow row in dt.Rows)
            {
                CommentsTab model = new CommentsTab();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(CommentsTab).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;



        }
        [Route("/Projects/GetIntermediateResidentsAttachments")]
        [HttpGet]
        public async Task<List<WrittenCommunication>> GetIntermediateResidentsAttachments()
        {

            DataTable dt = _db.getintermediateAttchments();
            List<WrittenCommunication> modelList = new List<WrittenCommunication>();
            foreach (DataRow row in dt.Rows)
            {
                WrittenCommunication model = new WrittenCommunication();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(WrittenCommunication).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;



        }

        [Route("/Projects/GetAttachments")]
        [HttpGet]
        public async Task<List<FileData>> getAttachments()
        {
            DataTable dt = _db.getattachments();
            List<FileData> modelList = new List<FileData>();
            foreach (DataRow row in dt.Rows)
            {
                FileData model = new FileData();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(FileData).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
        [Route("/Projects/GetCodeType")]
        [HttpGet]
        public async Task<List<codetypeclass>> getCodeType()
        {
            return _context.codetypeclass.ToList();
        } 
        [Route("/Projects/getChartData")]
        [HttpGet]
        public async Task<List<chartData>> getChartData()
        {
            DataTable dt = _db.getChartData();
            List<chartData> modelList = new List<chartData>();
            foreach (DataRow row in dt.Rows)
            {
                chartData model = new chartData();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(chartData).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
