namespace EntityFrameworkMvc.Dtos
{
    public class InventaryDto
    {
        public int Id { get; set; }

        public decimal Stock { get; set; }

        public int BookId { get; set; }

        public int BranchId { get; set; }

        public virtual BookDto? Book { get; set; }

        public virtual BranchDto? Branch { get; set; }
    }
}
