using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeBarbeariaBack.Models
{

    public class Servicos
    {
        public int IdServico { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public List<Agendamento> agendamentosServicos { get; set; }
    }
}



