using Microsoft.IdentityModel.Tokens;
using SEDC.WebApi.Class10.SecuringApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.Class10.SecuringApi.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Aneta",
                LastName = "Stankovska",
                Username = "astan",
                Password = "asdzxc123"
            },
            new User
            {
                Id = 1,
                FirstName = "Trajan",
                LastName = "Stevkovski",
                Username = "trastev",
                Password = "asdzxc123"
            }
        };

        public void Register(RegisterModel request)
        {
            var user = ValidateUser(request.Username);
            if(user != null)
            {
                throw new Exception("Username already exists");
            }
            if (!ValidatePassword(request.Password))
            {
                throw new Exception("Password not valid");
            }

            var hashedPassword = HashPassword(request.Password);

            var registeredUser = new User
            {
                Id = _users.Count() + 1,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = hashedPassword
            };

            _users.Add(registeredUser);
        }

        public UserDto Login(LoginModel request)
        {
            var user = ValidateUser(request.Username);
            if(user == null)
            {
                throw new Exception("User does not exist");
            }
            var password = HashPassword(request.Password);

            if(user.Password != password)
            {
                throw new Exception("Password not valid");
            }
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding
                .ASCII
                .GetBytes("this is a secret from appsettings");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("Id", user.Id.ToString()),
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserDto
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Id = user.Id,
                Token = tokenHandler.WriteToken(token)
            };
        }

        private bool ValidatePassword(string password)
        {
            foreach (var character in password)
            {
                if (char.IsDigit(character))
                {
                    return true;
                }
            }
            return false;
        }

        private User? ValidateUser(string username)
        {
            return _users.FirstOrDefault(x => x.Username
            .Equals(username,
                StringComparison.CurrentCultureIgnoreCase));
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5data);
        }

    }
}
