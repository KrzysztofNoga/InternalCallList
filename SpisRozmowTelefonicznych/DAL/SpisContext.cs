using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpisRozmowTelefonicznych.DAL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SpisRozmowTelefonicznych.DAL
{
    public class SpisContext: IdentityDbContext<ApplicationUser>
    {
        public SpisContext() : base("SpisContext")
        {
        }

        public static SpisContext Create()
        {
            return new SpisContext();
        }
             
            public DbSet<Phone> Phones { get; set; }
            public DbSet<Call>  Calls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove< PluralizingTableNameConvention > ();
        }
       

        
         



    }
}