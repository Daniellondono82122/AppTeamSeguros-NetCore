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
        public IndexModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
            Vehicles = VehicleStore.GetVehicles();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            VehicleStore.DeleteVehicle(id);
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
