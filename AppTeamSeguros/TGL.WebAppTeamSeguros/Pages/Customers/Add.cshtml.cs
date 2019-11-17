using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TGL.WebAppTeamSeguros.Data;
using TGL.WebAppTeamSeguros.Models;


namespace TGL.WebAppTeamSeguros.Pages.Customers
{
    public class AddModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public AddModel(CustomerStore customerStore)
        {
            CustomerStore = customerStore;
            
        }
        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {
        }


        public IActionResult OnPostAsync() {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try

            {
                int age = DateTime.Now.Year - Customer.Birthday.Year;
                if (DateTime.Now < Customer.Birthday.AddYears(age)) age--;
                Customer.Age = age;
                CustomerStore.AddCustomer(Customer);

            }

            catch (Exception e)

            {
                e.ToString();
                return Page(); //return popup with error message

            }

            return RedirectToPage("../Vehicles/Add", "CustomerId", new { CustomerId = Customer.Id });


        }

    }
}