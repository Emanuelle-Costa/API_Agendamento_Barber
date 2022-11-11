using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public class ClienteProfissional
    {
         public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int ProfissionalId { get; set; }

        public Profissional Profissional { get; set; }
    }
}