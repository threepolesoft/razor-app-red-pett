using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace ReDpett_API.Modal
{
    public class Login
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "User Name is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? username { get; set; }
        public string? role { get; set; }
        public string? refreshToken { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime tokenExpires { get; set; }
        public string? UserAccessToken { get; set; }
   
        //public string? Passcode { get; set;}
        //public int? roleId { get; set; }
        //public string? ResidentPascode { get; set; }

    }
}
