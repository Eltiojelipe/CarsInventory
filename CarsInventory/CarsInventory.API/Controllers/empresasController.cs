using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/empresas")]
    public class empresasController : ControllerBase
    {
        private readonly DataContext _context;

        public empresasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.empresas.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var empresas = await _context.empresas.FirstOrDefaultAsync(c => c.Id == id);

            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(Empresa empresas)
        {
            _context.empresas.Add(empresas);
            await _context.SaveChangesAsync();
            return Ok(empresas);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Empresa empresas)
        {
            _context.empresas.Update(empresas);
            await _context.SaveChangesAsync();
            return Ok(empresas);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.empresas
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
