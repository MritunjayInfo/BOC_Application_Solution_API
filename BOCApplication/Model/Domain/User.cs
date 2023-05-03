using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required]
        //[StringLength(255, ErrorMessage = "Must be between 2 and 255 characters", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public IEnumerable<Process> Process { get;set; }
        public IEnumerable<Tabs> Tabs { get; set; }
        public IEnumerable<SubTabs> SubTabs { get; set; }
        public IEnumerable<Fields> Fields { get; set; }
        public IEnumerable<Sections> Sections { get; set; }
        public IEnumerable<DataTab> DataTabs { get; set; }
        public IEnumerable<CreateTable> CreateTables { get; set; }
    }
}
