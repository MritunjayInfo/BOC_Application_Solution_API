using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.FieldsDTO;

namespace BOCApplication.Repositoy.FieldsService
{
    public interface IFieldsRepository
    {
        Task<bool> AddFieldsAsync(CreateFields createFields);
        Task<GetFields> GetFieldsAsyncById(int id);
        Task<GetFields> GetFieldsAsyncByType(string Type, int UserId);
        Task<IEnumerable<Fields>> GetFieldsAsync(int UserId);
        Task<bool> UpdateFieldsAsync(UpdateFields updateFields);
        Task<bool> DeleteAsync(int Id);
    }
}
