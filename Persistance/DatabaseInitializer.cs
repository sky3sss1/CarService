using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using System;
using System.Linq;
using System.Numerics;

namespace Persistence
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (!context.Washes.Any())
                {
                    context.Washes.AddRange(
                        new Wash
                        {
                            Price = 1500,
                            Description = "Basic Wash"
                        },
                        new Wash
                        {
                            Price = 2500,
                            Description = "Standard Wash"
                        },
                        new Wash
                        {
                            Price = 3500,
                            Description = "Premium Wash"
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Tarifs.Any())
                {
                    var basicWashId = context.Washes.FirstOrDefault(w => w.Description == "Basic Wash")?.Id ?? Guid.NewGuid();
                    var standardWashId = context.Washes.FirstOrDefault(w => w.Description == "Standard Wash")?.Id ?? Guid.NewGuid();
                    var premiumWashId = context.Washes.FirstOrDefault(w => w.Description == "Premium Wash")?.Id ?? Guid.NewGuid();

                    context.Tarifs.AddRange(
                        new Tarif
                        {
                            Wash_Id = basicWashId,
                            Name = "Basic Tarif",
                            Cost = 500,
                            CostIfLoosed = 1000
                        },
                        new Tarif
                        {
                            Wash_Id = basicWashId,
                            Name = "Deluxe Tarif",
                            Cost = 1000,
                            CostIfLoosed = 3000
                        },
                        new Tarif
                        {
                            Wash_Id = standardWashId,
                            Name = "Standard Tarif",
                            Cost = 1000,
                            CostIfLoosed = 2000
                        },
                        new Tarif
                        {
                            Wash_Id = standardWashId,
                            Name = "Premium Tarif",
                            Cost = 2000,
                            CostIfLoosed = 3000
                        },
                        new Tarif
                        {
                            Wash_Id = premiumWashId,
                            Name = "Full Service Tarif",
                            Cost = 3000,
                            CostIfLoosed = 7000
                        }
                    );

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Name = "Иван Иванов",
                            Email = "ivan.ivanov@example.com",
                            Phone_Number = "1111111111"
                        },
                        new User
                        {
                            Name = "Мария Петрова",
                            Email = "maria.petrova@example.com",
                            Phone_Number = "2222222222"
                        },
                        new User
                        {
                            Name = "Алексей Смирнов",
                            Email = "alexey.smirnov@example.com",
                            Phone_Number = "3333333333"
                        },
                        new User
                        {
                            Name = "Елена Козлова",
                            Email = "elena.kozlova@example.com",
                            Phone_Number = "4444444444"
                        },
                        new User
                        {
                            Name = "Дмитрий Васильев",
                            Email = "dmitry.vasilyev@example.com",
                            Phone_Number = "5555555555"
                        },
                        new User
                        {
                            Name = "Ольга Новикова",
                            Email = "olga.novikova@example.com",
                            Phone_Number = "6666666666"
                        },
                        new User
                        {
                            Name = "Сергей Морозов",
                            Email = "sergey.morozov@example.com",
                            Phone_Number = "7777777777"
                        },
                        new User
                        {
                            Name = "Татьяна Кузнецова",
                            Email = "tatiana.kuznetsova@example.com",
                            Phone_Number = "8888888888"
                        },
                        new User
                        {
                            Name = "Анна Соколова",
                            Email = "anna.sokolova@example.com",
                            Phone_Number = "9999999999"
                        }
                    );

                    context.SaveChanges(); 
                }

                if (!context.Places.Any())
                {
                    context.Places.AddRange(
                        new Place { Is_Charge = true, Voltage = 220 },
                        new Place { Is_Charge = false, Voltage = 0 },
                        new Place { Is_Charge = true, Voltage = 110 },
                        new Place { Is_Charge = true, Voltage = 380 },
                        new Place { Is_Charge = false, Voltage = 0 },
                        new Place { Is_Charge = true, Voltage = 240 },
                        new Place { Is_Charge = true, Voltage = 120 },
                        new Place { Is_Charge = false, Voltage = 0 },
                        new Place { Is_Charge = true, Voltage = 200 }
                    );

                    context.SaveChanges();
                }
                if (!context.Floors.Any())
                {
                    context.Floors.AddRange(
                        new Floor { FloorNumber = 1 },
                        new Floor { FloorNumber = 2 },
                        new Floor { FloorNumber = 3 },
                        new Floor { FloorNumber = 4 },
                        new Floor { FloorNumber = 5 }
                    );

                    context.SaveChanges();
                }
                if (!context.Parkings.Any())
                {
                    var floors = context.Floors.ToList();
                    var places = context.Places.ToList();

                    foreach (var floor in floors)
                    {
                        foreach(var place in places)
                        {
                            var parking = new Parking
                            {
                                Floor_Id = floor.Id,
                                Place_Id = place.Id
                            };

                            context.Parkings.Add(parking);
                        }
                    }

                    context.SaveChanges();
                }
                if (!context.Cars.Any())
                {
                    var users = context.Users.ToList();

                    context.Cars.AddRange(
                        new Car
                        {
                            User_Id = users[0].Id,
                            GovernmentNumber = "А123ВС",
                            Model = "Toyota Camry",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[1].Id,
                            GovernmentNumber = "В234АВ",
                            Model = "Honda Accord",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[2].Id,
                            GovernmentNumber = "Е567УК",
                            Model = "BMW X5",
                            MinimalVoltage = 240
                        },
                        new Car
                        {
                            User_Id = users[3].Id,
                            GovernmentNumber = "К890НС",
                            Model = "Mercedes-Benz E-Class",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[4].Id,
                            GovernmentNumber = "М456ОР",
                            Model = "Audi Q7",
                            MinimalVoltage = 240
                        },
                        new Car
                        {
                            User_Id = users[5].Id,
                            GovernmentNumber = "Р112АА",
                            Model = "Volkswagen Passat",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[6].Id,
                            GovernmentNumber = "С789УВ",
                            Model = "Ford Focus",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[7].Id,
                            GovernmentNumber = "Т321АЕ",
                            Model = "Chevrolet Cruze",
                            MinimalVoltage = 220
                        },
                        new Car
                        {
                            User_Id = users[8].Id,
                            GovernmentNumber = "У456АК",
                            Model = "Nissan Altima",
                            MinimalVoltage = 240
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
