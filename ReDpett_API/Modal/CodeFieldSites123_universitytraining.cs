using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.Modal
{
    public class CodeFieldSites123_universitytraining
    {
        [Key]
        public int UniqueKey { get; set; }
        public string UniqueRowId { get; set; }

        public string GlobalRecordId { get; set; } = string.Empty;
        public string RECSTATUS { get; set; } = string.Empty;
        public string FKEY { get; set; } = string.Empty;
        public string University_Training { get; set; } = string.Empty;
        public string FETP { get; set; } = string.Empty;
        public string FETPLevel { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
}
