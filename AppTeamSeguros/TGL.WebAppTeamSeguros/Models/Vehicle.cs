using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Data;

namespace TGL.WebAppTeamSeguros.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Id = Guid.NewGuid();
            Insurance = new Insurance();
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Insurance Insurance { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }

    }
}
