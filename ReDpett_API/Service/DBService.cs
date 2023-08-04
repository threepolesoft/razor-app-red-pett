using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReDpett_API.Modal;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Xml.Linq;

namespace ReDpett_API.Service
{
    public class DBService : IDBService
    {
        public string Role;
        public int userId;
        private Login login;
        private static IConfiguration Configuration;

        //string IDBService.Role { get; set; }

        public DBService(IConfiguration configuration)
        {
            Configuration = configuration;
            login = new Login();
        }

        public void InserTransaction(AppDataService _data, string _guid)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                //    "Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                //using (SqlConnection conn = new SqlConnection("Server=DESKTOP-N8T9AT4;Initial Catalog==TrackingMasterOLD;Persist Security Info=False;" +
                //   "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpInsertProjectRecord", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _guid));
                        cmd.Parameters.Add(new SqlParameter("@Pk_Id", _data.Pk_Id));
                        cmd.Parameters.Add(new SqlParameter("@RALevel", true));
                        cmd.Parameters.Add(new SqlParameter("@FETPFrontline", _data.FETP == null ? DBNull.Value : _data.FETP));
                        cmd.Parameters.Add(new SqlParameter("@RPFL1_CohortNumber", _data.CohortNumber));//_data.CohortNumber == null ? DBNull.Value : _data.CohortNumber));
                        cmd.Parameters.Add(new SqlParameter("@RPFL2_CohortStart", _data.CohortStartDate == null ? DBNull.Value : Convert.ToDateTime(_data.CohortStartDate)));
                        cmd.Parameters.Add(new SqlParameter("@RPFL3_CohortEnd", _data.CohortEndDate == null ? DBNull.Value : Convert.ToDateTime(_data.CohortEndDate)));
                        cmd.Parameters.Add(new SqlParameter("@RPFL4_RosterNumber", DBNull.Value));//0));
                        cmd.Parameters.Add(new SqlParameter("@RPFL5_NameLast", _data.Sur_LastName == null ? DBNull.Value : _data.Sur_LastName));
                        cmd.Parameters.Add(new SqlParameter("@RPFL6_NameFirst", _data.Given_FirstName == null ? DBNull.Value : _data.Given_FirstName));
                        cmd.Parameters.Add(new SqlParameter("@RPFL7_FullName", _data.ResidentName == null ? DBNull.Value : _data.ResidentName));
                        //cmd.Parameters["RPFL7_FullName"].Value = _data.ResidentName == null ? DBNull.Value : _data.ResidentName;
                        cmd.Parameters.Add(new SqlParameter("@RPFL8_Sex", _data.Sex == null ? DBNull.Value : _data.Sex));
                        // cmd.Parameters["RPFL8_Sex"].Value = _data.Sex == null ? DBNull.Value : _data.Sex;
                        cmd.Parameters.Add(new SqlParameter("@RPFL_DateofBirth", _data.DOB == null ? DBNull.Value : Convert.ToDateTime(_data.DOB)));
                        // cmd.Parameters["RPFL_DateofBirth"].Value = _data.DOB == null ? DBNull.Value : Convert.ToDateTime(_data.DOB);
                        cmd.Parameters.Add(new SqlParameter("@RPFL9_Age", _data.Age < 0 ? DBNull.Value : _data.Age));
                        //cmd.Parameters["RPFL9_Age"].Value = _data.Age < 0 ? DBNull.Value : _data.Age;
                        cmd.Parameters.Add(new SqlParameter("@RPFL10_Email", _data.Email == null ? DBNull.Value : _data.Email));
                        //cmd.Parameters["RPFL10_Email"].Value = _data.Email == null ? DBNull.Value : _data.Email;

                        cmd.Parameters.Add(new SqlParameter("@RPFL12_Employer", _data.Employer == null ? DBNull.Value : _data.Employer));
                        // cmd.Parameters["RPFL12_Employer"].Value = _data.Employer == null ? DBNull.Value : _data.Employer;

                        cmd.Parameters.Add(new SqlParameter("@RPFL11_ProBckgrd", _data.Professional_Background == null ? DBNull.Value : _data.Professional_Background));
                        // cmd.Parameters["RPFL11_ProBckgrd"].Value = _data.Professional_Background == null ? DBNull.Value : _data.Professional_Background;

                        cmd.Parameters.Add(new SqlParameter("@RPFL11b_Other", DBNull.Value));
                        ///cmd.Parameters["RPFL11b_Other"].Value = DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@RPFL14_YearJob", _data.YearsOnJob < 0 ? DBNull.Value : _data.YearsOnJob));
                        //cmd.Parameters["RPFL14_YearJob"].Value = _data.YearsOnJob < 0 ? DBNull.Value : _data.YearsOnJob;

                        cmd.Parameters.Add(new SqlParameter("@RPFL13_JobTitle", _data.JobTitle == null ? DBNull.Value : _data.JobTitle));
                        // cmd.Parameters["RPFL13_JobTitle"].Value = _data.JobTitle == null ? DBNull.Value : _data.JobTitle;

                        cmd.Parameters.Add(new SqlParameter("@RPFL16_SupervisorName", _data.SupervisorName == null ? DBNull.Value : _data.SupervisorName));
                        // cmd.Parameters["RPFL16_SupervisorName"].Value = _data.SupervisorName == null ? DBNull.Value : _data.SupervisorName;
                        cmd.Parameters.Add(new SqlParameter("@RPFL20_Latitude", DBNull.Value));//_data.RPFL20_Latitude == null ? DBNull.Value : _data.RPFL20_Latitude));
                                                                                               //cmd.Parameters["RPFL20_Latitude"].Value = _data.RPFL20_Latitude == null ? DBNull.Value : _data.RPFL20_Latitude;

                        cmd.Parameters.Add(new SqlParameter("@RPFL21_Location", DBNull.Value));
                        // cmd.Parameters["RPFL21_Location"].Value = DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@RPFL19_Longitude", DBNull.Value));//_data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude));
                        ///cmd.Parameters["RPFL19_Longitude"].Value = _data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude;

                        cmd.Parameters.Add(new SqlParameter("@RPFL17_District", _data.City == null ? DBNull.Value : _data.City));
                        // cmd.Parameters["RPFL17_District"].Value = _data.City == null ? DBNull.Value : _data.City;

                        cmd.Parameters.Add(new SqlParameter("@RPFL18_Region", _data.Country == null ? DBNull.Value : _data.Country));
                        // cmd.Parameters["RPFL18_Region"].Value = _data.Country == null ? DBNull.Value : _data.Country;

                        cmd.Parameters.Add(new SqlParameter("@RPFL22_FacilityName", _data.FacilityName == null ? DBNull.Value : _data.FacilityName));
                        //  cmd.Parameters["RPFL22_FacilityName"].Value = _data.FacilityName == null ? DBNull.Value : _data.FacilityName;

