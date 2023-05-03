using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class CreateTable
    {
        [Key]
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
