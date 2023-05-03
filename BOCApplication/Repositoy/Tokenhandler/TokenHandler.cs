using BOCApplication.Model.Domain;
using BOCApplication.Model.DTO.UserDTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BOCApplication.Repositoy.Tokenhandler
{
    public class TokenHandler: ITokenhandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<string> CreateTokenAsync(GetUser GetUser)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //Create Clames
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, GetUser.Email ));
            claims.Add(new Claim(ClaimTypes.GivenName, GetUser.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
                );


            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
