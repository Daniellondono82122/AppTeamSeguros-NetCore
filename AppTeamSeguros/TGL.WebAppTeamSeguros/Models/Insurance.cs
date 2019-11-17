using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Data;

namespace TGL.WebAppTeamSeguros.Models
{
    public class Insurance
    {
        public Insurance()
        {
            Id = Guid.NewGuid();
            Cost = 1000000;
            DateExp = DateTime.Now;
            DueDate = DateExp.AddDays(360);
            //Increase = GetIncrease(customer.Age, customer.City, Cost, vehicle.Year);
        }

        public Guid Id { get; set; }
        public double Cost { get; set; }
        public double Increase { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateExp { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public double GetIncrease(int CustomerAge, string CustomerCity, int VehicleYear)
        {
            double increaseMed = 0;
            double increaseYear = 0;
            double increase = 0;
            int year = DateTime.Now.Year- VehicleYear;

            if (CustomerCity == "Medellín")
            {
                increaseMed = Cost * 0.1;
            }

            if (year >= 10)
            {
                increaseYear = Cost * 0.05;
            }

            if (CustomerAge <= 25)
            {
                increase = Cost * 0.3;
            
            } else if (CustomerAge <= 40)
                {
                    increase = Cost * 0.1;
                }

            return increase + increaseMed + increaseYear;
        }
    }
}
