using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    public class personaController
    {
        [ApiController]
        [Route("/api/personas")]
        public class personasController : ControllerBase
        {
            private readonly DataContext _context;

            public personasController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.personas.ToListAsync());
            }

            [HttpGet("{cedulaId:string}")]
            public async Task<ActionResult> Get(string cedulaId)
            {
                var Persona = await _context.personas.FirstOrDefaultAsync(c => c.cedulaId == cedulaId);

                if (Persona == null)
                {
                    return NotFound();
                }

                return Ok(Persona);
            }

            // Insertar
            [HttpPost]
            public async Task<ActionResult> Post(Persona personas)
            {
                _context.personas.Add(personas);
                await _context.SaveChangesAsync();
                return Ok(personas);
            }

            // Actualizar
            [HttpPut]
            public async Task<ActionResult> Put(Persona personas)
            {
                _context.personas.Update(personas);
                await _context.SaveChangesAsync();
                return Ok(personas);
            }

            [HttpDelete("{cedulaId:string}")]
            public async Task<ActionResult> Delete(string cedulaId)
            {
                var afectado = await _context.personas
                    .Where(x => x.cedulaId == cedulaId)
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
