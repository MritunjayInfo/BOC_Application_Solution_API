using BOCApplication.Model.Domain;

namespace BOCApplication.Model.DTO.FieldsDTO
{
    public class CreateFields
    {
        public string? Desscription { get; set; }
        public string? Type { get; set; }
        public string? Size { get; set; }
        public string? Max_length { get; set; }
        public string? CreatedBy { get; set; }
        public string? Preview { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
