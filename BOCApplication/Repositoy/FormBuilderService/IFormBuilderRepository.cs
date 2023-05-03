using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.FormBuilderDTO;


namespace BOCApplication.Repositoy.FormBuilderService
{
    public interface IFormBuilderRepository
    {
        Task<bool> AddFormBuilderAsync(CreateFormBuilder createFormBuilder);
        Task<GetFormBuilder> GetFormBuilderAsyncById(int id);
        Task<GetFormBuilder> GetFormBuilderAsyncByForm(string Form,int ProcessId);
        Task<IEnumerable<FormBuilder>> GetFormBuilderAsync(int UserId);
        Task<bool> UpdateFormBuilderAsync(UpdateFormBuilder UpdateFormBuilder);
        Task<bool> DeleteAsync(int Id);
    }
}
