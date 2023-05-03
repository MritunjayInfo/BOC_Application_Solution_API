using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.FormBuilderDTO;
using BOCApplication.Model.DTO.ProcessDTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BOCApplication.Repositoy.FormBuilderService
{
    public class FormBuilderRepository: IFormBuilderRepository
    {
        private readonly ApplicationDbContext _db;
        public FormBuilderRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public async Task<bool> AddFormBuilderAsync(CreateFormBuilder createFormBuilder)
        {

            var res = new FormBuilder()
            {
                Form = createFormBuilder.Form,
                MenuName = createFormBuilder.MenuName,
                ProcessId = createFormBuilder.ProcessId,
            };
            await _db.AddAsync(res);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FormBuilder>> GetFormBuilderAsync(int UserId)
        {
            var res = await _db.FormBuilders.Where(x => x.Process.UserId == UserId).ToListAsync();
            return res;
        }

        public async Task<GetFormBuilder> GetFormBuilderAsyncByForm(string Form, int processId)
        {
            var res = await _db.FormBuilders.Where(x => x.ProcessId == processId && x.Form == Form).FirstOrDefaultAsync();
            if (res == null)
            {
                return null;
            }
            var form = new GetFormBuilder()
            {
                Id = res.Id,
                Form = res.Form,
                MenuName = res.MenuName,
                ProcessId = res.ProcessId,
            };
            return form;
        }

        public async Task<GetFormBuilder> GetFormBuilderAsyncById(int id)
        {
            var res = await _db.FormBuilders.Where(x => x.Id==id).FirstOrDefaultAsync();
            if (res == null)
            {
                return null;
            }
            var form = new GetFormBuilder()
            {
                Id = res.Id,
                Form = res.Form,
                MenuName = res.MenuName,
                ProcessId = res.ProcessId,
            };
            return form;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.FormBuilders.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            _db.FormBuilders.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateFormBuilderAsync(UpdateFormBuilder UpdateFormBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
