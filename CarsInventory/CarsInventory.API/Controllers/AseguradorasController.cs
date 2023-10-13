using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/Aseguradoras")]
    public class AseguradorasController : ControllerBase
    {
        private readonly DataContext _context;

        public AseguradorasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Aseguradoras.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Aseguradora = await _context.Aseguradoras.FirstOrDefaultAsync(c => c.Id == id);

            if (Aseguradora == null)
            {
                return NotFound();
            }

            return Ok(Aseguradora);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(Aseguradora evento)
        {
            _context.Aseguradoras.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Aseguradora evento)
        {
            _context.Aseguradoras.Update(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.Aseguradoras
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
