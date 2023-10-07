namespace EntityFrameworkMvc.Model
{
    public class Editorial
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? NameContact { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Commentary { get; set; }

        // foreigns
        public virtual ICollection<Book>? Books { get; set; }

    }
}
