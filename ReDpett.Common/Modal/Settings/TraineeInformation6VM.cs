using ReDpett.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Common.Modal.Settings
{
    public class TraineeInformation6VM
    {
        public int GlobalRecordId { get; set; }
        public int RegisterID { get; set; }
        public string? Country { get; set; } = string.Empty;
        public DateTime? Monthbeginning { get; set; }
        public string? UniversityTrainingInstitution { get; set; } = string.Empty;
        public string? QualifyingDegree { get; set; } = string.Empty;
        public int? CohortNumber { get; set; }
        public string? Mentor2 { get; set; } = string.Empty;
        public string? FETPLevel { get; set; } = string.Empty;
        public string? Mentor2x { get; set; } = string.Empty;
        public string? FETPTrack { get; set; } = string.Empty;
        public string? FETP { get; set; } = string.Empty;
        public string? OtherTrack { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? StreetAddress { get; set; } = string.Empty;
        public string? GivenName { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public DateTime? DateofBirth { get; set; }
        public string? State { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? ZipCode { get; set; } = string.Empty;  //PostalCode
        public string? Gender { get; set; } = string.Empty;
        public string? Mobile_Phone { get; set; } = string.Empty;
        public string? HomePhoneNumber { get; set; } = string.Empty;
        public string? TraineeEmail { get; set; } = string.Empty;
        public string? Ext2 { get; set; } = string.Empty;
        public string? BusinessPhone { get; set; } = string.Empty;
        public string? InstituteAff { get; set; } = string.Empty;
        public string? CurrentProfession { get; set; } = string.Empty;
        public string? OtherSpecifyInstitute { get; set; } = string.Empty;
        public string? JobTitle { get; set; } = string.Empty;
        public DateTime? StartDateCurrentJob1 { get; set; }
        public string? SNUJob { get; set; } = string.Empty;
        public string? DiseaseRole { get; set; } = string.Empty;
        public string? OrganizationType { get; set; } = string.Empty;
        public string? OtherSpecifydisease { get; set; } = string.Empty;
        public string? LocationofFacility { get; set; } = string.Empty;
        public bool? EmploymentSame { get; set; }
        public string? InstituteAff1 { get; set; } = string.Empty;
        public string? CurrentProfession1 { get; set; } = string.Empty;
        public string? JobTitle1 { get; set; } = string.Empty;
        public string? SNUJob1 { get; set; } = string.Empty;
        public DateTime? StartDateCurrentJob11 { get; set; }
        public string? DiseaseRole1 { get; set; } = string.Empty;
        public string? OrganizationType1 { get; set; } = string.Empty;
        public string? LocationofFacility1 { get; set; } = string.Empty;
        public string? OtherSpecifydisease1 { get; set; } = string.Empty;
        public string? completeFETP { get; set; } = string.Empty;
        public DateTime? MonthGraduating { get; set; }
        public string? CDCSupport { get; set; } = string.Empty;
        public string? ResidentVerificationCode { get; set; } = string.Empty;
        public bool? AutoGenerate { get; set; }
        public string? TraineeStatus { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        public string? WHORegionTrainee { get; set; } = string.Empty;
        public string? ProgramStartDate { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public string? MailingAddress { get; set; } = string.Empty;
        public string? BusinessAddress { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? contactLatitude { get; set; }
        public double? contactLongitude { get; set; }
        public bool? FETPAlumni { get; set; }
        public bool? Mentor { get; set; }
        public bool? Supervisor { get; set; }
        public bool? LocalRA { get; set; }
        public string? ProfessionalAffiliation { get; set; } = string.Empty;
        public string? PrimaryRole { get; set; } = string.Empty;
        public Register? register { get; set; }
    }
}
