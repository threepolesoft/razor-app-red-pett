using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal.Login
{
    public class LoginResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }        
        public ReDpett_API.Modal.Login Data { get; set; }
    }
}
