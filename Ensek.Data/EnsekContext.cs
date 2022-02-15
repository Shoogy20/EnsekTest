using System;
using Ensek.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Data
{
    public class EnsekContext : DbContext
    {
        public EnsekContext(DbContextOptions<EnsekContext>
          options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.LastName).IsRequired();
            modelBuilder.Entity<MeterReading>().HasKey(nameof(MeterReading.AccountId), nameof(MeterReading.MeterReadingDate));
            modelBuilder.Entity<MeterReading>().Property(m => m.MeterReadingValue).IsRequired();
        }

    }
}
