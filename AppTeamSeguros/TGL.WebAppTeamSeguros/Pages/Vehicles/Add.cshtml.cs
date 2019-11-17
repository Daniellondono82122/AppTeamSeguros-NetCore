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
        public List<Customer> Customers { get; set; }
        public AddModel(VehicleStore vehicleStore, CustomerStore customerStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            Customers = new List<Customer>();
            Customers = CustomerStore.GetCustomers();
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
            var customer = Customers.FirstOrDefault(x => x.Id == CustomerId);
            increase=Vehicle.Insurance.GetIncrease(customer.Age,customer.City,Vehicle.Year);
            Vehicle.Insurance.Increase=increase;
            VehicleStore.AddVehicle(Vehicle);
            return RedirectToPage("./Index", "CustomerId", new { CustomerId = CustomerId });
        }
    }
}