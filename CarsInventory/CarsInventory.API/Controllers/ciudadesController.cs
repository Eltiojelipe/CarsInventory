using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    public class ciudadesController
    {
        [ApiController]
        [Route("/api/ciudades")]
        public class CiudadesController : ControllerBase
        {
            private readonly DataContext _context;

            public CiudadesController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.ciudades.ToListAsync());
            }

            [HttpGet("{Id:int}")]
            public async Task<ActionResult> Get(int Id)
            {
                var Ciudad = await _context.ciudades.FirstOrDefaultAsync(c => c.Id == Id);

                if (Ciudad == null)
                {
                    return NotFound();
                }

                return Ok(Ciudad);
            }

            // Insertar
            [HttpPost]
            public async Task<ActionResult> Post(Ciudad ciudades)
            {
                _context.ciudades.Add(ciudades);
                await _context.SaveChangesAsync();
                return Ok(ciudades);
            }

            // Actualizar
            [HttpPut]
            public async Task<ActionResult> Put(Ciudad ciudades)
            {
                _context.ciudades.Update(ciudades);
                await _context.SaveChangesAsync();
                return Ok(ciudades);
            }

            [HttpDelete("{Id:int}")]
            public async Task<ActionResult> Delete(int Id)
            {
                var afectado = await _context.ciudades
                    .Where(x => x.Id == Id)
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
