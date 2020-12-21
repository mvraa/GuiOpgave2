using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GuiEksamen.Data;
using GuiEksamen.Models.DTOs;
using GuiEksamen.Models.Entities;
using GuiEksamen.Utilities;
using static BCrypt.Net.BCrypt;

namespace GuiEksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public UserController(ApplicationDbContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EfUser>>> GetManagers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EfUser>> GetManager(long id)
        {
            var manager = await _context.Users.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }

        // PUT: api/User/[id]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(long id, EfUser manager)
        {
            if (id != manager.EfUserId)
            {
                return BadRequest();
            }

            // Check if new email
            var old = await _context.Users.FindAsync(manager.EfUserId);
            if (old.Email != manager.Email)
{
                // Update account
                var account = await _context.Accounts.FindAsync(manager.EfAccountId);
                account.Email = manager.Email;
            }

            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<EfUser>> PostManager(User managerDto)
        {
            if (managerDto == null)
                return BadRequest("No data!");

            var manager = new EfUser();

            manager.Email = managerDto.Email.ToLowerInvariant();
            var emailExist = await _context.Accounts.Where(u => u.Email == manager.Email)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            if (emailExist != null)
            {
                ModelState.AddModelError("Email", "Email already in use");
                return BadRequest(ModelState);
            }
            manager.FirstName = managerDto.FirstName;
            manager.LastName = managerDto.LastName;
            manager.Freq = managerDto.Freq;
            manager.Duration = managerDto.Duration;

            var account = new EfAccount()
            {
                Email = manager.Email,
                IsManager = true
            };
            account.PwHash = HashPassword(managerDto.Password, _appSettings.BcryptWorkfactor);
            manager.Account = account;
            _context.Accounts.Add(account);
            _context.Users.Add(manager);
            await _context.SaveChangesAsync();

            return Created(manager.EfUserId.ToString(), manager);
        }

        // DELETE: api/User/[id]
        [HttpDelete("{id}")]
        public async Task<ActionResult<EfUser>> DeleteManager(long id)
        {
            var manager = await _context.Users.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(manager.EfAccountId);
            _context.Accounts.Remove(account);
            _context.Users.Remove(manager);
            await _context.SaveChangesAsync();

            return manager;
        }

        private bool ManagerExists(long id)
        {
            return _context.Users.Any(e => e.EfUserId == id);
        }
    }
}
