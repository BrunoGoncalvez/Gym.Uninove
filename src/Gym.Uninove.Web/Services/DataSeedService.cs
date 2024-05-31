using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Entities.Users;
using Gym.Uninove.Core.Enums;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym.Uninove.Web.Services
{
    public class DataSeedService
    {
        private readonly GymContext _context;

        public DataSeedService([FromServices]GymContext context)
        {
            this._context = context;
        }
        public void Seeding()
        {

            if (_context.Teachers.Any() || _context.Gyms.Any() || _context.Adresses.Any()) return;

            _context.Teachers.Add(new Teacher { Id = 1, Name = "Tom Cruise", Description = "Aulas de Dublê" });
            _context.Teachers.Add(new Teacher { Id = 2, Name = "John Wick", Description = "Professor de Dança" });
            _context.Teachers.Add(new Teacher { Id = 3, Name = "Julia Roberts", Description = "Professora de Ballet" });
            _context.Teachers.Add(new Teacher { Id = 4, Name = "Sylvester Stallone", Description = "Professor de Boxe" });
            _context.Teachers.Add(new Teacher { Id = 5, Name = "Steve Carell", Description = "Aulas de Parkout" });


            _context.Gyms.Add(new GymBranch { Id = 1, Name = "Uninove Memorial", UnitNumber = 12, Phone = "(11) 98888-9999", ImagePath = "/images/gym/default-gym-image.jpg" });
            _context.Gyms.Add(new GymBranch { Id = 2, Name = "Uninove Barra Funda", UnitNumber = 10, Phone = "(11) 97676-9999", ImagePath = "/images/gym/default-gym-image.jpg" });
            _context.Gyms.Add(new GymBranch { Id = 3, Name = "Gym Paulista", UnitNumber = 11, Phone = "(11) 98888-0909", ImagePath = "/images/gym/default-gym-image.jpg" });
            _context.Gyms.Add(new GymBranch { Id = 4, Name = "Globo Gym", UnitNumber = 8, Phone = "(11) 92121-9999", ImagePath = "/images/gym/default-gym-image.jpg" });
            _context.Gyms.Add(new GymBranch { Id = 5, Name = "Tecnology Memorial", UnitNumber = 7, Phone = "(11) 91212-9999", ImagePath = "/images/gym/default-gym-image.jpg" });
            _context.Gyms.Add(new GymBranch { Id = 6, Name = "Gym Monster", UnitNumber = 5, Phone = "(11) 95454-9999", ImagePath = "/images/gym/default-gym-image.jpg" });


            _context.Adresses.Add(new Address { Id = 1, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Barra Funda", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-999", GymId = 1 });

            _context.Adresses.Add(new Address
            { Id = 2, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Jaraguá", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-888", GymId = 2 });

            _context.Adresses.Add(new Address
            { Id = 3, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Paulista", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-777", GymId = 3 });

            _context.Adresses.Add(new Address
            { Id = 4, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Liberdade", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-666", GymId = 4 });

            _context.Adresses.Add(new Address
            { Id = 5, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Campinas", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-555", GymId = 5 });

            _context.Adresses.Add(new Address { Id = 6, Street = "Rua da Imaginação", Number = 123, Neighborhood = "Mogi das Cruzes", 
                City = "São Paulo", State = "São Paulo", Complement = "", ZipCode = "09999-333", GymId = 6 });

            _context.Equipments.Add(new Equipment { Id = 1, Name = "BIKE ERG ECHOCROSS", DatePurchase = DateTime.Now, UsageTime = DateTime.Now, StatusPurchase = StatusEquipment.New });
            _context.Equipments.Add(new Equipment { Id = 2, Name = "ANILHA ELITE EMBORRACHADA - 4 GRIPS", DatePurchase = DateTime.Now, UsageTime = DateTime.Now, StatusPurchase = StatusEquipment.New });
            _context.Equipments.Add(new Equipment { Id = 3, Name = "KIT HALTERES SEXTAVADO", DatePurchase = DateTime.Now, UsageTime = DateTime.Now, StatusPurchase = StatusEquipment.Used });
            _context.Equipments.Add(new Equipment { Id = 4, Name = "INDOOR AIR ROWER", DatePurchase = DateTime.Now, UsageTime = DateTime.Now, StatusPurchase = StatusEquipment.Used });
            _context.Equipments.Add(new Equipment { Id = 5, Name = "REMO SECO", DatePurchase = DateTime.Now, UsageTime = DateTime.Now, StatusPurchase = StatusEquipment.New });


            // Password: myRoot123
            _context.Users.Add(new User { Id = 1, Name = "Root", Email = "root@root.com", Password = "749db48637aa76a9994e3c63fb160fd762ad36b6b9077e3b0b6abcbc329f07f6", Role = TypeUser.Admin });

            // Password: 123123123
            _context.Users.Add(new User { Id = 2, Name = "Comum", Email = "comum@comum.com", Password = "932f3c1b56257ce8539ac269d7aab42550dacf8818d075f0bdf1990562aae3ef", Role = TypeUser.Admin });

            _context.SaveChanges();

        }

    }
}