                        cmd.Parameters.Add(new SqlParameter("@RPFL23a_LevelFacility", _data.FacilityLevel == null ? DBNull.Value : _data.FacilityLevel));
                        // cmd.Parameters["RPFL23a_LevelFacility"].Value = _data.FacilityLevel == null ? DBNull.Value : _data.FacilityLevel;

                        cmd.Parameters.Add(new SqlParameter("@RPFL23b_Other", DBNull.Value));
                        //cmd.Parameters["RPFL23b_Other"].Value = DBNull.Value;

                        cmd.Parameters.Add(new SqlParameter("@RPFL15_SiteName", DBNull.Value));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                foreach (FileData data in _data.File_Att_Info)
                {
                    //using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                    //"Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    //using (SqlConnection conn = new SqlConnection("Server=DESKTOP-N8T9AT4;Initial Catalog==TrackingMasterOLD;Persist Security Info=False;" +
                    //"MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                    using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SpInsertAttachmentRecord", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // using (SqlCommand cmd = new SqlCommand("SpInsertAttachmentRecord"))
                        //{
                        //cmd.Connection = conn;
                        //cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@record_id", _guid));

                        cmd.Parameters.Add(new SqlParameter("@project_id", _data.Pk_Id));


                        cmd.Parameters.Add(new SqlParameter("@file", data.File_Att));
                        //cmd.Parameters["@file"].Value = data.File_Att;

                        cmd.Parameters.Add(new SqlParameter("@FileName", data.Att_FileName));
                        //cmd.Parameters["@FileName"].Value = data.Att_FileName;

                        cmd.Parameters.Add(new SqlParameter("@fileContentType", data.ContentType));
                        //cmd.Parameters["@fileContentType"].Value = data.ContentType;

                        cmd.Parameters.Add(new SqlParameter("@fileSize", data.FileSize));
                        //cmd.Parameters["@fileSize"].Value = data.FileSize;

                        cmd.Parameters.Add(new SqlParameter("@reportTitle", data.Report_Title));
                        //cmd.Parameters["@reportTitle"].Value = data.Report_Title;

                        cmd.Parameters.Add(new SqlParameter("@reportCategory ", data.TypeOfReport));
                        //cmd.Parameters["@reportCategory "].Value = data.TypeOfReport;

                        //conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void UpdateTransaction(AppDataService _data, string _guid)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpUpdateProjectRecord", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@RALevel", true));
                        cmd.Parameters.Add(new SqlParameter("@FETPFrontline", _data.FETP == null ? DBNull.Value : _data.FETP));
                        cmd.Parameters.Add(new SqlParameter("@RPFL1_CohortNumber", _data.CohortNumber));//_data.CohortNumber == null ? DBNull.Value : _data.CohortNumber));
                        cmd.Parameters.Add(new SqlParameter("@RPFL2_CohortStart", _data.CohortStartDate == null ? DBNull.Value : Convert.ToDateTime(_data.CohortStartDate)));
                        cmd.Parameters.Add(new SqlParameter("@RPFL3_CohortEnd", _data.CohortEndDate == null ? DBNull.Value : Convert.ToDateTime(_data.CohortEndDate)));
                        cmd.Parameters.Add(new SqlParameter("@RPFL4_RosterNumber", DBNull.Value));//0));
                        cmd.Parameters.Add(new SqlParameter("@RPFL5_NameLast", _data.Sur_LastName == null ? DBNull.Value : _data.Sur_LastName));
                        cmd.Parameters.Add(new SqlParameter("@RPFL6_NameFirst", _data.Given_FirstName == null ? DBNull.Value : _data.Given_FirstName));
                        cmd.Parameters.Add(new SqlParameter("@RPFL7_FullName", _data.ResidentName == null ? DBNull.Value : _data.ResidentName));
                        //cmd.Parameters["RPFL7_FullName"].Value = _data.ResidentName == null ? DBNull.Value : _data.ResidentName;
                        cmd.Parameters.Add(new SqlParameter("@RPFL8_Sex", _data.Sex == null ? DBNull.Value : _data.Sex));
                        // cmd.Parameters["RPFL8_Sex"].Value = _data.Sex == null ? DBNull.Value : _data.Sex;
                        cmd.Parameters.Add(new SqlParameter("@RPFL_DateofBirth", _data.DOB == null ? DBNull.Value : Convert.ToDateTime(_data.DOB)));
                        // cmd.Parameters["RPFL_DateofBirth"].Value = _data.DOB == null ? DBNull.Value : Convert.ToDateTime(_data.DOB);
                        cmd.Parameters.Add(new SqlParameter("@RPFL9_Age", _data.Age < 0 ? DBNull.Value : _data.Age));
                        //cmd.Parameters["RPFL9_Age"].Value = _data.Age < 0 ? DBNull.Value : _data.Age;
                        cmd.Parameters.Add(new SqlParameter("@RPFL10_Email", _data.Email == null ? DBNull.Value : _data.Email));
                        //cmd.Parameters["RPFL10_Email"].Value = _data.Email == null ? DBNull.Value : _data.Email;

                        cmd.Parameters.Add(new SqlParameter("@RPFL12_Employer", _data.Employer == null ? DBNull.Value : _data.Employer));
                        // cmd.Parameters["RPFL12_Employer"].Value = _data.Employer == null ? DBNull.Value : _data.Employer;

                        cmd.Parameters.Add(new SqlParameter("@RPFL11_ProBckgrd", _data.Professional_Background == null ? DBNull.Value : _data.Professional_Background));
                        // cmd.Parameters["RPFL11_ProBckgrd"].Value = _data.Professional_Background == null ? DBNull.Value : _data.Professional_Background;

                        cmd.Parameters.Add(new SqlParameter("@RPFL11b_Other", DBNull.Value));
                        ///cmd.Parameters["RPFL11b_Other"].Value = DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@RPFL14_YearJob", _data.YearsOnJob < 0 ? DBNull.Value : _data.YearsOnJob));
                        //cmd.Parameters["RPFL14_YearJob"].Value = _data.YearsOnJob < 0 ? DBNull.Value : _data.YearsOnJob;

                        cmd.Parameters.Add(new SqlParameter("@RPFL13_JobTitle", _data.JobTitle == null ? DBNull.Value : _data.JobTitle));
                        // cmd.Parameters["RPFL13_JobTitle"].Value = _data.JobTitle == null ? DBNull.Value : _data.JobTitle;

                        cmd.Parameters.Add(new SqlParameter("@RPFL16_SupervisorName", _data.SupervisorName == null ? DBNull.Value : _data.SupervisorName));
                        // cmd.Parameters["RPFL16_SupervisorName"].Value = _data.SupervisorName == null ? DBNull.Value : _data.SupervisorName;
                        cmd.Parameters.Add(new SqlParameter("@RPFL20_Latitude", DBNull.Value));//_data.RPFL20_Latitude == null ? DBNull.Value : _data.RPFL20_Latitude));
                                                                                               //cmd.Parameters["RPFL20_Latitude"].Value = _data.RPFL20_Latitude == null ? DBNull.Value : _data.RPFL20_Latitude;

                        cmd.Parameters.Add(new SqlParameter("@RPFL21_Location", DBNull.Value));
                        // cmd.Parameters["RPFL21_Location"].Value = DBNull.Value;
                        cmd.Parameters.Add(new SqlParameter("@RPFL19_Longitude", DBNull.Value));//_data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude));
                        ///cmd.Parameters["RPFL19_Longitude"].Value = _data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude;

                        cmd.Parameters.Add(new SqlParameter("@RPFL17_District", _data.City == null ? DBNull.Value : _data.City));
                        // cmd.Parameters["RPFL17_District"].Value = _data.City == null ? DBNull.Value : _data.City;

                        cmd.Parameters.Add(new SqlParameter("@RPFL18_Region", _data.Country == null ? DBNull.Value : _data.Country));
                        // cmd.Parameters["RPFL18_Region"].Value = _data.Country == null ? DBNull.Value : _data.Country;

                        cmd.Parameters.Add(new SqlParameter("@RPFL22_FacilityName", _data.FacilityName == null ? DBNull.Value : _data.FacilityName));
                        //  cmd.Parameters["RPFL22_FacilityName"].Value = _data.FacilityName == null ? DBNull.Value : _data.FacilityName;

                        cmd.Parameters.Add(new SqlParameter("@RPFL23a_LevelFacility", _data.FacilityLevel == null ? DBNull.Value : _data.FacilityLevel));
                        // cmd.Parameters["RPFL23a_LevelFacility"].Value = _data.FacilityLevel == null ? DBNull.Value : _data.FacilityLevel;

                        cmd.Parameters.Add(new SqlParameter("@RPFL23b_Other", DBNull.Value));
                        //cmd.Parameters["RPFL23b_Other"].Value = DBNull.Value;

                        cmd.Parameters.Add(new SqlParameter("@RPFL15_SiteName", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Pk_Id", _data.Pk_Id));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("deleteattachmentsFrontline", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Pk_Id", _data.Pk_Id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                foreach (FileData data in _data.File_Att_Info)
                {
                    using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SpInsertAttachmentRecord", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@record_id", _guid));
                        cmd.Parameters.Add(new SqlParameter("@project_id", _data.Pk_Id));
                        cmd.Parameters.Add(new SqlParameter("@file", data.File_Att));
                        cmd.Parameters.Add(new SqlParameter("@FileName", data.Att_FileName));
                        cmd.Parameters.Add(new SqlParameter("@fileContentType", data.ContentType));
                        cmd.Parameters.Add(new SqlParameter("@fileSize", data.FileSize));
                        cmd.Parameters.Add(new SqlParameter("@reportTitle", data.Report_Title));
                        cmd.Parameters.Add(new SqlParameter("@reportCategory ", data.TypeOfReport));
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public DataTable GetLoginDetails(String email)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DB")))
            using (SqlCommand cmd = new SqlCommand("sp_get_user", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 255));
                adapter.SelectCommand.Parameters["@email"].Value = email;

                adapter.Fill(dt);
            }

            return dt;
        }

