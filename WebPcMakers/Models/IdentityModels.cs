using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebPcMakers.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        //Temporal Shopping
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }
        //Shopping
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Item> Order_Items { get; set; }
        public DbSet<Order_Address> Order_Addresses { get; set; }
        public DbSet<Order_Tracking> Order_Trackings { get; set; }
        //
        public DbSet<Payment> Payments { get; set; }
        //
        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }

        //public System.Data.Entity.DbSet<WebPcMakers.Models.Size> Sizes { get; set; }

        //public System.Data.Entity.DbSet<WebPcMakers.Models.Color> Colors { get; set; }
    }
}