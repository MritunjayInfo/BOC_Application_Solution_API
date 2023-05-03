using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class Process
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<FormBuilder> FormBuilders { get; set; }
    }
}
