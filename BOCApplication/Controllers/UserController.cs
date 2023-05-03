using BOCApplication.Model.DTO.CreatetableDTO;
using BOCApplication.Model.DTO.UserDTO;
using BOCApplication.Repositoy.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var existUser = await _userRepository.GetUserAsync();
            return Ok(existUser);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(UserCreate userCreate)
        {
            var existUser = await _userRepository.GetUserAsyncByEmail(userCreate.Email);
            if(existUser != null)
            {
                return BadRequest("User is allready exits");
            }
            var res = await _userRepository.AddUserAsync(userCreate);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var existUser = await _userRepository.GetUserAsyncById(id);
            if(existUser == null)
            {
                return BadRequest("No any users present");
            }
            return Ok(existUser);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var res = await _userRepository.DeleteAsync(Id);
            return res == false ? BadRequest($"this{Id} is not availbale") : Ok($"User is Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UpdateUser updateUser)
        {
            var exist = await _userRepository.GetUserAsyncByEmail(updateUser.Email);
            if (exist.Id != updateUser.Id)
            {
                return BadRequest($"This users ({updateUser.Email}) allready exist");
            }
            var res = await _userRepository.UpdateUserAsync(updateUser);
            return Ok(res);
        }
    }
}
