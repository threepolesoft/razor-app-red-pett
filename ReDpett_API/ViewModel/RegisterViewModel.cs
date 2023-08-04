using Microsoft.AspNetCore.Mvc.Rendering;
using ReDpett_API.Modal;
using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.ViewModel
{
    public class RegisterViewModel
    {
        public int RegisterID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public List<Country> Country { get; set; }
        public List<Roles> Role { get; set; }        
        public List<FETPProgram> FETPPrograms { get; set; }
        public List<ResidentType> ResidentTYpe { get; set; }
        public string? Passcode { get; set; }
    }
}
