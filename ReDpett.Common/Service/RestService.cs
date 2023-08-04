using Microsoft.VisualBasic;
using Newtonsoft.Json;
//using ReDpett.Pages;
using ReDpett_API.Modal;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ReDpett.Modal;
using ReDpett.ViewModel;
using ReDpett.Modal.Login;
using System.Data;
using ReDpett.Common.Modal;
using ReDpett.Common.Modal.Settings;
//using ThreadNetwork;

namespace ReDpett.Service
{
    public class RestService : IRestService
    {

        HttpClient _httpClient;
        RestClient client;
        JsonSerializerOptions _serializerOptions;
        //private string URL = "http://reddpt.somee.com/";
        public List<Login> Logins { get; private set; }
        public RestService()
        {
            _httpClient = new HttpClient();
            client = new RestClient();
            _serializerOptions = new JsonSerializerOptions
            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<Login>> RefreshLoginData()
        {
            Logins = new List<Login>();
            //Uri uri = new Uri(URL);
            //try
            //{
            //    HttpResponseMessage response = await _httpClient.GetAsync(uri + "api/logins");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string content = await response.Content.ReadAsStringAsync();
            //        Logins = System.Text.Json.JsonSerializer.Deserialize<List<Login>>(content, _serializerOptions);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //}

            return Logins;
        }

        public async Task PostLogin(LoginRequesModel item, bool isNewItem = false)
        {
            //Uri uri = new Uri(URL);

            //try
            //{
            //    string json = System.Text.Json.JsonSerializer.Serialize<LoginRequesModel>(item, _serializerOptions);
            //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //    HttpResponseMessage response = null;
            //    if (isNewItem)
            //        response = await _httpClient.PostAsync(uri, content);
            //    else
            //        response = await _httpClient.PutAsync(URL, content);

            //    if (response.IsSuccessStatusCode)
            //        Debug.WriteLine(@"\tTodoItem successfully saved.");
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //}
        }

        public async Task<String> AddProject(AppDataService postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/Insert", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Project Added";
                }
                return "Project  Added";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> UpdateProject(AppDataService postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/Update", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Project Added";
                }
                return "Project  Added";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> UpdateNewIntermediateResidents(IntermediateResidentData postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Update", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Intermediate Resident Updated";
                }
                return "Intermediate Resident Updated";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }

        public async Task<string> AddIntermediateResident(IntermediateResidentData postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Insert", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Intermediate Residents Added";
                }
                return "Intermediate Residents Added";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<string> UpdateProjectfull(AppDataService postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/UpdateFull", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Project Added";
                }
                return "Project  Added";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> UpdateIntermediateResidents(IntermediateResidentData postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/UpdateIntermediateResidents", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Intermediate Residents Added";
                }
                return "Intermediate Residents  Added";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> DeleteProject(AppDataService postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/Delete", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Project Deleted";
                }
                return "Project  Deleted";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> DeleteIntermediateResidents(IntermediateResidentData postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/DeleteIntermediateResidents", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "Intermediate Resident Deleted";
                }
                return "Intermediate Resident   Deleted";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<String> RegisterUser(RegisterViewModel postData)
        {
            try
            {
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Registers", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return "registered";
                }
                return "Cannot Resgiter";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error Occured";
            }
        }
        public async Task<LoginResponseModel> Login(LoginRequesModel postData)
        {
            try
            {
                LoginResponseModel res = new LoginResponseModel();
                var request = new RestRequest(Modal.AppConstants.ReDpettConstants.BaseAddress + "Login", Method.Post);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                var result = System.Text.Json.JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                request.AddBody(result);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return System.Text.Json.JsonSerializer.Deserialize<LoginResponseModel>(response.Content, _serializerOptions);
                }
                return System.Text.Json.JsonSerializer.Deserialize<LoginResponseModel>(response.Content, _serializerOptions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new LoginResponseModel();
            }
        }
        private Roles[] response;

