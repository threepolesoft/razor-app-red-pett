using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Common.Modal.Settings
{
    public class ProgramInfoVM
    {
        public string Nationality { get; set; } = string.Empty;
        public string FETP { get; set; } = string.Empty;
        public string CohortNumber { get; set; } = string.Empty;
        public string FETPTrack { get; set; } = string.Empty;
        public string CohortTrainingBegan { get; set; } = string.Empty;
        public string QualifyingDegree { get; set; } = string.Empty;
        public string Mentor1 { get; set; } = string.Empty;
        public string Mentor2 { get; set; } = string.Empty;
    }
}
