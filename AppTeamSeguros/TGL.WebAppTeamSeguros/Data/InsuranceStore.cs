using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Data
{
    public class InsuranceStore
    { 
        public Context Context { get; set; }
        public InsuranceStore(Context context)
        {
            Context = context;

        }

        internal Insurance GetInsuranceById(Guid id)
        {
            return Context.Insurance.FirstOrDefault(
                x => x.Id == id
                );
        }

        internal void AddInsurance(Insurance insurance)
        {
            Context.Insurance.Add(insurance);
            Context.SaveChanges();
        }

        internal void DeleteInsurance(Guid id)
        {
            var insurance = Context.Insurance.FirstOrDefault(
                x => x.Id == id //linq
                );
            Context.Insurance.Remove(insurance);
            Context.SaveChanges();
        }

        public List<Insurance> GetInsurances()
        {
            return Context.Insurance.ToList();
        }
    }
}
