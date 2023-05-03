using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.DataTabDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using Microsoft.EntityFrameworkCore;

namespace BOCApplication.Repositoy.DataTabService
{
    public class DataTabRepository: IDataTabRepository
    {
        private readonly ApplicationDbContext _db;
        public DataTabRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddDatatabsAsync(CreateDatatabs createDatatabs)
        {
            var datatabs = new DataTab()
            {
                Code = createDatatabs.Code,
                Description = createDatatabs.Description,
                CreateTableId = createDatatabs.CreateTableId,
                OrganisationImageBase64 = createDatatabs.OrganisationImageBase64,
            };
            await _db.DataTabs.AddAsync(datatabs);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DataTab>> GetDatatabsAsync(int UserId)
        {
            var res = await _db.DataTabs.Where(x =>x.CreateTable.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetDatatabs> GetDatatabsAsyncByCode(string code, int CreateTableId)
        {
            var res = await _db.DataTabs.Where(x => x.Code == code && x.CreateTableId == CreateTableId).FirstOrDefaultAsync();
            if (res == null)
            {
                return null;
            }
            var datatab = new GetDatatabs()
            {
                Id = res.Id,
                Code = res.Code,
                Description = res.Description,
                CreateTableId = res.CreateTableId,
                OrganisationImageBase64 = res.OrganisationImageBase64,
            };
            return datatab;
            
        }

        public async Task<GetDatatabs> GetDatatabsAsyncById(int id)
        {
            var res = await _db.DataTabs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res == null)
            {
                return null;
            }
            var datatab = new GetDatatabs()
            {
                Id = res.Id,
                Code = res.Code,
                Description = res.Description,
                CreateTableId = res.CreateTableId,
                OrganisationImageBase64 = res.OrganisationImageBase64,
            };
            return datatab;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.DataTabs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.DataTabs.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDatatabsAsync(UpdateDatatabs updateDatatabs)
        {
            var res = await GetDatatabsAsyncById(updateDatatabs.Id);
            if (res == null) return false;
            res.Description = updateDatatabs.Description;
            res.OrganisationImageBase64 = updateDatatabs.OrganisationImageBase64;
            res.CreateTableId = updateDatatabs.CreateTableId;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
