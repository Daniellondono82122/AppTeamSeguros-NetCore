using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Data
{
    public class VehicleStore
    {
        
        public Context Context { get; set; }
  
        public VehicleStore(Context context)
        {
            Context = context;

        }

        internal Vehicle GetVehicleById(Guid id)
        {
            return Context.Vehicle.FirstOrDefault(
                x => x.Id == id
                );
        }
               
        internal void AddVehicle(Vehicle vehicle)
        {
            Context.Vehicle.Add(vehicle);
            Context.SaveChanges();
        }

        internal void DeleteVehicle(Guid id)
        {
            var vehicle = Context.Vehicle.FirstOrDefault(
                x => x.Id == id //linq
                );
            Context.Vehicle.Remove(vehicle);
            Context.SaveChanges();
        }

        public List<Vehicle> GetVehicles()
        {
            var b= Context.Vehicle.ToList();
            return b;
        }
        
    }
}
