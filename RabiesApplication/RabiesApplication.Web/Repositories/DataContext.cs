using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using RabiesApplication.Web.Models;


namespace RabiesApplication.Web
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {

        public Member Member { get; set; }


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
