using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using Microsoft.EntityFrameworkCore;

namespace BOCApplication.Repositoy.CreateTableService
{
    public class CreateTableRepository: ICreateTableRepository
    {
        private readonly ApplicationDbContext _db;
        public CreateTableRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddCreateTableAsync(AddCreateTable addCreateTable)
        {
            var res = new CreateTable()
            {
                TableName = addCreateTable.TableName,
                Description = addCreateTable.Description,
                UserId = addCreateTable.UserId
            };
            await _db.AddAsync(res);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CreateTable>> GetCreateTableAsync(int UserId)
        {
            var res = await _db.CreateTables.Where(x => x.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetCreatetable> GetCreateTableAsyncById(int id)
        {
            var res = await _db.CreateTables.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res == null) return null;
            var createtable = new GetCreatetable()
            {
                Id = res.Id,
                TableName = res.TableName,
                Description = res.Description,
                UserId = res.UserId
            };
            return createtable;
        }

        public async Task<GetCreatetable> GetCreateTableAsyncByTableName(string TableName, int UserId)
        {
            var res = await _db.CreateTables.Where(x => x.UserId==UserId).FirstOrDefaultAsync();
            if (res == null) return null;
            var createtable = new GetCreatetable()
            {
                Id = res.Id,
                TableName = (string)res.TableName,
                Description =(string)res.Description,
                UserId = res.UserId
            };
            return createtable;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.CreateTables.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.CreateTables.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCreateTableAsync(UpdateCreateTable updateCreateTable)
        {
            var res = await GetCreateTableAsyncById(updateCreateTable.Id);
            if (res == null) return false;
            res.Description= (string)updateCreateTable.Description;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
