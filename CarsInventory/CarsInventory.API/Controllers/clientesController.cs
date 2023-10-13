﻿using CarsInventory.API.Data;
using CarsInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Controllers
{
    public class clientesController
    {
        [ApiController]
        [Route("/api/clientes")]
        public class ClientesController : ControllerBase
        {
            private readonly DataContext _context;

            public ClientesController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.clientes.ToListAsync());
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {
                var cliente = await _context.clientes.FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }

            // Insertar
            [HttpPost]
            public async Task<ActionResult> Post(Cliente clientes)
            {
                _context.clientes.Add(clientes);
                await _context.SaveChangesAsync();
                return Ok(clientes);
            }

            // Actualizar
            [HttpPut]
            public async Task<ActionResult> Put(Cliente clientes)
            {
                _context.clientes.Update(clientes);
                await _context.SaveChangesAsync();
                return Ok(clientes);
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var afectado = await _context.clientes
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
