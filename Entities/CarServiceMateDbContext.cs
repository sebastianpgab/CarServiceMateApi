using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class CarServiceMateDbContext : DbContext
    {
        public CarServiceMateDbContext(DbContextOptions<CarServiceMateDbContext> options) : base(options)
        {
            try
            {

                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<MailRequest> MailRequests { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<SmsRequest> SmsRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Domyślna wartość statusu dla pojazdu
            modelBuilder.Entity<Vehicle>()
                .Property(p => p.Status)
                .HasDefaultValue("Czeka na naprawę");

            // Relacja: Company 1:N Users
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.IdCompany)
                .OnDelete(DeleteBehavior.Restrict); 

            // Relacja: Company 1:N MailRequests
            modelBuilder.Entity<MailRequest>()
                .HasOne(m => m.Company)
                .WithMany(c => c.MailRequests)
                .HasForeignKey(m => m.IdCompany)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja: Company 1:N SmsRequests
            modelBuilder.Entity<SmsRequest>()
                .HasOne(s => s.Company)
                .WithMany(c => c.SmsRequests)
                .HasForeignKey(s => s.IdCompany)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
