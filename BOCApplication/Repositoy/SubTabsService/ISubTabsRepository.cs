using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.SubTabsDTO;

namespace BOCApplication.Repositoy.SubTabsService
{
    public interface ISubTabsRepository
    {
        Task<bool> AddSubTabsAsync(CreateSubTabs createSubTabs);
        Task<GetSubTabs> GetSubTabsAsyncById(int id);
        Task<GetSubTabs> GetSubTabsAsyncByName(string Name, int UserId);
        Task<IEnumerable<SubTabs>> GetSubTabsAsync(int UserId);
        Task<bool> UpdateSubTabsAsync(UpdateSubTab updateSubTab);
        Task<bool> DeleteAsync(int Id);
    }
}
