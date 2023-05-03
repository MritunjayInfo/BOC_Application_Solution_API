using BOCApplication.Data;
using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;
using Userss = BOCApplication.Model.Domain.User;

namespace BOCApplication.Repositoy.UserService
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public async Task<bool> AddUserAsync(UserCreate userCreate)
        {
            var user = new Userss()
            {
                UserName = userCreate.UserName,
                Email = userCreate.Email,
                Password = userCreate.Password
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Userss>> GetUserAsync()
        {
            var res = await _db.Users.ToListAsync();
            return res;
        }

        public async Task<GetUser> GetUserAsyncByEmail(string email)
        {
            var existUser = await _db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if(existUser == null)
            {
                return null;
            }
            var user = new GetUser()
            {
                Id = existUser.Id,
                UserName = existUser.UserName,
                Password = existUser.Password,
                Email = existUser.Email,
                RefreshToken = existUser.RefreshToken,
                RefreshTokenExpiryTime = existUser.RefreshTokenExpiryTime,
            };
            return user;
        }

        public async Task<GetUser> GetUserAsyncById(int id)
        {
            var existUser = await _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(existUser == null)
            {
                return null;
            }
            var user = new GetUser()
            {
                Id = existUser.Id,
                UserName = existUser.UserName,
                Password = existUser.Password,
                Email = existUser.Email,
                RefreshToken = existUser.RefreshToken,
                RefreshTokenExpiryTime = existUser.RefreshTokenExpiryTime,
            };
            return user;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var exist = await _db.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
              _db.Users.Remove(exist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(UpdateUser updateUser)
        {
            var res = await GetUserAsyncById(updateUser.Id);
            if (res == null) return false;
            res.UserName = updateUser.UserName;
            res.Email = updateUser.Email;
            res.Password = updateUser.Password;
            //await _db.Users.Update();
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<LogInDto> Authenticate(LogInDto logInDto)
        {
            var res = await GetUserAsyncByEmail(logInDto.Email);
            if (res == null || res.Password != logInDto.Password)
            {
                return null;
            }
            return logInDto;
        }
        
        public async Task<bool> UpdateRefreshToken(int usersId, string refreshToken)
        {
            var res = await GetUserAsyncById(usersId);

            res.RefreshToken = refreshToken;
            res.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _db.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateRefreshTokenAsync(int usersId, string refreshToken)
        {
            var res = await GetUserAsyncById(usersId);

            res.RefreshToken = refreshToken;
           // res.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}
