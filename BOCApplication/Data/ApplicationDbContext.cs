using BOCApplication.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BOCApplication.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Tabs> Tabs { get; set; }
        public DbSet<SubTabs> SubTabs { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<CreateTable> CreateTables { get; set; }
        public DbSet<DataTab> DataTabs { get; set; }
        public DbSet<FormBuilder> FormBuilders { get; set; }
        public DbSet<PreferredForm> PreferredForms { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
