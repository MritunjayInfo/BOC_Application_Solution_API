using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class FormBuilder
    {
        [Key]
        public int Id { get; set; }
        public string Form { get; set; }
        public string MenuName { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}
