using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GuiEksamen.Data;
using GuiEksamen.Models.DTOs;
using GuiEksamen.Models.Entities;
using GuiEksamen.Utilities;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static BCrypt.Net.BCrypt;

namespace GuiEksamen.Controllers
{
    /// <summary>
    /// Use this API to login and change password.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public AccountController(ApplicationDbContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<Token>> Login([FromBody]Login login)
        {
            if (login != null)
            {
                login.Email = login.Email.ToLowerInvariant();
                var account = await _context.Accounts.Where(u => u.Email == login.Email)
                    .FirstOrDefaultAsync().ConfigureAwait(false);

                if (account != null)
                {
                    var validPwd = Verify(login.Password, account.PwHash);
                    if (validPwd)
                    {
                        var user = await _context.Managers.Where(m => m.Email == account.Email)
                            .FirstOrDefaultAsync().ConfigureAwait(false);

                        long userId = user.EfManagerId;

                        var jwt = GenerateToken(account.Email, userId, account.IsManager);
                        var token = new Token() { JWT = jwt };
                        return token;
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login");
            return BadRequest(ModelState);
        }

        [HttpPut("Password")]
        public async Task<ActionResult<Token>> ChangePassword([FromBody]Login login)
        {
            if (login == null)
            {
                ModelState.AddModelError(string.Empty, "Data missing");
                return BadRequest(ModelState);
            }
            login.Email = login.Email.ToLowerInvariant();
            var account = await _context.Accounts.Where(u => u.Email == login.Email)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (account == null)
            {
                ModelState.AddModelError("email", "Not found!");
                return BadRequest(ModelState);
            }
            var validPwd = Verify(login.OldPassword, account.PwHash);
            if (validPwd)
            {

                account.PwHash = HashPassword(login.Password, _appSettings.BcryptWorkfactor);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            else
            {
                ModelState.AddModelError("oldPassword", "No match");
                return BadRequest(ModelState);
            }
        }

        private string GenerateToken(string email, long modelId, bool isManager)
        {
            Claim roleClaim;
            if (isManager)
                roleClaim = new Claim(ClaimTypes.Role, "Manager");
            else
                roleClaim = new Claim(ClaimTypes.Role, "Model");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, email),
                roleClaim,
                new Claim("ModelId", modelId.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var token = new JwtSecurityToken(
                 new JwtHeader(new SigningCredentials(
                      new SymmetricSecurityKey(key),
                      SecurityAlgorithms.HmacSha256Signature)),
                      new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}