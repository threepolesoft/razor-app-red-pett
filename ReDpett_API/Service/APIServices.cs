using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReDpett_API.Modal;
using ReDpett_API.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ReDpett_API.Service
{
    public class APIServices
    {
        private readonly REcontext _context;

        public APIServices()
        {
        }

        //Service to generate Access Token
        public async Task<List<Roles>> GetRoles()
        {
            var result = await _context.ROles.ToListAsync();
            return result;
        }

        //Service to generate refresh Token

    }
}