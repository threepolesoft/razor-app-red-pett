using System.ComponentModel;

namespace ReDpett_API.Modal
{
    public class Passcode
    {
        public int Id { get; set; }
        public int Country { get; set; }
        public int Program { get; set; }
        [DisplayName("Passcodes")]
        public string Passcodes { get; set; }
        public string EmailAssociated { get; set; }
    }
}
