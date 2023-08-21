using CarServiceMate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate
{
    public class CarServiceMateSeeder
    {
        public readonly CarServiceMateDbContext _dbContext;
        public CarServiceMateSeeder(CarServiceMateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>() 
            {
               new Role()
               {
                   Name = "Client"
               },
               new Role()
               {
                   Name = "Mechanic"
               },
               new Role()
               {
                   Name = "Admin"
               }
            };
            return roles;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Clients.Any())
                {

                    //Seed Clients
                    var clients = new List<Client>
                    {
                    new Client
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Address = "123 Main St",
                        PhoneNumber = "555-123-4567",
                        Email = "johndoe@example.com"
                    },
                    new Client
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Address = "456 High St",
                        PhoneNumber = "555-234-5678",
                        Email = "janedoe@example.com"
                    }
                    };
                    _dbContext.Clients.AddRange(clients);
                    _dbContext.SaveChanges();

                    //Seed Vehicles
                    var vehicles = new List<Vehicle>
                    {
                    new Vehicle
                    {
                        Make = "Toyota",
                        Model = "Camry",
                        VIN = "12345678901234567",
                        Year = 2010,
                        Engine = "2.5L",
                        Kilometers = 100000,
                        ClientId = 1
                    },
                    new Vehicle
                    {
                        Make = "Honda",
                        Model = "Accord",
                        VIN = "23456789012345678",
                        Year = 2015,
                        Engine = "3.5L",
                        Kilometers = 50000,
                        ClientId = 2
                    }
                    };
                    _dbContext.Vehicles.AddRange(vehicles);
                    _dbContext.SaveChanges();

                    //Seed Notification
                    var notifications = new List<Notification>
                {
                    new Notification
                    {
                        NotificationDate = new DateTime(2004-03-10),
                        Description = "Notka do samochodu 1"
                    },

                    new Notification
                    {
                        NotificationDate = new DateTime(2005-02-11),
                        Description = "Notka do samochodu 2"
                    }
                    };
                    _dbContext.Notifications.AddRange(notifications);
                    _dbContext.SaveChanges();

                    //Seed Orders
                    var orders = new List<Order>
                    {
                    new Order
                    {
                        OrderDate = DateTime.Now,
                        TotalCost = 100.00m,
                        Status = "Completed",
                    },
                    new Order
                    {
                        OrderDate = DateTime.Now,
                        TotalCost = 250.00m,
                        Status = "In Progress",
                    }
                    };
                    _dbContext.Orders.AddRange(orders);
                    _dbContext.SaveChanges();

                    //Seed Repairs
                    var repairs = new List<Repair>
                    {
                    new Repair
                    {
                        Description = "Oil change",
                        RepairDate = DateTime.Now,
                        Cost = 50.00m,
                        VehicleId = 1,
                        OrderId = 1,
                        NotificationId = 1
                    },
                    new Repair
                    {
                        Description = "Brake job",
                        RepairDate = DateTime.Now,
                        Cost = 200.00m,
                        VehicleId = 2,
                        OrderId = 2,
                        NotificationId = 2
                    }
                    };
                    _dbContext.Repairs.AddRange(repairs);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
