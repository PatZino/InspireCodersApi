using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspireCodersApi.Data;
using InspireCodersApi.Models.Applications;

namespace InspireCodersApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly applicationDbContext _context;

        public ApplicationsController(applicationDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplication()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(long id)
        {
            var application = await _context.Applications.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: Applications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(long id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: Applications
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: Applications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> DeleteApplication(long id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return application;
        }

        private bool ApplicationExists(long id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}