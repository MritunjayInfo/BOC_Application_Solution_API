namespace BOCApplication.Model.DTO.TabsDTO
{
    public class GetTabs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
