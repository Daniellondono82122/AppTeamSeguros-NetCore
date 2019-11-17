using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGL.WebAppTeamSeguros.Models;

namespace TGL.WebAppTeamSeguros.Data
{
    public class Context: DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Insurance> Insurance { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
