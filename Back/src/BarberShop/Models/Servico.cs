using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public class Servico
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public DateTime? InicioServiço { get; set; }

        public DateTime? FimServiço { get; set; }

        public Guid ProfissionalId { get; set; }

        public Profissional Profissional { get; set; }

        public IEnumerable<ServicoProfissional> ServicosProfissionais { get; set; }
    }
}