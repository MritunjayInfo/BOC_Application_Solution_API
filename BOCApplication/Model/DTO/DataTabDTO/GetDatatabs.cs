namespace BOCApplication.Model.DTO.DataTabDTO
{
    public class GetDatatabs
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CreateTableId { get; set; }
        public string? OrganisationImageBase64 { get; set; }
    }
}
