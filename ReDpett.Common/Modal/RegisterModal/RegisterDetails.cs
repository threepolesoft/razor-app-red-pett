using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Modal.RegisterModal
{
    public class RegisterDetails
    {
        public int RegisterID { get; set; }

       
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public string? Email { get; set; }      
        
        public int CountryId { get; set; }       
        public int FETPProgramId { get; set; }        
        public int RoleId { get; set; }
        public int NonResidentId { get; set; }
       
    }
}
