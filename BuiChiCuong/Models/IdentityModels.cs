using Microsoft.AspNet.Identity.EntityFramework;

namespace BuiChiCuong.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<BuiChiCuong.Context.Product> Products { get; set; }

        public System.Data.Entity.DbSet<BuiChiCuong.Context.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<BuiChiCuong.Context.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<BuiChiCuong.Context.Order> Orders { get; set; }
    }
}