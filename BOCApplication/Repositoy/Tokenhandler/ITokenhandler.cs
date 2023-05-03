using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.UserDTO;

namespace BOCApplication.Repositoy.Tokenhandler
{
    public interface ITokenhandler
    {
        Task<String> CreateTokenAsync(GetUser getUser);
    }
}
