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
            //Vehicle vehicle = VehicleStore.GetVehicleById(VehicleId);
            //Customer customer = CustomerStore.GetCustomerById(vehicle.CustomerId);
            //Increase = GetIncrease(customer.Age, customer.City, Cost, vehicle.Year);
        }

        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        
        public double Cost { get; set; }
        public double Increase { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateExp { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public VehicleStore VehicleStore { get; set; }
        public CustomerStore CustomerStore { get; set; }


        private double GetIncrease(int Age, string City, double Cost, int YearVehicle)
        {
            double increaseMed = 0;
            double increaseYear = 0;
            double increase = 0;
            int year = DateTime.Now.Year-YearVehicle;

            if (City == "Medellín")
            {
                increaseMed = Cost * 0.1;
            }

            if (year >= 10)
            {
                increaseYear = Cost * 0.05;
            }

            if (Age <= 25)
            {
                increase = Cost * 0.3;
            
            } else if (Age <= 40)
                {
                    increase = Cost * 0.1;
                }

            return increase + increaseMed + increaseYear;
        }
    }
}
