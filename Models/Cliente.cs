using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeBarbeariaBack.Models
{
public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public List<Agendamento> agendamentosClientes { get; set; }
    }
}