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
    public class EditModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public EditModel(CustomerStore customerStore)
        {
            CustomerStore = customerStore;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet(Guid id) //llega de la pagina id
        {
            Customer = CustomerStore.GetCustomerById(id);
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add
            CustomerStore.EditCustomer(Customer);
            return RedirectToPage("./Index");
        }
    }
}