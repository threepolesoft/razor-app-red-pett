using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal
{
    [Table("user")]
    public class Project
    {
        public string FETP { get; set; }
        public string CohortNumber { get; set; }
        public string CohortEndDate { get; set; }
        public string CohortStartDate { get; set; }
        public string ResidentName { get; set; }
        public string Given_FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Sur_LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Professional_Background { get; set; }
        public string Employer { get; set; }
        public string JobTitle { get; set; }
        public int YearsOnJob { get; set; }
        public string SupervisorName { get; set; }
        public string SiteAddress { get; set; }
        public string City { get; set; }
        public string State_Region_Pro { get; set; }
        public string Postal_Zip { get; set; }
        public string Country { get; set; }
        public int RPFL19_Longitude { get; set; }
        public string RPFL20_Latitude { get; set; }
        public string Secondary_Subnational_Unit { get; set; }
        public string Tertiary_Subnational_Unit { get; set; }
        public string FacilityName { get; set; }
        public string FacilityLevel { get; set; }
    }
    public class Frontline36
    {
        [Key] // Specify TrackingID as the primary key

        public int TrackingID { get; set; }
        public string GlobalRecordId { get; set; }
        public bool RALevel { get; set; }
        public string FETPFrontline { get; set; }
        public float RPFL1_CohortNumber { get; set; }
        public DateTime RPFL2_CohortStart { get; set; }
        public DateTime RPFL3_CohortEnd { get; set; }
        public float RPFL4_RosterNumber { get; set; }
        public string RPFL5_NameLast { get; set; }
        public string RPFL6_NameFirst { get; set; }
        public string RPFL7_FullName { get; set; }
        public string RPFL8_Sex { get; set; }
        public DateTime RPFL_DateofBirth { get; set; }
        public float RPFL9_Age { get; set; }
        public string RPFL10_Email { get; set; }
        public string RPFL12_Employer { get; set; }
        public string RPFL11_ProBckgrd { get; set; }
        public string RPFL11b_Other { get; set; }
        public float RPFL14_YearJob { get; set; }
        public string RPFL13_JobTitle { get; set; }
        public string RPFL16_SupervisorName { get; set; }
        public string RPFL15_SiteName { get; set; }
        public float RPFL20_Latitude { get; set; }
        public float RPFL19_Longitude { get; set; }
        public string RPFL17_District { get; set; }
        public string RPFL18_Region { get; set; }
        public string RPFL22_FacilityName { get; set; }
        public string RPFL23a_LevelFacility { get; set; }
        public string RPFL23b_Other { get; set; }
    }

}
