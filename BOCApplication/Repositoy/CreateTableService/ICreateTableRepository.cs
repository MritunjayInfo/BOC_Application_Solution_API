using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.ProcessDTO;

namespace BOCApplication.Repositoy.CreateTableService
{
    public interface ICreateTableRepository
    {
        Task<bool> AddCreateTableAsync(AddCreateTable addCreateTable);
        Task<GetCreatetable> GetCreateTableAsyncById(int id);
        Task<GetCreatetable> GetCreateTableAsyncByTableName(string TableName, int UserId);
        Task<IEnumerable<CreateTable>> GetCreateTableAsync(int UserId);
        Task<bool> UpdateCreateTableAsync(UpdateCreateTable updateCreateTable);
        Task<bool> DeleteAsync(int Id);
    }
}
