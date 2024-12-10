using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemadeBarbeariaBack.Data;
using SistemaDeBarbeariaBack.Models;

namespace SistemaDeBarbeariaBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Clientes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null) return NotFound("Cliente não encontrado.");
        return Ok(cliente);
    }

    [HttpGet("search")]
    public IActionResult GetByName(string nome)
    {
        var clientes = _context.Clientes.Where(c => c.NomeCliente.Contains(nome)).ToList();
        if (!clientes.Any()) return NotFound("Nenhum cliente encontrado.");
        return Ok(clientes);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = cliente.IdCliente }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Cliente clienteAtualizado)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null) return NotFound("Cliente não encontrado.");

        cliente.NomeCliente = clienteAtualizado.NomeCliente;
        cliente.TelefoneCliente = clienteAtualizado.TelefoneCliente;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null) return NotFound("Cliente não encontrado.");

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
    }
}