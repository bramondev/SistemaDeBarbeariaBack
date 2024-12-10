using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeBarbeariaBack.Models
{public class Barbeiro
    {
        public int IdBarbeiro { get; set; }
        public string NomeBarbeiro { get; set; }
        public string TelefoneBarbeiro { get; set; }
        public string Especialidade { get; set; }
        public List<Agendamento> agendamentosBarbeiro { get; set; }
    }
}