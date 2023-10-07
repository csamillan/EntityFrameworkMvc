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
            //Creacion de Data Inicial Para Editorial
            List<Editorial> editorialsInit = new List<Editorial>();

            editorialsInit.Add(new Editorial
            {
                Id = 1,
                Name = "Libreria San Marcos",
                NameContact = "Manuel Fernandez",
                Address = "Urb. Salamanca Mz 4 Lt 4",
                City = "Lima",
                Phone = "+51555555555",
                Email ="libSanMarcos@gmail.com",
                Commentary = "Libreria especializada en libros de programacion"
            });

            editorialsInit.Add(new Editorial
            {
                Id = 2,
                Name = "Libreria Santo Tomas",
                NameContact = "Jose Alfredo",
                Address = "Av. Los Manzanos N° 548",
                City = "Chiclayo",
                Phone = "+51888888888",
                Email = "libSantoTomas@gmail.com",
                Commentary = "Libreria especializada en libros para niños"
            });

            modelBuilder.Entity<Editorial>( Editorial =>
            {
                //To Table permite ponerle el nombre q qieres a la tabla
                Editorial.ToTable("Editorial");

                //Has Key Permite crear la clave primaria al valor
                Editorial.HasKey(p => p.Id);

                //Permite asignar la Propiedad de cada columna de cada columna
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

                //HasData permite el llenado de la data inicial en la tabla
                Editorial.HasData(editorialsInit);
            });

            List<Book> booksInit = new List<Book>();

            booksInit.Add(new Book()
            {
                Id = 1,
                ISBN = "54545adsasd541215",
                Title = "Estructura e interpretación de programas informáticos",
                Autor = "Harold Abelson",
                Year = 2005,
                Price = 28,
                Commentary = "Libro basicos para estudiantes de programacion",
                EditorialId = 1,
            });

            booksInit.Add(new Book()
            {
                Id = 2,
                ISBN = "6465123321asdasd321586",
                Title = "A Veces Mamá Tiene Truenos en la Cabeza",
                Autor = "Harold Abelson",
                Year = 2021,
                Price = 35,
                Commentary = "Libro para niños entre 8 a 12 años",
                EditorialId = 2,
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

                Book.HasData(booksInit);
            });
        }
    }
}
