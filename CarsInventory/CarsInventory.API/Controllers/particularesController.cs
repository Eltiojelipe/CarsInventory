using CarsInventory.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsInventory.Shared.Entities;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/particulares")]
    public class particularesController : ControllerBase
    {
        private readonly DataContext _context;

        public particularesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.particulares.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var clienteParticular = await _context.particulares.FirstOrDefaultAsync(c => c.Id == id);

            if (clienteParticular == null)
            {
                return NotFound();
            }

            return Ok(clienteParticular);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(clienteParticular particulares)
        {
            _context.particulares.Add(particulares);
            await _context.SaveChangesAsync();
            return Ok(particulares);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(clienteParticular particulares)
        {
            _context.particulares.Update(particulares);
            await _context.SaveChangesAsync();
            return Ok(particulares);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.particulares
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectado == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
