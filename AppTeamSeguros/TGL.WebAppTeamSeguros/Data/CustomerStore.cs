using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Data
{
    public class CustomerStore
    {
        public Context Context { get; set; }
        public CustomerStore(Context context)
        {
            Context = context;

        }

        internal Customer GetCustomerById(Guid id)
        {
            return Context.Customer.FirstOrDefault(
                x=> x.Id==id
                );
        }

        internal void EditCustomer(Customer customer)
        {
            var currentCustomer = GetCustomerById(customer.Id);
            currentCustomer.Id = customer.Id;
            currentCustomer.Name = customer.Name;
            currentCustomer.LastName = customer.LastName;
            currentCustomer.TypeDoc = customer.TypeDoc;
            currentCustomer.NumDoc = customer.NumDoc;
            currentCustomer.Birthday = customer.Birthday;
            currentCustomer.City = customer.City;
            Context.Customer.Update(currentCustomer);
            Context.SaveChanges();
        }

        internal void AddCustomer(Customer customer)
        {
            Context.Customer.Add(customer);
            Context.SaveChanges();
        }

        internal void DeleteCustomer(Guid id)
        {
            var customer = Context.Customer.FirstOrDefault(
                x => x.Id == id //linq
                );
            Context.Customer.Remove(customer);
            Context.SaveChanges();
        }

        public List<Customer> GetCustomers() {
            return Context.Customer.ToList();
        }


    }
}
