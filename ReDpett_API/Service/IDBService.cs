using ReDpett_API.Modal;
using System.Data;

namespace ReDpett_API.Service
{
    public interface IDBService
    {
        //string Role { get; set; }
        void InserTransaction(AppDataService _data, string _guid);
        bool CreateUser(Register register);
        bool ValidateCredentials(Login loginfromuser);
        DataTable getattachments();
        DataTable getGComments();
        DataTable getprojects();
        DataTable getChartData();
        void UpdateTransaction(AppDataService _data);
        DataTable Getcodeprojectstatus1();
        DataTable getAllTiers();
        DataTable getRegions();
        DataTable getAlltrainings();
        DataTable Getprojectstatus();
        DataTable GetCodetype2();
        DataTable Getcodesetting1();
        DataTable GetcodeTargetPopulation();
        DataTable GetCodeCdcRoles();
        DataTable Getcodeprojectclassification1();
        DataTable Getcodediseaseenglish();
        void UpdateTransaction(AppDataService _data, string _guid);
        DataTable GetCountries();
        DataTable getintermediateResidents(string country, string LeadResident);
        void UpdateIntermediateResidents(IntermediateResidentData _data);
        void InsertIntermediateResidents(IntermediateResidentData _data, string _guid);
        void DeleteTransaction(AppDataService _data);
        void DeleteIntermediateResidents(IntermediateResidentData _data);
        void UpdateNewIntermediateResidents(IntermediateResidentData _data, string _guid);
        DataTable getintermediateAttchments();
        DataTable getintermediateResidents2();
        DataTable getPAPFAR();
        DataTable Getcodeexposure1();
        DataTable GetToolTips();
    }
}
