using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace BarberShop.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public int? ProfissionalId { get; set; }

        public Profissional Profissional { get; set; }

        public int? ClinteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}