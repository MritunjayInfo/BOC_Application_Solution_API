using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.SectionsDTO;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BOCApplication.Repositoy.SectionsService
{
    public class SectionRepository: ISectionRepository
    {
        private readonly ApplicationDbContext _db;
        public SectionRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddSectionsAsync(CreateSections createSections)
        {
            var sections = new Sections()
            {
                Name = createSections.Name,
                Desscription = createSections.Desscription,
                PreferredFormId = createSections.PreferredFormId,
                UserId = createSections.UserId,
            };
            await _db.Sections.AddAsync(sections);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Sections>> GetSectionsAsync(int UserId)
        {
            var res = await _db.Sections.Where(x => x.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetSections> GetSectionsAsyncByName(string Name, int UserId)
        {
            var exist = await _db.Sections.Where(x => x.Name == Name && x.UserId == UserId).FirstOrDefaultAsync();
            if(exist == null)
            {
                return null;
            }
            var res = new GetSections()
            {
                Id = exist.Id,
                Name = exist.Name,
                Desscription = exist.Desscription,
                PreferredFormId = exist.PreferredFormId,
                UserId = exist.UserId
            };
            return res;
        }

        public async Task<GetSections> GetSectionsAsyncById(int Id)
        {
            var exist = await _db.Sections.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return null;
            }
            var res = new GetSections()
            {
                Id = exist.Id,
                Name = exist.Name,
                Desscription = exist.Desscription,
                PreferredFormId = exist.PreferredFormId,
                UserId = exist.UserId
            };
            return res;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.Sections.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.Sections.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSectionsAsync(UpdateSection updateSection)
        {
            var res = await GetSectionsAsyncById(updateSection.Id);
            if (res == null) return false;
            res.Desscription = updateSection.Desscription;
            res.PreferredFormId = updateSection.PreferredFormId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
