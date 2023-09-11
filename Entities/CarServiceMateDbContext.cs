using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class CarServiceMateDbContext : DbContext
    {
        private string _connectionString = "Server=SEBASTIANPGAB\\SQLEXPRESS; Database=CarServiceMateDb; Trusted_Connection=True";
        public DbSet<Client> Clients { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
