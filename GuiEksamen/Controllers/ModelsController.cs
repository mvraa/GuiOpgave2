﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Authorize(Roles = "Manager")]
    public class ModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public ModelsController(ApplicationDbContext context,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EfModel>>> GetModels()
        {
            return await _context.Models.ToListAsync();
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EfModel>> GetModel(long id)
        {
            var model = await _context.Models.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(long id, EfModel model)
        {
            if (id != model.EfModelId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        [HttpPost]
        public async Task<ActionResult<EfModel>> PostModel(ModelDetails modelDto)
        {
            modelDto.Email = modelDto.Email.ToLower();
            var emailExist = await _context.Accounts.Where(u => u.Email == modelDto.Email).FirstOrDefaultAsync();
            if (emailExist != null)
            {
                ModelState.AddModelError("Email", "Email already in use");
                return BadRequest(ModelState);
            }
            // UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            var model = _mapper.Map<EfModel>(modelDto);
            
            var account = new EfAccount()
            {
                Email = model.Email,
                IsManager = false
            };
            account.PwHash = HashPassword(modelDto.Password, _appSettings.BcryptWorkfactor);
            model.Account = account;
            _context.Accounts.Add(account);
            _context.Models.Add(model);
            await _context.SaveChangesAsync();

            return Created(model.EfModelId.ToString(), model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EfModel>> DeleteModel(long id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return model;
        }

        private bool ModelExists(long id)
        {
            return _context.Models.Any(e => e.EfModelId == id);
        }
    }
}