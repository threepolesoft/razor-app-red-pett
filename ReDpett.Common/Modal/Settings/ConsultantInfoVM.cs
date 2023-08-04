using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Common.Modal.Settings
{
    public class ConsultantInfoVM
    {     
        public string SurName { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool FETPAlumni { get; set; }
        public bool Mentor { get; set; }
        public bool Supervisor { get; set; }
        public bool ProgramOrLocalMgr { get; set; }
        public string PrimaryAffiliation { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string MailingAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