        public async Task<List<Roles>> Get()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Roles", string.Empty));
                response = await _httpClient.GetFromJsonAsync<Roles[]>(uri);
                return response.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private Country[] countriesResponse;
        public async Task<List<Country>> GetCountries()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Countries", string.Empty));
                countriesResponse = await _httpClient.GetFromJsonAsync<Country[]>(uri);
                return countriesResponse.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private FETPProgram[] programResponse;
        public async Task<List<FETPProgram>> GetFetPrograms()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/FETPPrograms", string.Empty));
                programResponse = await _httpClient.GetFromJsonAsync<FETPProgram[]>(uri);
                return programResponse.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private ResidentType[] residentTypeResponse;
        public async Task<List<ResidentType>> GetResidentType()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/ResidentTypes", string.Empty));
                residentTypeResponse = await _httpClient.GetFromJsonAsync<ResidentType[]>(uri);
                return residentTypeResponse.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<ResidentType> GetResidentType(int id)
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/Registers/GetResidentType/{id}"));
                var res = await _httpClient.GetFromJsonAsync<ResidentType>(uri);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ListAppDataService> GetProjects()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/Get", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<ListAppDataService>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<ListIntermediateResidentData> GetIntermediateResidents(string country, string LeadResident)
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Projects/GetIntermediateResidents?country={country}&leadResident={LeadResident}", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<ListIntermediateResidentData>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<ListIntermediateResidentData> GetIntermediateResidents2()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/GetIntermediateResidents2", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<ListIntermediateResidentData>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<ListIntermediateResidentData> GetPEPFAR()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/GetPEPFAR", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<ListIntermediateResidentData>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<WrittenCommunication>> GetIntermediateAttachments()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/GetIntermediateResidentsAttachments", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<WrittenCommunication>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<chartData>> GetchartData()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/getChartData", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<chartData>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<CommentsTab>> GetComments()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/GetGeneralComments", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<CommentsTab>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<codeprojectclassification1>> getClassifcations()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Getcodeprojectclassification", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<codeprojectclassification1>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<FileData>> GetAttachments()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Projects/GetAttachments", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<FileData>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<codeprojectstatus1>> GetProjectStatus()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetProjectStatus", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<codeprojectstatus1>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<codeprojectstatus1>> GetProjStatus()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetProjStatus", string.Empty));
                var ares = await _httpClient.GetFromJsonAsync<List<codeprojectstatus1>>(uri);
                return ares;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<codediseaseenglish>> GetCodeDiseaseenglish()
        {
            try
            {
                var codediseaseenglish = await _httpClient.GetFromJsonAsync<List<codediseaseenglish>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Getcodediseaseenglish");

                return codediseaseenglish;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<ToolTips>> GetToolTips()
        {
            try
            {
                var codediseaseenglish = await _httpClient.GetFromJsonAsync<List<ToolTips>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetToolTips");

                return codediseaseenglish;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<codesetting1>> GetCodeSetting1()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<codesetting1>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Getcodesetting1");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<codefieldsites123university_training>> Getcodefieldsites123university_training()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<codefieldsites123university_training>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Getcodefieldsites123university_training");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<codefieldsites123university_training>> getRegions()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<codefieldsites123university_training>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/getRegions");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<codefieldsites123university_training>> getTrainings()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<codefieldsites123university_training>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/getAllTrainings");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<List<codeexposure1>> Getcodeexposure1()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<codeexposure1>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/Getcodeexposure1");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //public async Task<DataTable> GetProjects()
        //{
        //    try
        //    {
        //        DataTable list = new DataTable();
        //        Uri uri = new Uri(string.Format("https://localhost:7194/" + "Projects/Get", string.Empty));
        //        list = await _httpClient.GetFromJsonAsync<DataTable>(uri);
        //        return list;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}

        public async Task<List<string>> GetTeamMember(string email)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Intermediate/GetMembers", email);
                List<string> teamMember = await response.Content.ReadFromJsonAsync<List<string>>();
                return teamMember;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetLeadResidents(string email)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Intermediate/GetLeadResidents", email);
                List<string> teamMember = await response.Content.ReadFromJsonAsync<List<string>>();
                return teamMember;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        } 
        public async Task<List<string>> GetSuperVisors(string email)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Intermediate/GetSuperVisors", email);
                List<string> teamMember = await response.Content.ReadFromJsonAsync<List<string>>();
                return teamMember;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetMentor(string email)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Intermediate/GetMentor", email);
                List<string> mentors = await response.Content.ReadFromJsonAsync<List<string>>();
                return mentors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetMentors(string email)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"Intermediate/GetMentors", email);
                List<string> mentors = await response.Content.ReadFromJsonAsync<List<string>>();
                return mentors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetCodeReqWritingType1()
        {
            try
            {
                var Response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetWritingType");

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<CodeTargetPopulation1>> GetcodeTargetPopulation()
        {
            try
            {
                var Response = await _httpClient.GetFromJsonAsync<List<CodeTargetPopulation1>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetcodeTargetPopulation");

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<CodeCdcRole>> GetCodeCdcRoles()
        {
            try
            {
                var Response = await _httpClient.GetFromJsonAsync<List<CodeCdcRole>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetCodeCdcRoles");

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetOneHealth11()
        {
            try
            {
                var Response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetOneHealth11");

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetOneHealth21()
        {
            try
            {
                var Response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "Intermediate/GetOneHealth21");

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> AddTraineeInfo(TraineeInformation6VM traineeInformation6)
        {
            Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/TraineesInfo/AddTraineeInfo"));
            var res = await _httpClient.PostAsJsonAsync(uri, traineeInformation6);
            return true;
        }
        public async Task<bool> UpdateTraineeInfo(int id, TraineeInformation6VM traineeInformation6)
        {
            Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/TraineesInfo/{id}"));
            var res = await _httpClient.PutAsJsonAsync(uri, traineeInformation6);
            return true;
        }
        public async Task<List<string>> GetGender()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Registers/GetGender", string.Empty));
                var result = await _httpClient.GetFromJsonAsync<string[]>(uri);
                return result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Register> GetRegisteredUser(string email)
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/Registers/GetRegisteredUser/{email}"));
                var res = await _httpClient.GetFromJsonAsync<Register>(uri);
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<List<TraineeInformation6VM>> GetAllTraineeInfo()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/TraineesInfo/GetAllTraineeInfo"));
                var res = await _httpClient.GetFromJsonAsync<List<TraineeInformation6VM>>(uri);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<string>> GetFETP()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Registers/GetFETP");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetFETPTrack()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Registers/GetFETPTrack");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<string> GetFETPLevel(string fetp)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/Registers/GetFETPLevel/{fetp}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<string>> GetUniversityTraining(string fetp)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/Registers/GetUniversityTraining/{fetp}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetQualifyingDegree()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/Registers/GetQualifyingDegree");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<string> GetProfilePictureUrl(string email)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/TraineesInfo/GetProfilePictureUrl/{email}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetMentors()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/TraineesInfo/GetMentors", string.Empty));
                var result = await _httpClient.GetFromJsonAsync<string[]>(uri);
                return result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetCodeCurrentProfession()
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/TraineesInfo/GetCodeCurrentProfession", string.Empty));
                var result = await _httpClient.GetFromJsonAsync<string[]>(uri);
                return result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<List<string>> GetCodeInstituteAff()
        {
            try
            {
                var codeSettings = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/TraineesInfo/GetCodeInstituteAff");

                return codeSettings;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public async Task<List<string>> GetOrganizationType()
        {
            try
            {
                var organizationType = await _httpClient.GetFromJsonAsync<List<string>>(Modal.AppConstants.ReDpettConstants.BaseAddress + "api/TraineesInfo/GetOrganizationType");

                return organizationType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public async Task<Roles> GetRoles(int id)
        {
            try
            {
                Uri uri = new Uri(string.Format(Modal.AppConstants.ReDpettConstants.BaseAddress + $"api/Registers/GetRoles/{id}"));
                var res = await _httpClient.GetFromJsonAsync<Roles>(uri);
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }


}