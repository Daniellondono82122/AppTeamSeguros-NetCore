
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TGL.WebAppTeamSeguros.Models
{
    public enum TypeDoc { TI = 1, CC = 2 }
    

    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public TypeDoc TypeDoc { get; set; }
        [Required]
        public long NumDoc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        public string City { get; set; }
        public int Age { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }
}
