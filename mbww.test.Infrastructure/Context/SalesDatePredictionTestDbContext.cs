using SalesDatePrediction.test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Net;

namespace SalesDatePrediction.test.Infrastructure.Context
{
    public class SalesDatePredictionTestDbContext : DbContext
    {

        public SalesDatePredictionTestDbContext(DbContextOptions<SalesDatePredictionTestDbContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<NextOrderPrediction> NextOrderPrediction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDatePredictionTestDbContext).Assembly);
            modelBuilder.Entity<Order>().ToTable("Orders", schema: "Sales");
            modelBuilder.Entity<Employee>().ToTable("Employees", schema: "HR");
            modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
            modelBuilder.Entity<Employee>()
        .Property(e => e.Mgrid).IsRequired(false);
            modelBuilder.Entity<Shipper>().ToTable("Shippers", schema: "Sales");
            modelBuilder.Entity<Product>().ToTable("Products", schema: "Production");
            modelBuilder.Entity<NextOrderPrediction>().HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
