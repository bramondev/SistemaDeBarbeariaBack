using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeBarbeariaBack.Models
{
   public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public DateTime HorarioData { get; set; }
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }
        public int BarbeiroId { get; set; }
        public Barbeiro barbeiro { get; set; }
        public int ServicoId { get; set; }
        public Servicos servicos { get; set; }
      
    }
}