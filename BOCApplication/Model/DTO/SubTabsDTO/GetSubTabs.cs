namespace BOCApplication.Model.DTO.SubTabsDTO
{
    public class GetSubTabs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
