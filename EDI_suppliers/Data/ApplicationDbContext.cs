using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EDI_suppliers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Connection> Connections { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
