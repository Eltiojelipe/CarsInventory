using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    public class serviciosController
    {
        [ApiController]
        [Route("/api/servicios")]
        public class ServiciosController : ControllerBase
        {
            private readonly DataContext _context;

            public ServiciosController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.servicios.ToListAsync());
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {
                var servicios = await _context.servicios.FirstOrDefaultAsync(c => c.Id == id);

                if (servicios == null)
                {
                    return NotFound();
                }

                return Ok(servicios);
            }

            // Insertar
            [HttpPost]
            public async Task<ActionResult> Post(Servicio servicios)
            {
                _context.servicios.Add(servicios);
                await _context.SaveChangesAsync();
                return Ok(servicios);
            }

            // Actualizar
            [HttpPut]
            public async Task<ActionResult> Put(Servicio servicios)
            {
                _context.servicios.Update(servicios);
                await _context.SaveChangesAsync();
                return Ok(servicios);
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var afectado = await _context.servicios
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
}
