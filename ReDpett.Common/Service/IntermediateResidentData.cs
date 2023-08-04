using ReDpett.Modal;

namespace ReDpett.Service
{

    public class IntermediateResidentData
    {
        public int Status { get; set; }
        public string GUID { get; set; }
        public string SupervisorFullName { get; set; }

        //Section 1
        public string FETP { get; set; }
        public string Type { get; set; }
        public string TypeId { get; set; }
        public string ProjectClassification { get; set; }
        public string ProjectStatus { get; set; }
        public string GlobalRecordId { get; set; }
        public string Reviewed { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string DateAssigned { get; set; }
        public string LeadResident { get; set; }
        public bool Adolescents { get; set; }

        public List<string> TeamMembers { get; set; }
        public List<string> LeadResidents { get; set; }
        public List<string> Supervisors { get; set; }
        public string TraineeAssigned { get; set; }
        public List<string> Mentors { get; set; }
        public string MentorFullName { get; set; }
        public string projecttitle { get; set; }
        public bool SenstiveData { get; set; }
        public bool SingleToggle1 { get; set; }
        public bool SingleToggle2 { get; set; }
        public bool SingleToggle3 { get; set; }
        public bool SingleToggle4 { get; set; }
        public bool SingleToggle5 { get; set; }
        public bool SingleToggle6 { get; set; }
        public bool SingleToggle7 { get; set; }
        public bool SingleToggle8 { get; set; }
        public List<WrittenCommunication> WrittenCommunications { get; set; }
        public List<CommentsTab> CommentsTab { get; set; }

        public bool HasAttachment { get; set; }


        //Umbrella protocol

        public string? problemDescription { get; set; }
        public string? TeamComposition { get; set; }
        public string? InvestivationObjective { get; set; }
        public string? ProjectSupporting { get; set; }
        public string? DataForCollection { get; set; }
        public string? AnticipatedScope { get; set; }
        public string? ReportingRecommendations { get; set; }
        public string? ImprovementDescription { get; set; }
        public string? Research_orNon { get; set; }
        public string? TargetPopulation { get; set; }
        public string? CDCRole { get; set; }

        //Section 2
        public string Outbreakstart { get; set; }
        public string ValidityDate1 { get; set; }
        public string DateOutbreakEnd { get; set; }
        public string ValidityDate3 { get; set; }
        public string Outbreakdetection { get; set; }
        public string ValidityDate2 { get; set; }
        public string ValidityDate4 { get; set; }
        public string ValidityDate5 { get; set; }
        public string ValidityDate6 { get; set; }
        public string Setting { get; set; }
        public string SettingOther { get; set; }
        public string DiseaseSuspected { get; set; }
        public string DiseaseSuspected1 { get; set; }
        public string InitialCases { get; set; }
        public string Country { get; set; }
        public string WHORegion { get; set; }
        public string City { get; set; }
        public string deployment { get; set; }
        public string ObjectiveDeployment { get; set; }
        public string ResidentsDeployed { get; set; }
        public string NumberofGraduatesDeployed { get; set; }
        public string OutbreakReporting { get; set; }
        public string PublicHealthResponse { get; set; }
        public DateTime? LaboratoryConfirmation { get; set; }
        public bool ChildLs5 { get; set; }
        public bool CurrentORpostGraduate { get; set; }
        public bool ChildGr5 { get; set; }
        public bool Adults { get; set; }
        public bool Elderly { get; set; }
        //Section 3
        public string HIVStatus { get; set; }
        public string PEPFARFunded { get; set; }
        public string ART { get; set; }
        public string ART1 { get; set; }
        public string PMTCT { get; set; }
        public string PMTCT1 { get; set; }
        public string TBHIV { get; set; }
        public string TBHIV1 { get; set; }
        public string ProjectTravel { get; set; }
        public string KeyPopulations { get; set; }
        public string KeyPopulations1 { get; set; }
        public bool PWID { get; set; }
        public bool MSM { get; set; }
        public bool FSW { get; set; }
        public bool Transgender { get; set; }
        public bool Migrants { get; set; }
        public bool Prisoners { get; set; }
        public string PEPFAROversight { get; set; }
        public bool DATIM { get; set; }
        public bool DATIM1 { get; set; }
        public bool DQASQA { get; set; }
        public bool DQASQA1 { get; set; }
        public bool EA { get; set; }
        public bool EA1 { get; set; }
        public bool SIMS { get; set; }
        public bool SIMS1 { get; set; }
        public bool PEPFARMigrants { get; set; }
        public bool PEPFARMonitoring { get; set; }
        public bool PEPFARNoReply { get; set; }
        public string ResponseToDatRequest { get; set; }
        public string ProjHIVMonitoring { get; set; }
        public string HIVDataRequest { get; set; }
        public string AddAyPopulation { get; set; }
        public string AddPopulation { get; set; }
        public string Stigma { get; set; }
        public string HIVStigma { get; set; }
        public string Dropdown { get; set; }

        //Section 4
        public bool RoutineSurveillance { get; set; }
        public bool MasMedia { get; set; }
        public bool Rumors { get; set; }
        public bool ClinicianReport { get; set; }
        public bool OtherSpecify { get; set; }
        public string FinalOutcome { get; set; }
        public string DiseaseFinal { get; set; }
        public string DateInitialFindings { get; set; }
        public string WrittenDocumentAvailable { get; set; }
        public string DateFirstPublic { get; set; }
        public string OutbreakInvestigation { get; set; }
        public bool Children5 { get; set; }
        public bool Children511 { get; set; }
        public bool Children1219 { get; set; }
        public bool Children2060 { get; set; }
        public bool Children61 { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public bool FtoM { get; set; }
        public float DaysinField { get; set; }
        public float FinalNumberAffect { get; set; }
        public bool MtoF { get; set; }
        public string EndDateofActivity { get; set; }
        public string ONEHealth1 { get; set; }
        public string ONEHealth2 { get; set; }
        public string questionnaires { get; set; }
        public bool DataSpecimensCollected { get; set; }
        public bool FocusGroupDataCollected { get; set; }
        public bool DataFromRoutineSurveillance { get; set; }
        public bool AdministrativeInformation { get; set; }
        public bool DataHealthFacilities { get; set; }
        public bool DataUnlinkedAnonymous { get; set; }
        public bool DataDeceasedPersons { get; set; }
        public bool DataVertebrateAnimals { get; set; }
        public string author  { get; set; } 

    }

    public class WrittenCommunication
    {
        public string GlobalRecordId { get; set; }

        public string Att_FileName { get; set; }
        public string Report_Title { get; set; }
        public string TypeOfReport { get; set; }
        public string File_Att { get; set; }
        public string ContentType { get; set; }
        public string FileSize { get; set; }
        public string SuspectedDisease { get; set; }
        public string RequiredCommunication { get; set; }
        public string Accepted { get; set; }
        public string FullCitation { get; set; }
        public string ResidentName { get; set; }
        public string SubmittedTo { get; set; }
        public string DateofSubmission { get; set; }
        public bool CurrentResident { get; set; }

        public WrittenCommunication()
        {
        }

        public WrittenCommunication(string title, string suspectedDisease, string type, string att_FileName, string fType, string fSize, string fContent, string residentName, string citation, string submittedTo, string dateofsub, string req, string acc)
        {
            Report_Title = title;
            SuspectedDisease = suspectedDisease;
            TypeOfReport = type;
            Att_FileName = att_FileName;
            ContentType = fType;
            FileSize = fSize;
            File_Att = fContent;
            ResidentName = residentName;
            FullCitation = citation;
            SubmittedTo = submittedTo;
            DateofSubmission = dateofsub;
            RequiredCommunication = req;
            Accepted = acc;
        }
    }
    public class CommentsTab
    {
        public string commentText { get; set; }
        public string commentDate { get; set; }
        public string CommentName { get; set; }
        public string projectID { get; set; }


        public CommentsTab()
        {
        }

        public CommentsTab(string title)
        {
            commentText = title;
        }
    }
    public class ListIntermediateResidentData
    {
        public List<IntermediateResidentData> intermediateResidents { get; set; }
    }
    public class chartData
    {
        public int NoOfProjects { get; set; }
        public string projectclassification { get; set; }
        public string Yearr { get; set; }
    }
}
