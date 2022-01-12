using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_Project.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions <AppDbContext> options)
            :base (options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Books>().HasData(new Books { Title = "" })
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser { FirstName = "Teszt", LastName = "Béla", Email = "admin@email.hu", MemberId = new Guid(), RegistrationDay = "2022-01-10" });
            builder.Entity<Books>().HasData(new Books { Id = 1, Title = "A kis vakond", isbnNumber = "1234567891011", Author = "Teszt János", Publisher = "Teszt Kiadó", Category = "Mese", PublishDate = "1995-03-15", Quantity = 3 });
            base.OnModelCreating(builder);
        }

    }
}
