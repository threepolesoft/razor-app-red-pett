using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Common.Modal.Settings
{
    public class ResidentInfoVM
    {
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string CurrentProfession { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string DiseaseAddressed { get; set; } = string.Empty;
        public string InstitutionalAffiliation { get; set; } = string.Empty;
        public string InstitutionalLevel { get; set; } = string.Empty;
        public string InstitutionType { get; set; } = string.Empty;
        public string JobLocation { get; set; } = string.Empty;
        public string? ResidentFETP { get; set; } = string.Empty;
        public DateTime? GraduationDate { get; set; }
    }
}
