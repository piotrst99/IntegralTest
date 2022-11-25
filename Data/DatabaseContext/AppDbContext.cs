using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.DatabaseContext {
    public class AppDbcontext : DbContext{
        public AppDbcontext(DbContextOptions options) : base(options){}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarRepair> CarRepairs { get; set; }
        
        // tworzenie modelu z ograniczeniami
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CarRepair>()
                .Ignore(x=>x.Car)
                .Ignore(x=>x.Customer);
        }
    }
}
