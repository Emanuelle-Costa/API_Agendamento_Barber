using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public class Profissional : Pessoa
    {
        public string ImagemURL { get; set; } 

        public string Instagram { get; set; }

        public  IEnumerable<Servico> Servicos { get; set; }

        public IEnumerable<Agenda> Agendas { get; set; }

        public IEnumerable<ClienteProfissional> ClientesProfissionais { get; set; }

        public IEnumerable<ServicoProfissional> ServicosProfissionais { get; set; }
    }
}