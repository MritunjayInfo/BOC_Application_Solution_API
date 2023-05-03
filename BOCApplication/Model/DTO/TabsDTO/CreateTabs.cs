namespace BOCApplication.Model.DTO.TabsDTO
{
    public class CreateTabs
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
