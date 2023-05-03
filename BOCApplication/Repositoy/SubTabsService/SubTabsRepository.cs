using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.SubTabsDTO;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BOCApplication.Repositoy.SubTabsService
{
    public class SubTabsRepository: ISubTabsRepository
    {
        private readonly ApplicationDbContext _db;
        public SubTabsRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddSubTabsAsync(CreateSubTabs createSubTabs)
        {
            var subtabs = new SubTabs()
            {
                Name = createSubTabs.Name,
                Description = createSubTabs.Description,
                UserId = createSubTabs.UserId,
                PreferredFormId = createSubTabs.PreferredFormId,
            };

            await _db.AddAsync(subtabs);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubTabs>> GetSubTabsAsync(int UserId)
        {
            var res = await _db.SubTabs.Where(x => x.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetSubTabs> GetSubTabsAsyncByName(string Name, int UserId)
        {
            var res = await _db.SubTabs.Where(x => x.UserId == UserId && x.Name == Name).FirstOrDefaultAsync();
            if (res == null) return null;
            var sub = new GetSubTabs()
            {
                Id= res.Id,
                Name = res.Name,
                Description = res.Description,
                PreferredFormId = res.PreferredFormId,
                UserId = res.UserId
            };
            return sub;
        }

        public async Task<GetSubTabs> GetSubTabsAsyncById(int id)
        {
            var res = await _db.SubTabs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res == null) return null;
            var sub = new GetSubTabs()
            {
                Name = res.Name,
                Description = res.Description,
                PreferredFormId = res.PreferredFormId,
                UserId = res.UserId
            };
            return sub;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.SubTabs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.SubTabs.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSubTabsAsync(UpdateSubTab updateSubTab)
        {
            var res = await GetSubTabsAsyncById(updateSubTab.Id);   
            if(res == null) return false;
            res.Description = updateSubTab.Description;
            res.PreferredFormId = updateSubTab.PreferredFormId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
