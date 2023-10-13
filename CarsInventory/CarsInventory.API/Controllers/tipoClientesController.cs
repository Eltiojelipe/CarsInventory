using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/tipoClientes")]
    public class tipoClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public tipoClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.tipoClientes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var tipoClientes = await _context.tipoClientes.FirstOrDefaultAsync(c => c.Id == id);

            if (tipoClientes == null)
            {
                return NotFound();
            }

            return Ok(tipoClientes);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(tipoCliente tipoClientes)
        {
            _context.tipoClientes.Add(tipoClientes);
            await _context.SaveChangesAsync();
            return Ok(tipoClientes);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(tipoCliente tipoClientes)
        {
            _context.tipoClientes.Update(tipoClientes);
            await _context.SaveChangesAsync();
            return Ok(tipoClientes);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.tipoClientes
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
