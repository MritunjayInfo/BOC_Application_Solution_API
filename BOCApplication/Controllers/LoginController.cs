using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.UserDTO;
using BOCApplication.Repositoy.Tokenhandler;
using BOCApplication.Repositoy.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOCApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ITokenhandler _tokenHandler;
        public LoginController(IConfiguration configuration , IUserRepository userRepository,ITokenhandler tokenhandler)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenHandler = tokenhandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LogInDto loginDto)
        {
            // check if user is authenticated

            //check username and password
            var user = await _userRepository.Authenticate(loginDto);
            if (user != null)
            {
                //Generate a Jwt Token
                var users = await _userRepository.GetUserAsyncByEmail(loginDto.Email);
                var refreshToken = GenerateRefreshToken();
                var token = await _tokenHandler.CreateTokenAsync(users);
                var res = await _userRepository.UpdateRefreshToken(users.Id,refreshToken);

                return Ok(new
                {
                    JwtToken = token,
                    RefreshToken = refreshToken,
                });
            }
            return BadRequest("Username or password is incurrect");
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            var user = await _userRepository.GetUserAsyncByEmail(username);
            //var user = await _userRepository.GetRefreshTokenByUserId(users.Id);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = _tokenHandler.CreateTokenAsync(user);
            var newRefreshToken = GenerateRefreshToken();

            await _userRepository.UpdateRefreshTokenAsync(user.Id, newRefreshToken);

            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
    }
}
