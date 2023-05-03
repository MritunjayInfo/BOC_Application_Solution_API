using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.UserDTO;
using Processs = BOCApplication.Model.Domain.Process;

namespace BOCApplication.Repositoy.ProcessService
{
    public interface IProcessRepository
    {
        Task<bool> AddProcessAsync(CreateProcess createProcess);
        Task<GetProcess> GetProcessAsyncById(int id);
        Task<GetProcess> GetProcessAsyncByCode(string code, int UserId);
        Task<IEnumerable<Processs>> GetProcessAsync(int UserId);
        Task<bool> UpdateProcessAsync(UpdateProcess updateProcess);
        Task<bool> DeleteAsync(int Id);
    }
}
