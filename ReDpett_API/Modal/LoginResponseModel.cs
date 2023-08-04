namespace ReDpett_API.Modal
{
    public class LoginResponseModel
    {
        public string? role { get; set; }
        public string? username { get; set; }
        public string? refreshToken { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime tokenExpires { get; set; }
        public string? UserAccessToken { get; set; }
        public string? Passcode { get; set; }
        public string? CountryId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int? roleId { get; set; }
        public string? ResidentPascode { get; set; }
        public int NonResidentId { get; set; }

        public int FETPProgramId { get; set; }
        public string FETP { get; set; }

    }
}
