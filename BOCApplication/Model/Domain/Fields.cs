using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class Fields
    {
        [Key]
        public int Id { get; set; }
        public string? Desscription { get; set; }
        public string? Type { get; set; }
        public string? Size { get; set; }
        public string? Max_length { get; set; }
        public string? CreatedBy { get; set; }
        public string? Preview { get; set; }
        public int PreferredFormId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PreferredForm PreferredForm { get; set; }
    }
}
