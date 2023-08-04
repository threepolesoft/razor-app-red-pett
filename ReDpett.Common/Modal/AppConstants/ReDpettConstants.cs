using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal.AppConstants
{
    public class Mentor
    {
        public string id;
        public string name;
    }
    public static class ReDpettConstants
    {
        public static string BaseAddress = "https://v3-web-app-for-api.azurewebsites.net/";
        //public static string BaseAddress = "https://localhost:7194/";
        public const string ContentType = "application/json";
        public const string LoginAddress = "Login";
        public const string RegisterAddress = "api/Registers";
        public const string GetResidents = "/FindResidents";
        public const string RoleAddress = "api/Roles";
        public const string CountriesList = "api/Countries";
        public const string FETPPrograms = "api/FETPPrograms";
        public const string ResidentTypes = "api/ResidentTypes";
        public const string Passcode = "api/Passcodes";

        public static string SelectedCountry = "";
        public static string SelectedProgram = "";

        public static string GeneratedPasscode = "";
        public static bool isNonResident = false;
        public static int countryId = 0;    
        public static int programId = 0; //countryId,programId
        public const int programName = 0;
        public static string UserName = "";


    }

    


}
