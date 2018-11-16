using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    class RegionContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State>   States { get; set; }
        public DbSet<Region>  Regions { get; set; }

        public RegionContext()
          : base(Data.Properties
          .Settings
          .Default.DbConnectionString)
        {
        }
    }
}
