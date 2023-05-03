using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;
using Processs = BOCApplication.Model.Domain.Process;

namespace BOCApplication.Repositoy.ProcessService
{
    public class ProcessRepository: IProcessRepository
    {
        private readonly ApplicationDbContext _db;
        public ProcessRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddProcessAsync(CreateProcess createProcess)
        {
            var res = new Processs()
            {
                Code = createProcess.Code,
                Description = createProcess.Description,
                UserId = createProcess.UserId,
            };
            await _db.Processes.AddAsync(res);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Model.Domain.Process>> GetProcessAsync(int UserId)
        {
            var res = await _db.Processes.Where(x=>x.UserId==UserId).ToListAsync();
            return res;
        }

        public async Task<GetProcess> GetProcessAsyncById(int id)
        {
            var res = await _db.Processes.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return null;
            }
            var exitsProcess = new GetProcess()
            {
                Id = res.Id,
                Code = res.Code,
                Description = res.Description,
                UserId = res.UserId,
            };
            return exitsProcess;
        }
        public async Task<GetProcess> GetProcessAsyncByCode(string code, int UserId)
        {
            var res = await _db.Processes.FirstOrDefaultAsync(x => x.Code == code && x.UserId==UserId);
            if (res == null)
            {
                return null;
            }
            var exitsProcess = new GetProcess()
            {
                Id = res.Id,
                Code = res.Code,
                Description = res.Description,
                UserId = res.UserId,
            };
            return exitsProcess;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.Processes.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.Processes.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProcessAsync(UpdateProcess updateProcess)
        {
            var res = await GetProcessAsyncById(updateProcess.Id);
            if(res==null) return false;
            res.Description = updateProcess.Description;
            await _db.SaveChangesAsync();
            var res1 = await GetProcessAsyncById(updateProcess.Id);


            return true;
        }
    }
}
