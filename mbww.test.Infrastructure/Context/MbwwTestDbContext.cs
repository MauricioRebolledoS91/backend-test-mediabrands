using mbww.test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Infrastructure.Context
{
    public class MbwwTestDbContext : DbContext
    {

        public MbwwTestDbContext(DbContextOptions<MbwwTestDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MbwwTestDbContext).Assembly);
            modelBuilder.Entity<User>().ToTable("users");
            base.OnModelCreating(modelBuilder);
        }
    }
}
