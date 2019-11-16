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
    public class IndexModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public List<Customer> Customers { get; set; }
        public IndexModel(CustomerStore customerStore)
        {
            CustomerStore = customerStore;
            Customers = CustomerStore.GetCustomers();
        }
        
        public IActionResult OnPostDelete(Guid id)
        {
            CustomerStore.DeleteCustomer(id);
            return RedirectToPage();
        }

        public void OnGet()
        {
        }
    }
}
