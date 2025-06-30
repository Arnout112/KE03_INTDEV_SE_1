using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }
         
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product
                {
                    Name = "Nebuchadnezzar",
                    Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen",
                    Price = 10000.00m,
                    ImageUrl = "/img/products/Nebuchadnezzar.webp",
                    SalePrice = null,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    StockQuantity = 5,
                    CreatedAt = DateTime.UtcNow.AddDays(-120),
                    Category = "Hovercraft"
                },
                new Product
                {
                    Name = "Jack-in Chair",
                    Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort",
                    Price = 500.50m,
                    ImageUrl = "/img/products/jackinchair.png",
                    SalePrice = 450.00m,
                    SaleStartDate = DateTime.UtcNow.AddDays(-10),
                    SaleEndDate = DateTime.UtcNow.AddDays(10),
                    StockQuantity = 10,
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    Category = "Equipment"
                },
                new Product
                {
                    Name = "EMP (Electro-Magnetic Pulse) Device",
                    Description = "Wapentuig op de schepen van Zion",
                    Price = 129.99m,
                    ImageUrl = "/img/products/emp.png",
                    SalePrice = 99.99m,
                    SaleStartDate = DateTime.UtcNow.AddDays(-5),
                    SaleEndDate = DateTime.UtcNow.AddDays(5),
                    StockQuantity = 20,
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    Category = "Weapon"
                },
                new Product
                {
                    Name = "Zion defence turret",
                    Description = "De defence turrets van Zion, gebruikt om de oorlog van de machines te winnen",
                    Price = 9500.00m,
                    ImageUrl = "/img/products/zion_defense_turret.jpg",
                    SalePrice = null,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    StockQuantity = 3,
                    CreatedAt = DateTime.UtcNow.AddDays(-90),
                    Category = "Weapon"
                },
                new Product
                {
                    Name = "Sentinel Drone",
                    Description = "Mechanische vijand die jaagt op menselijke schepen in de echte wereld",
                    Price = 299.99m,
                    ImageUrl = "/img/products/sentinel_drone.jpg",
                    SalePrice = 249.99m,
                    SaleStartDate = DateTime.UtcNow.AddDays(-2),
                    SaleEndDate = DateTime.UtcNow.AddDays(8),
                    StockQuantity = 15,
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    Category = "Enemy"
                },
                new Product
                {
                    Name = "Construct Training Module",
                    Description = "Virtuele omgeving waarin de crew vechttechnieken en scenario’s oefent",
                    Price = 749.00m,
                    ImageUrl = "/img/products/onderdeel6.jpeg",
                    SalePrice = null,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    StockQuantity = 7,
                    CreatedAt = DateTime.UtcNow.AddDays(-45),
                    Category = "Simulation"
                },
                new Product
                {
                    Name = "Oracle’s Cookie",
                    Description = "Mysterieuze koekje van de Oracle dat meer betekenis heeft dan je denkt",
                    Price = 2.99m,
                    ImageUrl = "/img/products/oracle_cookie.webp",
                    SalePrice = 1.99m,
                    SaleStartDate = DateTime.UtcNow.AddDays(-1),
                    SaleEndDate = DateTime.UtcNow.AddDays(14),
                    StockQuantity = 100,
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    Category = "Consumable"
                },
                new Product
                {
                    Name = "Operator Console",
                    Description = "Console waarmee de operator zoals Tank of Link de crew begeleidt",
                    Price = 1200.00m,
                    ImageUrl = "/img/products/operators_console.webp",
                    SalePrice = null,
                    SaleStartDate = null,
                    SaleEndDate = null,
                    StockQuantity = 4,
                    CreatedAt = DateTime.UtcNow.AddDays(-80),
                    Category = "Equipment"
                }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."},
                new Part { Name = "M3 Ringetje", Description = "Voor gebruik met kleine bouten om druk gelijkmatig te verdelen" },
                new Part { Name = "M3 Moertje", Description = "Bevestigt M3 boutjes op plaatsen met beperkte ruimte" },
                new Part { Name = "Gyroscoopmodule", Description = "Voor stabilisatie van hovercrafts of drones" },
                new Part { Name = "Neural Interface Jack", Description = "Connector voor aansluiting op de Matrix via nekpoort" },
                new Part { Name = "O-Ring T-klasse", Description = "Voor afdichting van hydraulische systemen in luchtsluizen" },
                new Part { Name = "Thrusterklep", Description = "Regelt stuwkracht bij verticale manoeuvres van schepen" },
                new Part { Name = "Ionisatiekern", Description = "Onderdeel van energieopwekking aan boord van een hovercraft" }

            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
