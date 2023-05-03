using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BOCApplication.Model.Domain
{
    public class DataTab
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }
        public int CreateTableId { get; set; }
        public CreateTable CreateTable { get; set; }
        public string? OrganisationImageBase64 { get; set; }
    }
}
