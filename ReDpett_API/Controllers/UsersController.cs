using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using ReDpett_API.Service.Interface;

namespace ReDpett_API.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UsersController : ControllerBase
    {
        private REcontext _context;
        private readonly IPasswordHash _passwordHashService;
        private readonly IGenerateToken _tokenService;

        public UsersController(REcontext context, IPasswordHash passwordHashService, IGenerateToken tokenService)
        {
            _context = context;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }

        public User _user = new User();

        [HttpPost("register")]
        [AllowAnonymous]

        //Action method .First checks whether username already exists>If not saves the user in DB along with hashed password
        public async Task<ActionResult<User>> Register(Login request)
        {
            var exisitingUser = await _context.Users!.FirstOrDefaultAsync(user => user.username == request.username);

            if (exisitingUser != null)
            {
                return BadRequest("Username already exists");
            }
            else
            {
                _passwordHashService.HashPassword(request.password!, out byte[] passwordHash, out byte[] passwordSalt);

                _user.username = request.username;
                _user.passwordHash = passwordHash;
                _user.passwordSalt = passwordSalt;
                _user.role = request.role;
                _user.email = request.mail;
                _context.Users!.Add(_user);
                await _context.SaveChangesAsync();
                return Ok(_user);

            }
        }

        [AllowAnonymous]

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {

            var exisitingUser = await _context.Users!.FirstOrDefaultAsync(user => user.username == request.username);

            if (exisitingUser == null)
            {
                return BadRequest("User not found");
            }
            else if (!_passwordHashService.VerifyPasssword(request.password, exisitingUser.passwordHash, exisitingUser.passwordSalt))
            {
                return BadRequest("Incorrect password");
            }
            else
            {

                var userToken = _tokenService.GenerateAccessToken(exisitingUser);
                var refreshToken = _tokenService.GenerateRefreshToken();
                await _tokenService.SetRefreshToken(refreshToken, Response);

                exisitingUser.refreshToken = refreshToken.Token;
                exisitingUser.dateCreated = refreshToken.Created;
                exisitingUser.tokenExpires = refreshToken.Expires;

                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Success",
                    token = userToken
                });
            }

        }


        [HttpGet("protected")]
        [Authorize(Roles = "admin")]
        public string ProtectedAPI()
        {

            return "Protected Resource.You are authorized to access this resource";
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];



            var existinguser = await _context.Users!.FirstOrDefaultAsync(user => user.refreshToken == refreshToken);


            if (existinguser == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (existinguser.tokenExpires < DateTime.Now)
            {
                return Unauthorized("Token Expired");
            }
            else
            {
                string token = _tokenService.GenerateAccessToken(existinguser);
                var newRefreshToken = _tokenService.GenerateRefreshToken();
                await _tokenService.SetRefreshToken(newRefreshToken, Response);
                return Ok(token);
            }
        }

    }
}