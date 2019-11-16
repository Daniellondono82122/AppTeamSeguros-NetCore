
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TGL.WebAppTeamSeguros.Models
{
    public enum typeDoc { TI = 1, CC = 2 }
    

    public class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
            Age= DateTime.Today.AddTicks(-Birthday.Ticks).Year - 1;
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public typeDoc TypeDoc { get; set; }
        [Required]
        public long NumDoc { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "15/11/2003" , "1/1/1919")]
        public DateTime Birthday { get; set; }
        [Required]
        public string City { get; set; }
        public int Age { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }
}
