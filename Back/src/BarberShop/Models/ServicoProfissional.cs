using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public class ServicoProfissional
    {
        public int ServicoId { get; set; }

        public Cliente Servico { get; set; }

        public Guid ProfissionalId { get; set; }

        public Profissional Profissional { get; set; }
    }
}