using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace GUI.Models
{


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Display(Name = "Name")]
        public string Name { get; set; }



        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }

   
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("easymissionEntities")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Make sure you add above line
            modelBuilder.Entity<ApplicationUser>().ToTable("aspnetusers");
            modelBuilder.Entity<IdentityRole>().ToTable("aspnetroles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetuserroles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetuserclaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetuserlogins");
            //Don't add IdentityUser ToTable aspnetusers
        }
    }
}