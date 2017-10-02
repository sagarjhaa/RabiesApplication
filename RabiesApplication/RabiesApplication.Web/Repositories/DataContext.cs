using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using RabiesApplication.Models;
using RabiesApplication.Models.Interfaces;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bite> Bites { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HumanVictim> HumanVictims { get; set; }


        

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalOwner> AnimalOwner { get; set; }

        //public DbSet<Action> Actions { get; set; }
        //public DbSet<Investigation> Investigations { get; set; }
        //public DbSet<Specimen> Specimens { get; set; }

        public DbSet<Species> Species { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<BiteStatus> BiteStatuses { get; set; }
        

        public DataContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static DataContext Create() => new DataContext();    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(t => t.Employee)
                .WithRequired();

           
            base.OnModelCreating(modelBuilder);
        }
    }
}
