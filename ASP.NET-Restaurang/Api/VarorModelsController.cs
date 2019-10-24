using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using RestaurantLibrary;

namespace ASP.NET_Restaurang.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarorModelsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public VarorModelsController(OdeToFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/VarorModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VarorModel>>> GetVarorModel()
        {
            return await _context.VarorModel.ToListAsync();
        }

        // GET: api/VarorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VarorModel>> GetVarorModel(int id)
        {
            var varorModel = await _context.VarorModel.FindAsync(id);

            if (varorModel == null)
            {
                return NotFound();
            }

            return varorModel;
        }

        // PUT: api/VarorModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVarorModel(int id, VarorModel varorModel)
        {
            if (id != varorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(varorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VarorModelExists(id))
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

        // POST: api/VarorModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VarorModel>> PostVarorModel(VarorModel varorModel)
        {
            _context.VarorModel.Add(varorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVarorModel", new { id = varorModel.Id }, varorModel);
        }

        // DELETE: api/VarorModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VarorModel>> DeleteVarorModel(int id)
        {
            var varorModel = await _context.VarorModel.FindAsync(id);
            if (varorModel == null)
            {
                return NotFound();
            }

            _context.VarorModel.Remove(varorModel);
            await _context.SaveChangesAsync();

            return varorModel;
        }

        private bool VarorModelExists(int id)
        {
            return _context.VarorModel.Any(e => e.Id == id);
        }
    }
}
