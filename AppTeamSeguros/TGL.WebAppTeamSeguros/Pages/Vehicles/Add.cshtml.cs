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
        public CustomerStore CustomerStore { get; set; }
        public Customer Customer { get; set; }
        public AddModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        [BindProperty]
        public Guid CustomerId { get; set; }

        public void OnGetCustomerId(Guid CustomerId)
        {
            this.CustomerId = CustomerId;
            
        }

        public void OnGet(Guid customerid) 
        {
            CustomerId = customerid;
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            double increase;
            //Add
            Vehicle.CustomerId = CustomerId;
            Customer = CustomerStore.GetCustomerById(CustomerId);
            increase=Vehicle.Insurance.GetIncrease(Customer.Age,Customer.City,Vehicle.Year);
            Vehicle.Insurance.Increase=increase;
            VehicleStore.AddVehicle(Vehicle);
            return RedirectToPage("./Index", "CustomerId", new { CustomerId = CustomerId });
        }
    }
}