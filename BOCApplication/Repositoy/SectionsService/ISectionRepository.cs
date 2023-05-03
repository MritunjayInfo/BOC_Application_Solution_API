using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.ProcessDTO;
using BOCApplication.Model.DTO.SectionsDTO;

namespace BOCApplication.Repositoy.SectionsService
{
    public interface ISectionRepository
    {
        Task<bool> AddSectionsAsync(CreateSections createSections);
        Task<GetSections> GetSectionsAsyncById(int Id);
        Task<GetSections> GetSectionsAsyncByName(string Name, int UserId);
        Task<IEnumerable<Sections>> GetSectionsAsync(int UserId);
        Task<bool> UpdateSectionsAsync(UpdateSection updateSection);
        Task<bool> DeleteAsync(int Id);
    }
}
