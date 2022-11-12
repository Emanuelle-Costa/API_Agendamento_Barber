using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Cliente : Pessoa 
    {
        public string Email { get; set; }
       
        public string Senha { get; set; }

        public IEnumerable<Agenda> Agendas { get; set; }

        public IEnumerable<ClienteProfissional> ClientesProfissionais { get; set; }
    }
}