using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeBarbeariaBack.Data;
using SistemaDeBarbeariaBack.Models;
using Microsoft.AspNetCore.Mvc;


namespace SistemaDeBarbeariaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeiroController : ControllerBase
    {
        private readonly DataContext _context;

        public BarbeiroController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Barbeiro
        [HttpGet]
        public IActionResult GetBarbeiros()
        {
            var barbeiros = _context.Barbeiros.ToList();
            if (!barbeiros.Any())
                return NoContent(); // Retorna 204 se não houver barbeiros cadastrados

            return Ok(barbeiros);
        }

        // GET: api/Barbeiro/5
        [HttpGet("{id}")]
        public IActionResult GetBarbeiro(int id)
        {
            var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.IdBarbeiro == id);
            if (barbeiro == null)
                return NotFound($"Barbeiro com ID {id} não encontrado.");

            return Ok(barbeiro);
        }

        // POST: api/Barbeiro
        [HttpPost]
        public IActionResult CreateBarbeiro([FromBody] Barbeiro barbeiro)
        {
            if (barbeiro == null)
                return BadRequest("Dados inválidos.");

            _context.Barbeiros.Add(barbeiro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBarbeiro), new { id = barbeiro.IdBarbeiro }, barbeiro);
        }

        // PUT: api/Barbeiro/5
        [HttpPut("{id}")]
        public IActionResult UpdateBarbeiro(int id, [FromBody] Barbeiro barbeiroAtualizado)
        {
            if (barbeiroAtualizado == null || barbeiroAtualizado.IdBarbeiro != id)
                return BadRequest("Dados inconsistentes.");

            var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.IdBarbeiro == id);
            if (barbeiro == null)
                return NotFound($"Barbeiro com ID {id} não encontrado.");

            // Atualiza os campos
            barbeiro.NomeBarbeiro = barbeiroAtualizado.NomeBarbeiro;
            barbeiro.Especialidade = barbeiroAtualizado.Especialidade;

            _context.Barbeiros.Update(barbeiro);
            _context.SaveChanges();

            return NoContent(); // Retorna 204 para indicar que a operação foi bem-sucedida
        }

        // DELETE: api/Barbeiro/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBarbeiro(int id)
        {
            var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.IdBarbeiro == id);
            if (barbeiro == null)
                return NotFound($"Barbeiro com ID {id} não encontrado.");

            _context.Barbeiros.Remove(barbeiro);
            _context.SaveChanges();

            return NoContent(); // Retorna 204 para indicar que o recurso foi removido
        }
    }
}
