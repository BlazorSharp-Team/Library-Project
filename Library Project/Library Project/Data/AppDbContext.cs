using Microsoft.EntityFrameworkCore;

namespace Library_Project.Data
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions <AppDbContext> options)
            :base (options)
        {

        }

        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("Books");
                entity.Property(e => e.Id).HasColumnName("Userid");
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.isbnNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Publisher)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PublishDate);
                entity.Property(e => e.Quantity)
                    .HasMaxLength(20);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
