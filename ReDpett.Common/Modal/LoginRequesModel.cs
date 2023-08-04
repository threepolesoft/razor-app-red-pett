using System.ComponentModel.DataAnnotations;

namespace ReDpett_API.Modal
{
    public class LoginRequesModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password should have minimum eight characters, at least 1 upper case, 1 lower case, 1 digit, 1 special character.")]
        public string Password { get; set; }
        public string? Passcode { get; set; }
        public string? ResidentPasscode { get; set; }

    }  
    public class ChangePassRequesModel
    {
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password should have minimum eight characters, at least 1 upper case, 1 lower case, 1 digit, 1 special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password should have minimum eight characters, at least 1 upper case, 1 lower case, 1 digit, 1 special character.")]
        public string ConfirmPassword { get; set; }
    } 
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

       

    } 
    public class OTP
    {
        [Required(ErrorMessage = "OTP is required")]
        public string OTPCode { get; set; }
    }
}
