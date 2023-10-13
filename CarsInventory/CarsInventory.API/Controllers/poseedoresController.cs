using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/poseedores")]
    public class poseedoresController : ControllerBase
    {
        private readonly DataContext _context;

        public poseedoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.poseedores.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var poseedores = await _context.poseedores.FirstOrDefaultAsync(c => c.Id == id);

            if (poseedores == null)
            {
                return NotFound();
            }

            return Ok(poseedores);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(Poseedor poseedores)
        {
            _context.poseedores.Add(poseedores);
            await _context.SaveChangesAsync();
            return Ok(poseedores);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Poseedor poseedores)
        {
            _context.poseedores.Update(poseedores);
            await _context.SaveChangesAsync();
            return Ok(poseedores);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.poseedores
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
