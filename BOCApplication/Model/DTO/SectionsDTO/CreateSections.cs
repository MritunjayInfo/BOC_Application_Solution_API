namespace BOCApplication.Model.DTO.SectionsDTO
{
    public class CreateSections
    {
        public string? Name { get; set; }
        public string? Desscription { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
