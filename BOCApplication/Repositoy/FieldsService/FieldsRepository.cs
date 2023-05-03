using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.FieldsDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using Microsoft.EntityFrameworkCore;

namespace BOCApplication.Repositoy.FieldsService
{
    public class FieldsRepository: IFieldsRepository
    {
        private readonly ApplicationDbContext _db;
        public FieldsRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddFieldsAsync(CreateFields createFields)
        {
            var field = new Fields()
            {
                Desscription = createFields.Desscription,
                Type = createFields.Type,
                Size = createFields.Size,
                Max_length = createFields.Max_length,
                CreatedBy = createFields.CreatedBy,
                Preview = createFields.Preview,
                PreferredFormId = createFields.PreferredFormId,
                UserId = createFields.UserId,
            };
            await _db.AddAsync(field);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Fields>> GetFieldsAsync(int UserId)
        {
            var res = _db.Fields.Where(x => x.UserId == UserId).ToList();
            return res;
        }

        public async Task<GetFields> GetFieldsAsyncByType(string Type, int UserId)
        {
            var res = await _db.Fields.Where(x => x.UserId == UserId && x.Type == Type).FirstOrDefaultAsync();
            if(res == null) return null;
            var fields = new GetFields()
            {
                Id  = res.Id,
                Desscription = res.Desscription,
                Type = res.Type,
                Size = res.Size,
                Max_length = res.Max_length,
                CreatedBy = res.CreatedBy,
                Preview = res.Preview,
                PreferredFormId = res.PreferredFormId,
                UserId = res.UserId,
            };
            return fields;
        }

        public async Task<GetFields> GetFieldsAsyncById(int id)
        {
            var res = await _db.Fields.Where(x => x.Id == id).FirstOrDefaultAsync();
            var fields = new GetFields()
            {
                Id = res.Id,
                Desscription = res.Desscription,
                Type = res.Type,
                Size = res.Size,
                Max_length = res.Max_length,
                CreatedBy = res.CreatedBy,
                Preview = res.Preview,
                PreferredFormId = res.PreferredFormId,
                UserId = res.UserId,
            };
            return fields;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.Fields.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.Fields.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateFieldsAsync(UpdateFields updateFields)
        {
            var res = await GetFieldsAsyncById(updateFields.Id);
            if (res == null) return false;
            res.Type = updateFields.Type;
            res.Size = updateFields.Size;
            res.Desscription = updateFields.Desscription;
            res.Max_length = updateFields.Max_length;
            res.CreatedBy = updateFields.Max_length;
            res.PreferredFormId = updateFields.PreferredFormId;
            res.Preview = updateFields.Preview;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
