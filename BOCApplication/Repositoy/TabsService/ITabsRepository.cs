using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.TabsDTO;

namespace BOCApplication.Repositoy.TabsService
{
    public interface ITabsRepository
    {
        Task<bool> AddTabsAsync(CreateTabs createTabs);
        Task<GetTabs> GetTabsAsyncById(int Id);
        Task<GetTabs> GetTabsAsyncByName(string Name, int UserId);
        Task<IEnumerable<Tabs>> GetTabsAsync(int UserId);
        Task<bool> UpdateTabsAsync(UpdateTab updateTab);
        Task <bool> DeleteAsync(int Id);
    }
}
