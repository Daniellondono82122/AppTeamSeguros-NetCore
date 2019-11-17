using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TGL.WebAppTeamSeguros.Data;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public List<Vehicle> VehiclesByCostumerId { get; set; }


        public IndexModel(VehicleStore vehicleStore)
        {
            VehiclesByCostumerId = new List<Vehicle>();
            VehicleStore = vehicleStore;
            Vehicles = VehicleStore.GetVehicles();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            VehicleStore.DeleteVehicle(id);
            return RedirectToPage();
        }
        [BindProperty]
        public Guid Customerid { get; set; }
        public void OnGetCustomerId(Guid CustomerId)
        {
            this.Customerid = CustomerId;
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.CustomerId == Customerid)
                {
                    Vehicle addVe = vehicle;
                    VehiclesByCostumerId.Add(addVe);
                }
            }
        }

        public void OnGet(Guid customerid)
        {
            Customerid = customerid;
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.CustomerId == Customerid)
                {
                    Vehicle addVe = vehicle;
                    VehiclesByCostumerId.Add(addVe);
                }
            }
        }

    }
}
