using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.DataTabDTO;
using BOCApplication.Model.DTO.ProcessDTO;

namespace BOCApplication.Repositoy.DataTabService
{
    public interface IDataTabRepository
    {
        Task<bool> AddDatatabsAsync(CreateDatatabs createDatatabs);
        Task<GetDatatabs> GetDatatabsAsyncById(int id);
        Task<GetDatatabs> GetDatatabsAsyncByCode(string code, int CreateTableId);
        Task<IEnumerable<DataTab>> GetDatatabsAsync(int UserId);
        Task<bool> UpdateDatatabsAsync(UpdateDatatabs updateDatatabs);
        Task<bool> DeleteAsync(int Id);
    }
}
