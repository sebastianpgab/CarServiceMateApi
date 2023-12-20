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
            modelBuilder.Entity<Vehicle>().Property(p => p.Status).HasDefaultValue("Czeka na naprawę");
        }
    }
}
