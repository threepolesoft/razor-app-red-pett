using ReDpett_API.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal.RegisterModal
{
    public class PasscodeRequestModel
    {
        //public int country { get; set; }
        //public int program { get; set; }
        //public string passcodes { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public Passcode Data { get; set; }
    }
}
