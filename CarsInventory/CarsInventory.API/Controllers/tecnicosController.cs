using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    public class tecnicosController
    {
        [ApiController]
        [Route("/api/tecnicos")]
        public class TecnicosController : ControllerBase
        {
            private readonly DataContext _context;

            public TecnicosController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.tecnicos.ToListAsync());
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {
                var tecnicos = await _context.tecnicos.FirstOrDefaultAsync(c => c.Id == id);

                if (tecnicos == null)
                {
                    return NotFound();
                }

                return Ok(tecnicos);
            }

            // Insertar
            [HttpPost]
            public async Task<ActionResult> Post(Tecnico tecnicos)
            {
                _context.tecnicos.Add(tecnicos);
                await _context.SaveChangesAsync();
                return Ok(tecnicos);
            }

            // Actualizar
            [HttpPut]
            public async Task<ActionResult> Put(Tecnico tecnicos)
            {
                _context.tecnicos.Update(tecnicos);
                await _context.SaveChangesAsync();
                return Ok(tecnicos);
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var afectado = await _context.tecnicos
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
