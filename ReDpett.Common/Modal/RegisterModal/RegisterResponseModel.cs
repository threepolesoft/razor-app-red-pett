using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal.RegisterModal
{
    public class RegisterResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Modal.Register Data { get; set; }
    }
}
