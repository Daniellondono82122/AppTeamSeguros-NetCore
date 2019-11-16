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
    public class AddModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public AddModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;

        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        [BindProperty]
        public Guid customerId { get; set; }

        public void OnGetCustomerId(Guid CustomerId)
        {
            customerId = CustomerId;
            
        }

        public void OnGet() 
        {
            
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add
            Vehicle.CustomerId = customerId;
            VehicleStore.AddVehicle(Vehicle);
            return RedirectToPage("./Index");
        }
    }
}