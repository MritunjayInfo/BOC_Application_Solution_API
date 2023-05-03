using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class Sections
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Desscription { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PreferredForm PreferredForm { get; set; }
    }
}
