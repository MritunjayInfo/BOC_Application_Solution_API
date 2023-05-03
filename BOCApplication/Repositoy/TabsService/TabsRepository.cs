using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.SectionsDTO;
using BOCApplication.Model.DTO.TabsDTO;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BOCApplication.Repositoy.TabsService
{
    public class TabsRepository: ITabsRepository
    {
        private readonly ApplicationDbContext _db;
        public TabsRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddTabsAsync(CreateTabs createTabs)
        {
            var sections = new Tabs()
            {
                Name = createTabs.Name,
                Description = createTabs.Description,
                PreferredFormId = createTabs.PreferredFormId,
                UserId = createTabs.UserId,
            };
            await _db.Tabs.AddAsync(sections);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.Tabs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.Tabs.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tabs>> GetTabsAsync(int UserId)
        {
            var res = await _db.Tabs.Where(x => x.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetTabs> GetTabsAsyncById(int Id)
        {
            var exist = await _db.Tabs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return null;
            }
            var res = new GetTabs()
            {
                Id = exist.Id,
                Name = exist.Name,
                Description = exist.Description,
                PreferredFormId = exist.PreferredFormId,
                UserId = exist.UserId
            };
            return res;
        }

        public async Task<GetTabs> GetTabsAsyncByName(string Name, int UserId)
        {
            var exist = await _db.Tabs.Where(x => x.Name == Name && x.UserId == UserId).FirstOrDefaultAsync();
            if (exist == null)
            {
                return null;
            }
            var res = new GetTabs()
            {
                Id = exist.Id,
                Name = exist.Name,
                Description = exist.Description,
                PreferredFormId = exist.PreferredFormId,
                UserId = exist.UserId
            };
            return res;
        }

        public async Task<bool> UpdateTabsAsync(UpdateTab updateTab)
        {
            var res = await GetTabsAsyncById(updateTab.Id);
            if(res == null) return false;
            res.Description = updateTab.Description;
            res.PreferredFormId = updateTab.PreferredFormId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
