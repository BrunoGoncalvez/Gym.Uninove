
using Gym.Uninove.Core.Entities.Users;
using Gym.Uninove.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.Uninove.Data.Context
{
    public class GymContext : DbContext
    {
        // CONSTRUCTOR
        public GymContext(DbContextOptions<GymContext> options) : base(options){ }


        // ENTITIES
        public DbSet<GymBranch> Gyms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Address> Adresses { get; set; }

        public DbSet<GroupClass> GroupClasses { get; set; }


        // Configure Context
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}


    }
}
