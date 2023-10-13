using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/asegurados")]
    public class aseguradosController : ControllerBase
    {
        private readonly DataContext _context;

        public aseguradosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.asegurados.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var clienteAsegurado = await _context.asegurados.FirstOrDefaultAsync(c => c.Id == id);

            if (clienteAsegurado == null)
            {
                return NotFound();
            }

            return Ok(clienteAsegurado);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(clienteAsegurado asegurado)
        {
            _context.asegurados.Add(asegurado);
            await _context.SaveChangesAsync();
            return Ok(asegurado);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(clienteAsegurado asegurado)
        {
            _context.asegurados.Update(asegurado);
            await _context.SaveChangesAsync();
            return Ok(asegurado);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.asegurados
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
