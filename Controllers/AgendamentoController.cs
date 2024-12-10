using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeBarbeariaBack.Data;
using SistemaDeBarbeariaBack.Models;


namespace SistemadeBarbeariaBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public AgendamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _context.Agendamentos.Include(a => a.cliente).Include(a => a.barbeiro).Include(a => a.servicos).ToListAsync();
            return Ok(agendamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = agendamento.AgendamentoId }, agendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoId) return BadRequest();
            _context.Entry(agendamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _context.Agendamentos.Include(a => a.cliente).Include(a => a.barbeiro).Include(a => a.servicos).FirstOrDefaultAsync(a => a.AgendamentoId == id);
            if (agendamento == null) return NotFound();
            return Ok(agendamento);
        }
    }
}
