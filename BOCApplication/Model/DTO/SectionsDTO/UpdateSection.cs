namespace BOCApplication.Model.DTO.SectionsDTO
{
    public class UpdateSection
    {
        public int Id { get; set; }
        public string? Desscription { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
