using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class Tabs
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PreferredForm PreferredForm { get; set; }
    }
}
