using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using ReDpett_API.Service.Interface;
using ReDpett_API.Service.Repository;

namespace ReDpett_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly REcontext _context;
        private readonly IPasswordHash _passwordHashService;
        private readonly IGenerateToken _tokenService;
        public RegistersController(REcontext context, IPasswordHash passwordHashService, IGenerateToken tokenService)
        {
            _context = context;
            _passwordHashService = passwordHashService;
            _tokenService = tokenService;
        }

        // GET: api/Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            return await _context.Registers.ToListAsync();
        }
        [HttpGet("GetGender")]
        public async Task<ActionResult<List<string>>> GetGender()
        {
            return await _context.codegender1.Select(x => x.Name).ToListAsync();
        }
        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(int id)
        {
            var register = await _context.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }
        [HttpGet("GetRegisteredUser/{email}")]
        public Register GetRegisteredUser(string email)
        {
            var register = _context.Registers.FirstOrDefault(x => x.Email == email);
            return register;
        }

        [HttpGet("GetRoles/{id}")]
        public Roles GetRole(int id)
        {
            var role = _context.ROles.FirstOrDefault(x => x.RoleId == id);
            return role;
        }

        [HttpGet("GetResidentType/{id}")]
        public ResidentType GetResident(int id)
        {
            var resident = _context.ResidentTypes.FirstOrDefault(x => x.Id == id);
            return resident;
        }
        [AllowAnonymous]
        [Route("/Login")]
        [HttpPost()]//("{Email}/{Password}/{Passcode}")]
        public async Task<ActionResult<Register>> CheckLogin([FromBody] LoginRequesModel content)//string Email,string Password,string Passcode)//[FromBody]Register reg)
        {
            try
            {
                LoginRequesModel reg = content;
                string Email = reg.Email; string Password = reg.Password.ToString(); //string Passcode = reg.Passcode.ToString();
                var registers = _context.Registers.ToList();
                var checkPasscode = _context.Registers.FirstOrDefault(x => x.Email == Email);
                Login lgn = new Login();
                lgn.Email = Email;
                lgn.username = checkPasscode.Name;
                lgn.Password = checkPasscode.Password.ToString();
                lgn.role = _context.ROles.FirstOrDefault(x => x.RoleId == checkPasscode.RoleId).RoleName;// checkPasscode.RoleName;


                if (checkPasscode != null)
                {///Helper.Hasher.HashPassword(TPaswrd.Text)
                    if (Helper.Hasher.ValidatePassword(Password, checkPasscode.Password))//checkPasscode.Password==Password) //_context.Registers.FirstOrDefault(x=>x.Email==Email);
                    {
                        //return Ok("Login Success..");
                        //Added Refresh Token and Accesstoken
                        var userToken = _tokenService.GenerateAccessToken(lgn);
                        var refreshToken = _tokenService.GenerateRefreshToken();
                        await _tokenService.SetRefreshToken(refreshToken, Response);

                        lgn.refreshToken = refreshToken.Token;
                        lgn.dateCreated = refreshToken.Created;
                        lgn.tokenExpires = refreshToken.Expires;
                        lgn.UserAccessToken = userToken;

                        // lgn.Passcode = checkPasscode.Passcode;

                        //if (!string.IsNullOrEmpty(checkPasscode?.ResidentPasscode))
                        //{
                        //    lgn.ResidentPascode = checkPasscode?.ResidentPasscode;

                        //}
                        //lgn.roleId = checkPasscode?.RoleId;
                        //await _context.SaveChangesAsync();

                        //

                        LoginResponseModel loginResponseModel = new LoginResponseModel();
                        loginResponseModel.dateCreated = refreshToken.Created;
                        loginResponseModel.tokenExpires = refreshToken.Expires;
                        loginResponseModel.UserAccessToken = userToken;
                        loginResponseModel.Passcode = checkPasscode.Passcode;
                        loginResponseModel.ResidentPascode = checkPasscode?.ResidentPasscode;
                        loginResponseModel.roleId = checkPasscode?.RoleId;
                        loginResponseModel.role = lgn.role;
                        loginResponseModel.username = checkPasscode?.Name + " " + checkPasscode.LastName;
                        loginResponseModel.refreshToken = refreshToken?.Token;
                        loginResponseModel.NonResidentId = checkPasscode.NonResidentId;
                        loginResponseModel.FETPProgramId = checkPasscode.FETPProgramId;
                        loginResponseModel.CountryId = checkPasscode.Country;
                        loginResponseModel.Country = checkPasscode.Country;
                        loginResponseModel.Region = checkPasscode.Region;
                        loginResponseModel.FETP = checkPasscode.FETP;
                        //var country = _context.Country.FirstOrDefault(x => x.Id == checkPasscode.CountryId).Name;
                        //loginResponseModel.CountryId = country;
                        _context.Logins.Add(lgn);
                        await _context.SaveChangesAsync();
                        return Ok(new
                        {
                            status = true,
                            message = "Logged in successfully",
                            Data = loginResponseModel
                        });
                        //
                    }
                    else
                    {
                        LoginResponseModel loginResponseModel = new LoginResponseModel();

                        return Ok(new
                        {
                            status = false,
                            message = "Either username or password is incorrect \r\n\r\n",
                            Data = loginResponseModel
                        });
                        //return NotFound("Wrong Password");
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = false,
                        message = "No User Found \r\n\r\n",
                        Data = ""
                    });
                    //return NotFound("No User Found");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("protected")]
        [Authorize(Roles = "Non-Residnet")]
        public string ProtectedAPI()
        {

            return "Protected Resource.You are authorized to access this resource";
        }
        // PUT: api/Registers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(int id, Register register)
        {
            if (id != register.RegisterID)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [Route("/FindResidents")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> FindResidents(string id)
        {
            string passcode = id;
            var register = _context.Registers.ToListAsync().Result.Where(i => i.Passcode == passcode).ToList();

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }
        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            try
            {
                var checkUniqueEmail = _context.Registers.FirstOrDefault(x => x.Email == register.Email);
                if (checkUniqueEmail == null)
                {

                }
                else
                {
                    return Ok(new
                    {
                        status = false,
                        message = "Duplicate Email Found \r\n\r\n",
                        Data = ""
                    });
                }


                OrganizationPasscode orgPasscode = new OrganizationPasscode();

                Passcode passcodes = new Passcode();

                if (register.RoleId == 4)
                {
                    if (register.NonResidentId == 2)
                    {
                        var checkIfPasscode = _context.Registers.Where(x => x.CountryId == register.CountryId
                                        && x.FETPProgramId == register.FETPProgramId
                                      ).FirstOrDefault();

                        //if (checkIfPasscode != null)
                        //{
                        //    return Ok(new
                        //    {
                        //        status = false,
                        //        message = "Passcode already created for selected country and program  \r\n\r\n." + checkIfPasscode.Passcode,
                        //        Data = ""
                        //    });


                        //}

                        var NEWcheckIfPasscode = _context.Passcodes.Where(x => x.Country == register.CountryId
                              && x.Program == register.FETPProgramId
                            ).FirstOrDefault();

                        if (checkIfPasscode != null)
                        {


                        }
                        else
                        {
                            Passcode passcode = new Passcode();
                            passcode.EmailAssociated = register.Email;
                            passcode.Program = register.FETPProgramId;
                            passcode.Country = register.CountryId;
                            passcode.Passcodes = register.Passcode;
                            _context.Passcodes.Add(passcode);
                            await _context.SaveChangesAsync();
                        }

                    }

                    var getpassVaidatedForNonResident = _context.OrganizationPasscode.Where(x => x.Country == register.CountryId
                              && x.Program == register.FETPProgramId && x.Passcodes == register.Passcode).FirstOrDefault();


                    //if (getpassVaidatedForNonResident != null)
                    //{
                    register.Password = Helper.Hasher.HashPassword(register.Password);
                    _context.Registers.Add(register);
                    await _context.SaveChangesAsync();
                    //return CreatedAtAction("GetRegister", new { id = register.RegisterID }, register);
                    return Ok(new
                    {
                        status = true,
                        message = "Successfully Registered \r\n\r\n",
                        Data = ""
                    });


                    //}
                    //else
                    //{
                    //    return Ok(new
                    //    {
                    //        status = false,
                    //        message = "Passcode entered mismatched with the selected country and program \r\n\r\n",
                    //        Data = ""
                    //    });

                    //}

                }
                else
                {
                    //Reg for Resident

                    //var getpasscodesVaidated = _context.Passcodes.Where(x => x.Country == register.CountryId
                    //&& x.Program == register.FETPProgramId
                    //&& x.Passcodes == register.Passcode).FirstOrDefault();

                    //if (getpasscodesVaidated != null)
                    //{
                    register.Password = Helper.Hasher.HashPassword(register.Password);
                    _context.Registers.Add(register);
                    await _context.SaveChangesAsync();
                    //return CreatedAtAction("GetRegister", new { id = register.RegisterID }, register);
                    return Ok(new
                    {
                        status = true,
                        message = "Successfully Registered \r\n\r\n",
                        Data = ""
                    });


                    //}
                    //else
                    //{
                    //    return Ok(new
                    //    {
                    //        status = false,
                    //        message = "Passcode entered mismatched with the selected country and program \r\n\r\n",
                    //        Data = ""
                    //    });


                    //}

                }
            }
            catch (Exception ex)
            {

                throw;
            }




        }

        // DELETE: api/Registers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegister(int id)
        {
            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("GetFETP")]
        public List<string> GetFETP()
        {
            var data = _context.codefieldsites123university_training.Select(x => x.FETP).ToList();
            data = data.Distinct().ToList();
            return data;
        }

        [HttpGet("GetFETPTrack")]
        public List<string> GetFETPTrack()
        {
            var data = _context.codefetptrack1.Select(x => x.fetptrack).ToList();
            return data;
        }

        [HttpGet("GetFETPLevel/{fetp}")]
        public async Task<string> GetFETPLevel(string fetp)
        {
            var data = await _context.codefieldsites123university_training.Where(x => x.FETP == fetp).FirstOrDefaultAsync();
            var res = data.FETPLevel;
            return res;
        }
        [HttpGet("GetUniversityTraining/{fetp}")]
        public async Task<IActionResult> GetUniversityTraining(string fetp)
        {
            var data = await _context.codefieldsites123university_training.Where(x => x.FETP == fetp).Select(x => x.University_Training).Distinct().ToListAsync();
            return new JsonResult(data);
        }

        [HttpGet("GetQualifyingDegree")]
        public List<string> GetQualifyingDegree()
        {
            var data = _context.codequalifyingdegree1.Select(x => x.qualifyingdegree).ToList();
            return data;
        }
        private bool RegisterExists(int id)
        {
            return _context.Registers.Any(e => e.RegisterID == id);
        }
    }
}
