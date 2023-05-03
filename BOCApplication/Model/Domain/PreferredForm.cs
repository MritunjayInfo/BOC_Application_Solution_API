using System.ComponentModel.DataAnnotations;

namespace BOCApplication.Model.Domain
{
    public class PreferredForm
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Tabs> Tabs { get; set; }
        public IEnumerable<SubTabs> SubTabs { get; set; }
        public IEnumerable<Fields> Fields { get; set; }
        public IEnumerable<Sections> Sections { get; set; }
        //public IEnumerable<DataTab> DataTabs { get; set; }
        //public IEnumerable<CreateTable> CreateTables { get; set; }
    }
}