        public bool CreateUser(Register register)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DB")))
                using (SqlCommand cmd = new SqlCommand("sp_insert_user"))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 255));
                    cmd.Parameters["@id"].Value = register.RegisterID;

                    cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 255));
                    cmd.Parameters["@username"].Value = register.Name;

                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 255));
                    cmd.Parameters["@email"].Value = register.Email;

                    cmd.Parameters.Add(new SqlParameter("@usertype", SqlDbType.VarChar, 255));
                    cmd.Parameters["@usertype"].Value = register.RoleId;

                    cmd.Parameters.Add(new SqlParameter("@fetptype", SqlDbType.VarChar, 255));
                    cmd.Parameters["@fetptype"].Value = register.FETPProgramId;

                    cmd.Parameters.Add(new SqlParameter("@userpasswd", SqlDbType.VarChar, 255));
                    cmd.Parameters["@userpasswd"].Value = register.Password;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ReadDataTable(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];
                login.Email = dataRow.ItemArray[4].ToString().Trim();
                login.Password = dataRow.ItemArray[5].ToString().Trim();
                Role = dataRow.ItemArray[2].ToString().Trim();
                //userId =dataRow.ItemArray[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCredentials(Login loginfromuser)
        {

            if (ReadDataTable(GetLoginDetails(loginfromuser.Email)))
            {
                if (loginfromuser.Email.Equals(login.Email) && loginfromuser.Password.Equals(login.Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUser(string email)
        {

            if (ReadDataTable(GetLoginDetails(email)))
            {
                if (String.IsNullOrEmpty(login.Email))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public int GetUserId(string email)
        {

            if (ReadDataTable(GetLoginDetails(email)))
            {
                if (String.IsNullOrEmpty(login.Email))
                {
                    return 0;
                }
                else
                {
                    return userId;
                }
            }

            else
            {
                return 0;
            }
        }
        public DataTable getprojects()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getprojects", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getChartData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getChartData", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getintermediateResidents(string country, string LeadResident)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getIntermediateResidents", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@country", country));
                cmd.Parameters.Add(new SqlParameter("@LeadResident", LeadResident));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getintermediateResidents2()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getIntermediateResidents2", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getPAPFAR()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getPEPFARFunded", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getGComments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getGeneralComments", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getintermediateAttchments()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                using (SqlCommand cmd = new SqlCommand("getAttachmentProjects", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public DataTable getattachments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getattachments", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable Getcodeprojectstatus1()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetCodeprojectstatus1", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable Getprojectstatus()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetProjStatus", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable GetCodetype2()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("Getcodetype2", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable GetcodeTargetPopulation()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetcodeTargetPopulation", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable GetCodeCdcRoles()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetcodeCDCRole", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable Getcodesetting1()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("Getcodesetting1", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getAllTiers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getAllTiers", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable getRegions()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getAllRegions", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable getAlltrainings()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("getAllTrainings", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable Getcodeexposure1()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("Getcodeexposure1", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable Getcodeprojectclassification1()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("Getcodeprojectclassification1", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable Getcodediseaseenglish()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("Getcodediseaseenglish", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable GetToolTips()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetToolTips", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public DataTable GetCountries()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
            using (SqlCommand cmd = new SqlCommand("GetcodeCountryPicklist", conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;

        }
        public void UpdateTransaction(AppDataService _data)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GUID));
                        cmd.Parameters.Add(new SqlParameter("@RPFL6_NameFirst", _data.Given_FirstName == null ? DBNull.Value : _data.Given_FirstName));
                        cmd.Parameters.Add(new SqlParameter("@RPFL8_Sex", _data.Sex == null ? DBNull.Value : _data.Sex));
                        cmd.Parameters.Add(new SqlParameter("@RPFL12_Employer", _data.ResidentName == null ? DBNull.Value : _data.ResidentName));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void DeleteTransaction(AppDataService _data)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("deleteProject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GUID));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void DeleteIntermediateResidents(IntermediateResidentData _data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("deleteIntermediateResident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void UpdateIntermediateResidents(IntermediateResidentData _data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateIntermediateResident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                        cmd.Parameters.Add(new SqlParameter("@LeadResident", _data.LeadResident == null ? DBNull.Value : _data.LeadResident));
                        cmd.Parameters.Add(new SqlParameter("@projecttitle", _data.projecttitle == null ? DBNull.Value : _data.projecttitle));
                        cmd.Parameters.Add(new SqlParameter("@DateAssigned", _data.DateAssigned == null ? DBNull.Value : _data.DateAssigned));
                        cmd.Parameters.Add(new SqlParameter("@classification", _data.ProjectClassification == null ? DBNull.Value : _data.ProjectClassification));
                        cmd.Parameters.Add(new SqlParameter("@FETP", _data.FETP == null ? DBNull.Value : _data.FETP));
                        cmd.Parameters.Add(new SqlParameter("@Type", _data.Type == null ? DBNull.Value : _data.Type));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void InsertIntermediateResidents(IntermediateResidentData _data, string _guid)
        {
            try
            {
                if (_data.Outbreakdetection == "" || _data.Outbreakdetection == null)
                {
                    _data.Outbreakdetection = DateTime.Now.ToShortDateString();
                }
                if (_data.Outbreakstart == "" || _data.Outbreakstart == null)
                {
                    _data.Outbreakstart = DateTime.Now.ToShortDateString();
                }
                if (_data.DateOutbreakEnd == "" || _data.DateOutbreakEnd == null)
                {
                    _data.DateOutbreakEnd = DateTime.Now.ToShortDateString();
                }
                //using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                //    "Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                //using (SqlConnection conn = new SqlConnection("Server=DESKTOP-N8T9AT4;Initial Catalog==TrackingMasterOLD;Persist Security Info=False;" +
                //   "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpInsertIntermediateResident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _guid));
                        cmd.Parameters.Add(new SqlParameter("@FETP", _data.FETP == null ? DBNull.Value : _data.FETP));
                        cmd.Parameters.Add(new SqlParameter("@Intermediate", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Type", _data.Type == null ? DBNull.Value : _data.Type));
                        cmd.Parameters.Add(new SqlParameter("@ProjectClassification", _data.ProjectClassification));//_data.CohortNumber == null ? DBNull.Value : _data.CohortNumber));
                        cmd.Parameters.Add(new SqlParameter("@DateAssigned", _data.DateAssigned == null ? DBNull.Value : Convert.ToDateTime(_data.DateAssigned).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@LeadResident", _data.LeadResident == null ? DBNull.Value : _data.LeadResident));
                        cmd.Parameters.Add(new SqlParameter("@MentorFullName", _data.MentorFullName == null ? DBNull.Value : _data.MentorFullName));
                        cmd.Parameters.Add(new SqlParameter("@SupervisorFullName", _data.SupervisorFullName == null ? DBNull.Value : _data.SupervisorFullName));
                        cmd.Parameters.Add(new SqlParameter("@projecttitle", _data.projecttitle == null ? DBNull.Value : _data.projecttitle));//0));
                        cmd.Parameters.Add(new SqlParameter("@SenstiveData", _data.SenstiveData));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate1", _data.ValidityDate1 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate1)));
                        cmd.Parameters.Add(new SqlParameter("@Outbreakdetection", _data.Outbreakdetection == null ? DBNull.Value : Convert.ToDateTime(_data.Outbreakdetection).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@Outbreakstart", _data.Outbreakstart == null ? DBNull.Value : Convert.ToDateTime(_data.Outbreakstart).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate2", _data.ValidityDate2 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate2)));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate3", _data.ValidityDate3 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate3)));
                        cmd.Parameters.Add(new SqlParameter("@DateOutbreakEnd", _data.DateOutbreakEnd == null ? DBNull.Value : Convert.ToDateTime(_data.DateOutbreakEnd).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@Setting", _data.Setting == null ? DBNull.Value : _data.Setting));
                        cmd.Parameters.Add(new SqlParameter("@SettingOther", _data.SettingOther == null ? DBNull.Value : _data.SettingOther));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseSuspected", _data.DiseaseSuspected == null ? DBNull.Value : _data.DiseaseSuspected));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseSuspected1", _data.DiseaseSuspected1 == null ? DBNull.Value : _data.DiseaseSuspected1));
                        cmd.Parameters.Add(new SqlParameter("@InitialCases", _data.InitialCases == null ? DBNull.Value : _data.InitialCases));
                        cmd.Parameters.Add(new SqlParameter("@Country", _data.Country == null ? DBNull.Value : _data.Country));
                        cmd.Parameters.Add(new SqlParameter("@WHORegion", _data.WHORegion == null ? DBNull.Value : _data.WHORegion));
                        cmd.Parameters.Add(new SqlParameter("@City", _data.City == null ? DBNull.Value : _data.City));
                        cmd.Parameters.Add(new SqlParameter("@deployment", _data.deployment == null ? DBNull.Value : _data.deployment));
                        cmd.Parameters.Add(new SqlParameter("@ObjectiveDeployment", _data.ObjectiveDeployment == null ? DBNull.Value : _data.ObjectiveDeployment));//_data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude));
                        cmd.Parameters.Add(new SqlParameter("@NumberofGraduatesDeployed", _data.NumberofGraduatesDeployed == null ? DBNull.Value : _data.NumberofGraduatesDeployed));
                        cmd.Parameters.Add(new SqlParameter("@ResidentsDeployed", _data.ResidentsDeployed == null ? DBNull.Value : _data.ResidentsDeployed));
                        cmd.Parameters.Add(new SqlParameter("@HIVStatus", _data.HIVStatus == null ? DBNull.Value : _data.HIVStatus));
                        cmd.Parameters.Add(new SqlParameter("@TraineeAssigned", _data.TraineeAssigned == null ? DBNull.Value : _data.TraineeAssigned));

                        //
                        cmd.Parameters.Add(new SqlParameter("@problemDescription", _data.problemDescription == null ? DBNull.Value : _data.problemDescription));
                        cmd.Parameters.Add(new SqlParameter("@TeamComposition", _data.TeamComposition == null ? DBNull.Value : _data.TeamComposition));
                        cmd.Parameters.Add(new SqlParameter("@InvestivationObjective", _data.InvestivationObjective == null ? DBNull.Value : _data.InvestivationObjective));
                        cmd.Parameters.Add(new SqlParameter("@ProjectSupporting", _data.ProjectSupporting == null ? DBNull.Value : _data.ProjectSupporting));
                        cmd.Parameters.Add(new SqlParameter("@DataForCollection", _data.DataForCollection == null ? DBNull.Value : _data.DataForCollection));
                        cmd.Parameters.Add(new SqlParameter("@AnticipatedScope", _data.AnticipatedScope == null ? DBNull.Value : _data.AnticipatedScope));
                        cmd.Parameters.Add(new SqlParameter("@ReportingRecommendations", _data.ReportingRecommendations == null ? DBNull.Value : _data.ReportingRecommendations));
                        cmd.Parameters.Add(new SqlParameter("@ImprovementDescription", _data.ImprovementDescription == null ? DBNull.Value : _data.ImprovementDescription));
                        cmd.Parameters.Add(new SqlParameter("@Research_orNon", _data.Research_orNon == null ? DBNull.Value : _data.Research_orNon));
                        cmd.Parameters.Add(new SqlParameter("@TargetPopulation", _data.TargetPopulation == null ? DBNull.Value : _data.TargetPopulation));
                        cmd.Parameters.Add(new SqlParameter("@CDCRole", _data.CDCRole == null ? DBNull.Value : _data.CDCRole));
                        cmd.Parameters.Add(new SqlParameter("@TypeId", _data.TypeId == null ? DBNull.Value : _data.TypeId));
                        cmd.Parameters.Add(new SqlParameter("@Reviewed", "New"));
                        cmd.Parameters.Add(new SqlParameter("@UpdateDateTime", _data.UpdateDateTime == null ? DBNull.Value : Convert.ToDateTime(_data.UpdateDateTime).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@DataSpecimensCollected", _data.DataSpecimensCollected));
                        cmd.Parameters.Add(new SqlParameter("@FocusGroupDataCollected", _data.FocusGroupDataCollected));
                        cmd.Parameters.Add(new SqlParameter("@DataFromRoutineSurveillance", _data.DataFromRoutineSurveillance));
                        cmd.Parameters.Add(new SqlParameter("@AdministrativeInformation", _data.AdministrativeInformation));
                        cmd.Parameters.Add(new SqlParameter("@DataHealthFacilities", _data.DataHealthFacilities));
                        cmd.Parameters.Add(new SqlParameter("@DataUnlinkedAnonymous", _data.DataUnlinkedAnonymous));
                        cmd.Parameters.Add(new SqlParameter("@DataDeceasedPersons", _data.DataDeceasedPersons));
                        cmd.Parameters.Add(new SqlParameter("@DataVertebrateAnimals", _data.DataVertebrateAnimals));
                        cmd.Parameters.Add(new SqlParameter("@CurrentORpostGraduate", _data.CurrentORpostGraduate));

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpInsertIntermediateResident2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _guid));
                        cmd.Parameters.Add(new SqlParameter("@ProjectStatus", _data.ProjectStatus == null ? DBNull.Value : _data.ProjectStatus));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate4", _data.ValidityDate4 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate4)));
                        cmd.Parameters.Add(new SqlParameter("@OutbreakReporting", _data.OutbreakReporting == "" ? DBNull.Value : _data.OutbreakReporting));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate5", _data.ValidityDate5 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate5)));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDRoutineSurv", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@PublicHealthResponse", _data.PublicHealthResponse == "" ? DBNull.Value : _data.PublicHealthResponse));
                        cmd.Parameters.Add(new SqlParameter("@IDIDRoutineSurvRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDMedia", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ProjectTravel", _data.ProjectTravel == null ? DBNull.Value : _data.ProjectTravel));
                        cmd.Parameters.Add(new SqlParameter("@IDIDMediaRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDRumorRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DaysinField", _data.DaysinField));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDRumors", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDClinical", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDClinicRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@questionnaires", _data.questionnaires == null ? DBNull.Value : _data.questionnaires));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDOtherSpec", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDOtherRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OralBriefing", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDOtherSpecify", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@WrittenInitialFindings", _data.WrittenDocumentAvailable == null ? DBNull.Value : _data.WrittenDocumentAvailable));
                        cmd.Parameters.Add(new SqlParameter("@FirstPublicCommunication", _data.DateFirstPublic == null ? DBNull.Value : Convert.ToDateTime(_data.DateFirstPublic).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseFinal", _data.DiseaseFinal == null ? DBNull.Value : _data.DiseaseFinal));
                        cmd.Parameters.Add(new SqlParameter("@SecondaryYes1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherFinalSecondaryDx", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ONEHealth1", _data.ONEHealth1 == null ? DBNull.Value : _data.ONEHealth1));
                        cmd.Parameters.Add(new SqlParameter("@FinalNumberAffect", _data.FinalNumberAffect == null ? DBNull.Value : _data.FinalNumberAffect));
                        //
                        cmd.Parameters.Add(new SqlParameter("@Exposure", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ExposureOther", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate6", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@LaboratoryConfirmation", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ONEHealth2", _data.ONEHealth2 == null ? DBNull.Value : _data.ONEHealth2));
                        cmd.Parameters.Add(new SqlParameter("@ChildLs5", _data.Children5));
                        cmd.Parameters.Add(new SqlParameter("@Male", _data.Male));
                        cmd.Parameters.Add(new SqlParameter("@ChildGr5", _data.Children511));
                        cmd.Parameters.Add(new SqlParameter("@Female", _data.Female));
                        cmd.Parameters.Add(new SqlParameter("@Adolescents", _data.Children1219));
                        cmd.Parameters.Add(new SqlParameter("@TransgenFtoM", _data.FtoM));
                        cmd.Parameters.Add(new SqlParameter("@Adults", _data.Children2060));
                        cmd.Parameters.Add(new SqlParameter("@TransgenMtoF", _data.MtoF));
                        cmd.Parameters.Add(new SqlParameter("@workNotapplicablefield", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Elderly", _data.Children61));
                        cmd.Parameters.Add(new SqlParameter("@GeneralDiseaseNameFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@WorkComplete", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@FieldWorkStart", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@GeneralDiseaseNameFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ICD10CodeFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisStart", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisIn", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseCategoryFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseCategoryFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseEnglishFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Enddateofactivity", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisDue", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseEnglishFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ICD10CodeFinal", DBNull.Value));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                if (_data.WrittenCommunications != null)
                {
                    foreach (WrittenCommunication data in _data.WrittenCommunications)
                    {
                        using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("SpInsertAttachmentProjects1", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _guid));
                            cmd.Parameters.Add(new SqlParameter("@file", data.File_Att == null ? DBNull.Value : data.File_Att));
                            cmd.Parameters.Add(new SqlParameter("@FileName", data.Att_FileName == null ? DBNull.Value : data.Att_FileName));
                            cmd.Parameters.Add(new SqlParameter("@fileContentType", data.ContentType == null ? DBNull.Value : data.ContentType));
                            cmd.Parameters.Add(new SqlParameter("@fileSize", data.FileSize == null ? DBNull.Value : data.FileSize));
                            cmd.Parameters.Add(new SqlParameter("@reportTitle", data.Report_Title == null ? DBNull.Value : data.Report_Title));
                            cmd.Parameters.Add(new SqlParameter("@reportCategory", data.TypeOfReport == null ? DBNull.Value : data.TypeOfReport));
                            cmd.Parameters.Add(new SqlParameter("@SuspectedDisease", data.SuspectedDisease == "-Select-" ? DBNull.Value : data.SuspectedDisease));
                            cmd.Parameters.Add(new SqlParameter("@ResidentName", data.ResidentName == "" ? DBNull.Value : data.ResidentName));
                            cmd.Parameters.Add(new SqlParameter("@CurrentResident", data.CurrentResident));
                            cmd.Parameters.Add(new SqlParameter("@RequiredCommunication", data.RequiredCommunication == "undefined" ? DBNull.Value : data.RequiredCommunication));
                            cmd.Parameters.Add(new SqlParameter("@Accepted", data.Accepted == "undefined" ? DBNull.Value : data.Accepted));
                            cmd.Parameters.Add(new SqlParameter("@FullCitation", data.FullCitation == "" ? DBNull.Value : data.FullCitation));
                            cmd.Parameters.Add(new SqlParameter("@SubmittedTo", data.SubmittedTo == "" ? DBNull.Value : data.SubmittedTo));
                            cmd.Parameters.Add(new SqlParameter("@DateofSubmission", data.DateofSubmission == "" ? DBNull.Value : Convert.ToDateTime(data.DateofSubmission).ToShortDateString()));
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                    }
                }

                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PEPFARFunded", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _guid));
                        cmd.Parameters.Add(new SqlParameter("@PEPFARComplete1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVPOART", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ART1", _data.ART == null ? DBNull.Value : Convert.ToInt32(_data.ART)));
                        cmd.Parameters.Add(new SqlParameter("@ProjHIVMonitoring", _data.ProjHIVMonitoring == null ? DBNull.Value : _data.ProjHIVMonitoring));
                        cmd.Parameters.Add(new SqlParameter("@PMTCT1", _data.PMTCT == null ? DBNull.Value : Convert.ToInt32(_data.PMTCT)));
                        cmd.Parameters.Add(new SqlParameter("@TBHIV1", _data.TBHIV == null ? DBNull.Value : Convert.ToInt32(_data.TBHIV)));
                        cmd.Parameters.Add(new SqlParameter("@KeyPopulations1", _data.KeyPopulations == null ? DBNull.Value : Convert.ToInt32(_data.KeyPopulations)));
                        cmd.Parameters.Add(new SqlParameter("@DATIM1", _data.DATIM));
                        cmd.Parameters.Add(new SqlParameter("@HIVMSM", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVPWID", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DQASQA1", _data.DQASQA));
                        cmd.Parameters.Add(new SqlParameter("@HIVFSW", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVTransgender", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVMigrants", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@EA1", _data.EA));
                        cmd.Parameters.Add(new SqlParameter("@HIVPrisoners", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SIMS1", _data.SIMS));
                        cmd.Parameters.Add(new SqlParameter("@Laboratory1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SI1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SLMTA1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherPEPFARMonitoring1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherHIVProgram1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVDataRequest", _data.ResponseToDatRequest == null ? DBNull.Value : Convert.ToInt32(_data.ResponseToDatRequest)));
                        cmd.Parameters.Add(new SqlParameter("@HIVGirlWoman", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVOrphans", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVFindingMen", _data.HIVStatus == null ? DBNull.Value : Convert.ToInt32(_data.HIVStatus)));
                        cmd.Parameters.Add(new SqlParameter("@HIVStigma", _data.Stigma == null ? DBNull.Value : Convert.ToInt32(_data.Stigma)));
                        cmd.Parameters.Add(new SqlParameter("@HIVSNU", DBNull.Value));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                if (_data.CommentsTab != null)
                {
                    foreach (CommentsTab data in _data.CommentsTab)
                    {
                        using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("SpInsertGeneralComments", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@commentText", data.commentText));
                            cmd.Parameters.Add(new SqlParameter("@commentDate", _data.author + " " + DateTime.Now.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@CommentName", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@projectID", _guid));

                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void UpdateNewIntermediateResidents(IntermediateResidentData _data, string _guid)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection("Server=tcp:testwebjob.database.windows.net,1433;Initial Catalog=TrackingMasterOLD;Persist Security Info=False;User ID=testadmin;" +
                //    "Password=Password13!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                //using (SqlConnection conn = new SqlConnection("Server=DESKTOP-N8T9AT4;Initial Catalog==TrackingMasterOLD;Persist Security Info=False;" +
                //   "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))

                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpUpdateIntermediateResident", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@FETP", _data.FETP));
                        cmd.Parameters.Add(new SqlParameter("@Intermediate", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Type", _data.Type == null ? DBNull.Value : _data.Type));
                        cmd.Parameters.Add(new SqlParameter("@ProjectClassification", _data.ProjectClassification));//_data.CohortNumber == null ? DBNull.Value : _data.CohortNumber));
                        cmd.Parameters.Add(new SqlParameter("@DateAssigned", _data.DateAssigned == null ? DBNull.Value : Convert.ToDateTime(_data.DateAssigned).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@LeadResident", _data.LeadResident == null ? DBNull.Value : _data.LeadResident));
                        cmd.Parameters.Add(new SqlParameter("@MentorFullName", _data.MentorFullName == null ? DBNull.Value : _data.MentorFullName));
                        cmd.Parameters.Add(new SqlParameter("@projecttitle", _data.projecttitle == null ? DBNull.Value : _data.projecttitle));//0));
                        cmd.Parameters.Add(new SqlParameter("@SenstiveData", _data.SenstiveData));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate1", _data.ValidityDate1 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate1)));
                        cmd.Parameters.Add(new SqlParameter("@Outbreakdetection", _data.Outbreakdetection == null ? DBNull.Value : Convert.ToDateTime(_data.Outbreakdetection).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@Outbreakstart", _data.Outbreakstart == null ? DBNull.Value : Convert.ToDateTime(_data.Outbreakstart).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate2", _data.ValidityDate2 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate2)));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate3", _data.ValidityDate3 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate3)));
                        cmd.Parameters.Add(new SqlParameter("@DateOutbreakEnd", _data.DateOutbreakEnd == null ? DBNull.Value : Convert.ToDateTime(_data.DateOutbreakEnd).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@Setting", _data.Setting == null ? DBNull.Value : _data.Setting));
                        cmd.Parameters.Add(new SqlParameter("@SettingOther", _data.SettingOther == null ? DBNull.Value : _data.SettingOther));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseSuspected", _data.DiseaseSuspected == null ? DBNull.Value : _data.DiseaseSuspected));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseSuspected1", _data.DiseaseSuspected1 == null ? DBNull.Value : _data.DiseaseSuspected1));
                        cmd.Parameters.Add(new SqlParameter("@InitialCases", _data.InitialCases == null ? DBNull.Value : _data.InitialCases));
                        cmd.Parameters.Add(new SqlParameter("@Country", _data.Country == null ? DBNull.Value : _data.Country));
                        cmd.Parameters.Add(new SqlParameter("@WHORegion", _data.WHORegion == null ? DBNull.Value : _data.WHORegion));
                        cmd.Parameters.Add(new SqlParameter("@City", _data.City == null ? DBNull.Value : _data.City));
                        cmd.Parameters.Add(new SqlParameter("@deployment", _data.deployment == null ? DBNull.Value : _data.deployment));
                        cmd.Parameters.Add(new SqlParameter("@ObjectiveDeployment", _data.ObjectiveDeployment == null ? DBNull.Value : _data.ObjectiveDeployment));//_data.RPFL19_Longitude == null ? DBNull.Value : _data.RPFL19_Longitude));
                        cmd.Parameters.Add(new SqlParameter("@NumberofGraduatesDeployed", _data.NumberofGraduatesDeployed == null ? DBNull.Value : _data.NumberofGraduatesDeployed));
                        cmd.Parameters.Add(new SqlParameter("@ResidentsDeployed", _data.ResidentsDeployed == null ? DBNull.Value : _data.ResidentsDeployed));
                        cmd.Parameters.Add(new SqlParameter("@HIVStatus", _data.HIVStatus == null ? DBNull.Value : _data.HIVStatus));
                        cmd.Parameters.Add(new SqlParameter("@TraineeAssigned", _data.TraineeAssigned == null ? DBNull.Value : _data.TraineeAssigned));

                        //
                        cmd.Parameters.Add(new SqlParameter("@problemDescription", _data.problemDescription == null ? DBNull.Value : _data.problemDescription));
                        cmd.Parameters.Add(new SqlParameter("@TeamComposition", _data.TeamComposition == null ? DBNull.Value : _data.TeamComposition));
                        cmd.Parameters.Add(new SqlParameter("@InvestivationObjective", _data.InvestivationObjective == null ? DBNull.Value : _data.InvestivationObjective));
                        cmd.Parameters.Add(new SqlParameter("@ProjectSupporting", _data.ProjectSupporting == null ? DBNull.Value : _data.ProjectSupporting));
                        cmd.Parameters.Add(new SqlParameter("@DataForCollection", _data.DataForCollection == null ? DBNull.Value : _data.DataForCollection));
                        cmd.Parameters.Add(new SqlParameter("@AnticipatedScope", _data.AnticipatedScope == null ? DBNull.Value : _data.AnticipatedScope));
                        cmd.Parameters.Add(new SqlParameter("@ReportingRecommendations", _data.ReportingRecommendations == null ? DBNull.Value : _data.ReportingRecommendations));
                        cmd.Parameters.Add(new SqlParameter("@ImprovementDescription", _data.ImprovementDescription == null ? DBNull.Value : _data.ImprovementDescription));
                        cmd.Parameters.Add(new SqlParameter("@Research_orNon", _data.Research_orNon == null ? DBNull.Value : _data.Research_orNon));
                        cmd.Parameters.Add(new SqlParameter("@TargetPopulation", _data.TargetPopulation == null ? DBNull.Value : _data.TargetPopulation));
                        cmd.Parameters.Add(new SqlParameter("@CDCRole", _data.CDCRole == null ? DBNull.Value : _data.CDCRole));
                        cmd.Parameters.Add(new SqlParameter("@TypeId", _data.TypeId == null ? DBNull.Value : _data.TypeId));
                        cmd.Parameters.Add(new SqlParameter("@Reviewed", "Updated"));
                        cmd.Parameters.Add(new SqlParameter("@UpdateDateTime", _data.UpdateDateTime == null ? DBNull.Value : Convert.ToDateTime(_data.UpdateDateTime).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@DataSpecimensCollected", _data.DataSpecimensCollected));
                        cmd.Parameters.Add(new SqlParameter("@FocusGroupDataCollected", _data.FocusGroupDataCollected));
                        cmd.Parameters.Add(new SqlParameter("@DataFromRoutineSurveillance", _data.DataFromRoutineSurveillance));
                        cmd.Parameters.Add(new SqlParameter("@AdministrativeInformation", _data.AdministrativeInformation));
                        cmd.Parameters.Add(new SqlParameter("@DataHealthFacilities", _data.DataHealthFacilities));
                        cmd.Parameters.Add(new SqlParameter("@DataUnlinkedAnonymous", _data.DataUnlinkedAnonymous));
                        cmd.Parameters.Add(new SqlParameter("@DataDeceasedPersons", _data.DataDeceasedPersons));
                        cmd.Parameters.Add(new SqlParameter("@DataVertebrateAnimals", _data.DataVertebrateAnimals));
                        cmd.Parameters.Add(new SqlParameter("@CurrentORpostGraduate", _data.CurrentORpostGraduate));
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    if (_data.OutbreakReporting.ToString() == "1/1/0001 12:00:00 AM")
                    {
                        _data.OutbreakReporting = null;
                    }
                    if (_data.PublicHealthResponse.ToString() == "1/1/0001 12:00:00 AM")
                    {
                        _data.PublicHealthResponse = null;
                    }
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SpUpdateIntermediateResident2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ProjectStatus", _data.ProjectStatus == null ? DBNull.Value : _data.ProjectStatus));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate4", _data.ValidityDate4 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate4)));
                        cmd.Parameters.Add(new SqlParameter("@OutbreakReporting", _data.OutbreakReporting == "" ? DBNull.Value : _data.OutbreakReporting));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate5", _data.ValidityDate5 == null ? DBNull.Value : Convert.ToInt16(_data.ValidityDate5)));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDRoutineSurv", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@PublicHealthResponse", _data.PublicHealthResponse == "" ? DBNull.Value : _data.PublicHealthResponse));
                        cmd.Parameters.Add(new SqlParameter("@IDIDRoutineSurvRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDMedia", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ProjectTravel", _data.ProjectTravel == null ? DBNull.Value : _data.ProjectTravel));
                        cmd.Parameters.Add(new SqlParameter("@IDIDMediaRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDRumorRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DaysinField", _data.DaysinField));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDRumors", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDClinical", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDClinicRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@questionnaires", _data.questionnaires == null ? DBNull.Value : _data.questionnaires));
                        cmd.Parameters.Add(new SqlParameter("@InitialDiseaseIDOtherSpec", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDOtherRank", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OralBriefing", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@IDIDOtherSpecify", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@WrittenInitialFindings", _data.WrittenDocumentAvailable == null ? DBNull.Value : _data.WrittenDocumentAvailable));
                        cmd.Parameters.Add(new SqlParameter("@FirstPublicCommunication", _data.DateFirstPublic == null ? DBNull.Value : Convert.ToDateTime(_data.DateFirstPublic).ToShortDateString()));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseFinal", _data.DiseaseFinal == null ? DBNull.Value : _data.DiseaseFinal));
                        cmd.Parameters.Add(new SqlParameter("@SecondaryYes1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherFinalSecondaryDx", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ONEHealth1", _data.ONEHealth1 == null ? DBNull.Value : _data.ONEHealth1));
                        cmd.Parameters.Add(new SqlParameter("@FinalNumberAffect", _data.FinalNumberAffect == null ? DBNull.Value : _data.FinalNumberAffect));
                        //
                        cmd.Parameters.Add(new SqlParameter("@Exposure", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ExposureOther", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ValidityDate6", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@LaboratoryConfirmation", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ONEHealth2", _data.ONEHealth2 == null ? DBNull.Value : _data.ONEHealth2));
                        cmd.Parameters.Add(new SqlParameter("@ChildLs5", _data.Children5));
                        cmd.Parameters.Add(new SqlParameter("@Male", _data.Male));
                        cmd.Parameters.Add(new SqlParameter("@ChildGr5", _data.Children511));
                        cmd.Parameters.Add(new SqlParameter("@Female", _data.Female));
                        cmd.Parameters.Add(new SqlParameter("@Adolescents", _data.Children1219));
                        cmd.Parameters.Add(new SqlParameter("@TransgenFtoM", _data.FtoM));
                        cmd.Parameters.Add(new SqlParameter("@Adults", _data.Children2060));
                        cmd.Parameters.Add(new SqlParameter("@TransgenMtoF", _data.MtoF));
                        cmd.Parameters.Add(new SqlParameter("@workNotapplicablefield", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Elderly", _data.Children61));
                        cmd.Parameters.Add(new SqlParameter("@GeneralDiseaseNameFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@WorkComplete", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@FieldWorkStart", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@GeneralDiseaseNameFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ICD10CodeFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisStart", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisIn", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseCategoryFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseCategoryFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseEnglishFinal1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Enddateofactivity", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAnalysisDue", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DiseaseEnglishFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ICD10CodeFinal", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteAttachmentProjects", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                foreach (WrittenCommunication data in _data.WrittenCommunications)
                {
                    using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SpInsertAttachmentProjects1", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                        cmd.Parameters.Add(new SqlParameter("@file", data.File_Att == null ? DBNull.Value : data.File_Att));
                        cmd.Parameters.Add(new SqlParameter("@FileName", data.Att_FileName == null ? DBNull.Value : data.Att_FileName));
                        cmd.Parameters.Add(new SqlParameter("@fileContentType", data.ContentType == null ? DBNull.Value : data.ContentType));
                        cmd.Parameters.Add(new SqlParameter("@fileSize", data.FileSize == null ? DBNull.Value : data.FileSize));
                        cmd.Parameters.Add(new SqlParameter("@reportTitle", data.Report_Title == null ? DBNull.Value : data.Report_Title));
                        cmd.Parameters.Add(new SqlParameter("@reportCategory", data.TypeOfReport == null ? DBNull.Value : data.TypeOfReport));
                        cmd.Parameters.Add(new SqlParameter("@SuspectedDisease", data.SuspectedDisease == "-Select-" ? DBNull.Value : data.SuspectedDisease));
                        cmd.Parameters.Add(new SqlParameter("@ResidentName", data.ResidentName == "" ? DBNull.Value : data.ResidentName));
                        cmd.Parameters.Add(new SqlParameter("@CurrentResident", data.CurrentResident));
                        cmd.Parameters.Add(new SqlParameter("@RequiredCommunication", data.RequiredCommunication == "undefined" ? DBNull.Value : data.RequiredCommunication));
                        cmd.Parameters.Add(new SqlParameter("@Accepted", data.Accepted == "undefined" ? DBNull.Value : data.Accepted));
                        cmd.Parameters.Add(new SqlParameter("@FullCitation", data.FullCitation == "" ? DBNull.Value : data.FullCitation));
                        cmd.Parameters.Add(new SqlParameter("@SubmittedTo", data.SubmittedTo == "" ? DBNull.Value : data.SubmittedTo));
                        cmd.Parameters.Add(new SqlParameter("@DateofSubmission", data.DateofSubmission == "" ? DBNull.Value : Convert.ToDateTime(data.DateofSubmission).ToShortDateString()));
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PEPFARFundedUpdate", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@PEPFARComplete1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVPOART", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@ART1", _data.ART == null ? DBNull.Value : Convert.ToInt32(_data.ART)));
                        cmd.Parameters.Add(new SqlParameter("@ProjHIVMonitoring", _data.ProjHIVMonitoring == null ? DBNull.Value : _data.ProjHIVMonitoring));
                        cmd.Parameters.Add(new SqlParameter("@PMTCT1", _data.PMTCT == null ? DBNull.Value : Convert.ToInt32(_data.PMTCT)));
                        cmd.Parameters.Add(new SqlParameter("@TBHIV1", _data.TBHIV == null ? DBNull.Value : Convert.ToInt32(_data.TBHIV)));
                        cmd.Parameters.Add(new SqlParameter("@KeyPopulations1", _data.KeyPopulations == null ? DBNull.Value : Convert.ToInt32(_data.KeyPopulations)));
                        cmd.Parameters.Add(new SqlParameter("@DATIM1", _data.DATIM));
                        cmd.Parameters.Add(new SqlParameter("@HIVMSM", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVPWID", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DQASQA1", _data.DQASQA));
                        cmd.Parameters.Add(new SqlParameter("@HIVFSW", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVTransgender", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVMigrants", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@EA1", _data.EA));
                        cmd.Parameters.Add(new SqlParameter("@HIVPrisoners", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SIMS1", _data.SIMS));
                        cmd.Parameters.Add(new SqlParameter("@Laboratory1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SI1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SLMTA1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherPEPFARMonitoring1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@OtherHIVProgram1", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVDataRequest", _data.ResponseToDatRequest == null ? DBNull.Value : Convert.ToInt32(_data.ResponseToDatRequest)));
                        cmd.Parameters.Add(new SqlParameter("@HIVGirlWoman", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVOrphans", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@HIVFindingMen", _data.HIVStatus == null ? DBNull.Value : Convert.ToInt32(_data.HIVStatus)));
                        cmd.Parameters.Add(new SqlParameter("@HIVStigma", _data.Stigma == null ? DBNull.Value : Convert.ToInt32(_data.Stigma)));
                        cmd.Parameters.Add(new SqlParameter("@HIVSNU", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@GlobalRecordId", _data.GlobalRecordId));
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteGeneralComments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@projectID", _data.GlobalRecordId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (_data.CommentsTab != null)
                {
                    foreach (CommentsTab data in _data.CommentsTab)
                    {
                        using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DBase")))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("SpInsertGeneralComments", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@commentText", data.commentText));
                            cmd.Parameters.Add(new SqlParameter("@commentDate", _data.author + " " + DateTime.Now.ToString()));
                            cmd.Parameters.Add(new SqlParameter("@CommentName", DBNull.Value));
                            cmd.Parameters.Add(new SqlParameter("@projectID", _data.GlobalRecordId));

                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
