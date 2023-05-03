using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.UserDTO;
using Userss = BOCApplication.Model.Domain.User;

namespace BOCApplication.Repositoy.UserService
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserCreate userCreate);
        Task<GetUser> GetUserAsyncById(int id);
        Task<GetUser> GetUserAsyncByEmail(string email);
        Task<LogInDto> Authenticate(LogInDto logInDto);
        Task<IEnumerable<Userss>> GetUserAsync();
        Task<bool> UpdateUserAsync(UpdateUser updateUser);
        Task<bool> DeleteAsync(int Id);
        //Task<RefreshTokenUser> GetRefreshTokenByUserId(int userId);
        Task<bool> UpdateRefreshTokenAsync(int usersId, string refreshtoken); 
        Task<bool> UpdateRefreshToken(int usersId, string refreshToken);
    }
}
