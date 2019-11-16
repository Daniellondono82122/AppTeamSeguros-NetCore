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
            //Add
            CustomerStore.AddCustomer(Customer);
            return RedirectToPage("../Vehicles/Add","CustomerId", new { CustomerId = Customer.Id });
         
        }

    }
}