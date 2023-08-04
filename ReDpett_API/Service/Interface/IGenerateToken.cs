using ReDpett_API.Modal;

namespace ReDpett_API.Service.Interface
{
    public interface IGenerateToken
    {
        public string GenerateAccessToken(Login user);
        public RefreshToken GenerateRefreshToken();
        public Task SetRefreshToken(RefreshToken newRefreshToken, HttpResponse Response);
    }
}
