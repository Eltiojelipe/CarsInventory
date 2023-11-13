using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/vehiculos")]
    public class vehiculosController : ControllerBase
    {
        private readonly DataContext _context;

        public vehiculosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.vehiculos.ToListAsync());
        }

        [HttpGet("{placaVh:string}")]
        public async Task<ActionResult> Get(string placaVh)
        {
            var vehiculos = await _context.vehiculos.FirstOrDefaultAsync(c => c.placaVh == placaVh);

            if (vehiculos == null)
            {
                return NotFound();
            }

            return Ok(vehiculos);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(Vehiculo vehiculos)
        {
            _context.vehiculos.Add(vehiculos);
            await _context.SaveChangesAsync();
            return Ok(vehiculos);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Vehiculo vehiculos)
        {
            _context.vehiculos.Update(vehiculos);
            await _context.SaveChangesAsync();
            return Ok(vehiculos);
        }

        [HttpDelete("{placaVh:string}")]
        public async Task<ActionResult> Delete(string placaVh)
        {
            var afectado = await _context.vehiculos
                .Where(x => x.placaVh == placaVh)
                .ExecuteDeleteAsync();

            if (afectado == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
