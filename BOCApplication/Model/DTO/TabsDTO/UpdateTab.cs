namespace BOCApplication.Model.DTO.TabsDTO
{
    public class UpdateTab
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
    }
}
