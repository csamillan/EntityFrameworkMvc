namespace EntityFrameworkMvc.Dtos
{
    public class SaveInventaryDto
    {
        public int? Id { get; set; }

        public decimal Stock { get; set; }

        public int BookId { get; set; }

        public int BranchId { get; set; }
    }
}
