using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    [ApiController]
    [Route("/api/propietarios")]
    public class propietariosController : ControllerBase
    {
        private readonly DataContext _context;

        public propietariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.propietarios.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var propietarios = await _context.propietarios.FirstOrDefaultAsync(c => c.Id == id);

            if (propietarios == null)
            {
                return NotFound();
            }

            return Ok(propietarios);
        }

        // Insertar
        [HttpPost]
        public async Task<ActionResult> Post(Propietario propietarios)
        {
            _context.propietarios.Add(propietarios);
            await _context.SaveChangesAsync();
            return Ok(propietarios);
        }

        // Actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Propietario propietarios)
        {
            _context.propietarios.Update(propietarios);
            await _context.SaveChangesAsync();
            return Ok(propietarios);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectado = await _context.propietarios
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
