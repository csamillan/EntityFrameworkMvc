using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Model
{
    public class ModelDBContext : DbContext
    {
        public ModelDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Editorial> Editorials { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Editorial>( Editorial =>
            {
                Editorial.ToTable("Editorial");
                Editorial.HasKey(p => p.Id);

                Editorial.Property(p => p.Name)
                                        .IsRequired()
                                        .HasMaxLength(50);
                Editorial.Property(p => p.NameContact)
                                        .IsRequired()
                                        .HasMaxLength(100);
                Editorial.Property(p => p.Address)
                                        .IsRequired()
                                        .HasMaxLength(150);
                Editorial.Property(p => p.City)
                                        .IsRequired()
                                        .HasMaxLength(50);
                Editorial.Property(p => p.Phone)
                                        .IsRequired()
                                        .HasMaxLength(12);
                Editorial.Property(p => p.Email)
                                        .IsRequired()
                                        .HasMaxLength(100);
                Editorial.Property(p => p.Commentary)
                                        .IsRequired(false)
                                        .HasMaxLength(150);
            });

            modelBuilder.Entity<Book>(Book =>
            {
                Book.ToTable("Book");
                Book.HasKey(p => p.Id);

                Book.Property(p => p.ISBN)
                                        .IsRequired()
                                        .HasMaxLength(30);
                Book.Property(p => p.Title)
                                        .IsRequired()
                                        .HasMaxLength(80);
                Book.Property(p => p.Autor)
                                        .IsRequired()
                                        .HasMaxLength(100);
                Book.Property(p => p.Year)
                                        .IsRequired();
                Book.Property(p => p.Price)
                                        .IsRequired();
                Book.Property(p => p.Commentary)
                                        .IsRequired(false)
                                        .HasMaxLength(150);
            });
        }
    }
}
