using System.ComponentModel.DataAnnotations;

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
        public string? userAccessToken { get; set; }
        public string? passcode { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string FETP { get; set; }
        public string? residentPasscode { get; set; }

        public int fetpProgramId { get; set; }

    }
}
