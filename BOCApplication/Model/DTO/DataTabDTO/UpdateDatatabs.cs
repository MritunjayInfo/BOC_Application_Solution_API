using BOCApplication.Model.Domain;

namespace BOCApplication.Model.DTO.DataTabDTO
{
    public class UpdateDatatabs
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? OrganisationImageBase64 { get; set; }
        public int CreateTableId { get; set; }
    }
}
