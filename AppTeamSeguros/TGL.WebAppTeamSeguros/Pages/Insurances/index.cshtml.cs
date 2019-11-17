using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TGL.WebAppTeamSeguros.Data;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Pages.Insurances
{
    public class IndexModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public CustomerStore CustomerStore { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Customer> Customers { get; set; }

        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public Insurance Insurance { get; set; }



        public IndexModel(VehicleStore vehicleStore, CustomerStore customerStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;


            Customer = new Customer();
            Vehicle = new Vehicle();
            Insurance = new Insurance();

            Customers = new List<Customer>();
            Vehicles = new List<Vehicle>();

            Vehicles = VehicleStore.GetVehicles();
            Customers = CustomerStore.GetCustomers();
        }
        public IActionResult OnPostDelete(Guid id)
        {
            VehicleStore.DeleteVehicle(id);
            return RedirectToPage();
        }
    }
}
