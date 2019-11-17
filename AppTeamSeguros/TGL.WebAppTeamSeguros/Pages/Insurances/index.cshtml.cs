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
        public InsuranceStore InsuranceStore { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Insurance> Insurances { get; set; }
        //public List<String> View { get; set; }

        public IndexModel()
        {
            Vehicles = VehicleStore.GetVehicles();
            Insurances = InsuranceStore.GetInsurances();
            Customers = CustomerStore.GetCustomers();
            //View = new List<String>();
        }


        public IActionResult OnPostDelete(Guid id)
        {
            VehicleStore.DeleteVehicle(id);
            return RedirectToPage();
        }
    }
}