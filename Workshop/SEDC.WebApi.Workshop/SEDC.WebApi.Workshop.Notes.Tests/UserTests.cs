using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.WebApi.Workshop.Notes.Common.Models;
using SEDC.WebApi.Workshop.Notes.DataAccess;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using SEDC.WebApi.Workshop.Notes.ServiceModels.UserModels;
using SEDC.WebApi.Workshop.Notes.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace SEDC.WebApi.Workshop.Notes.Tests
{
    [TestClass]
    public class UserTests
    {
        private Mock<IRepository<User>> _userRepository;
        private IOptions<AppSettings> _options;

        public UserTests()
        {
            _userRepository = new Mock<IRepository<User>>();
            _options = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "SECRET FOR TESTING"
            }); ;
        }
        [TestMethod]
        public void Register_UsernameExists()
        {
            //Arange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = "somePassword",
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var request = new RegisterUser
            {
                Username = "astan"
            };

            var service = new UserService(_userRepository.Object, _options);

            //Act
            //Assert

            Assert.ThrowsException<Exception>(() =>
            {
                service.Register(request);
            });

        }

        [TestMethod]
        public void Register_PasswordNotValid()
        {
            //Arange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = "somePassword",
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var request = new RegisterUser
            {
                Username = "astan1",
                Password = "ASD123"
            };

            var service = new UserService(_userRepository.Object, _options);

            //Act
            //Assert
            Assert.ThrowsException<Exception>(() =>
            {
                service.Register(request);
            });
        }

        [TestMethod]
        public void Resgister_SuccessfullyRegisteredUser()
        {
            //Arange

            var password = "asdzxc123";

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = "somePassword",
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var request = new RegisterUser
            {
                FirstName = "Aneta",
                LastName = "Stankovska",
                Username = "astan1",
                Password = password
            };

            

            _userRepository.Setup(x => x.Insert(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Add(user);
                });

            var expectedUsers = 2;
            

            var service = new UserService(_userRepository.Object, _options);

            //Act
            service.Register(request);

            //Assert
            var expectedUser = users[1];
            Assert.AreEqual(expectedUsers, users.Count());
            Assert.AreEqual(expectedUser.FirstName, request.FirstName);
            Assert.AreEqual(expectedUser.LastName, request.LastName);
            Assert.AreNotEqual(expectedUser.Password, request.Password);
            Assert.AreEqual(expectedUser.Username, request.Username);
            Assert.AreEqual(expectedUser.Password, hashedPassword);

        }

        [TestMethod]
        public void Login_UserNotExists()
        {
            //Arange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = "somePassword",
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var request = new LoginModel
            {
                Username = "ast",
                Password = "asd123"
            };

            var service = new UserService(_userRepository.Object, _options);

            //Act
            //Assert
            Assert.ThrowsException<Exception>(() =>
            {
                service.Login(request);
            });
        }

        [TestMethod]
        public void Login_WrongPassword()
        {
            var password = "asdzxc123";
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            //Arange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = hashedPassword,
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var request = new LoginModel
            {
                Username = "astan",
                Password = "asd123"
            };

            var service = new UserService(_userRepository.Object, _options);

            //Act
            //Assert
            Assert.ThrowsException<Exception>(() =>
            {
                service.Login(request);
            });

        }

        [TestMethod]
        public void Login_ValidLogin()
        {
            var password = "asdzxc123";
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            //Arange
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Password = hashedPassword,
                    Username = "astan"
                }
            };
            _userRepository.Setup(x => x.GetAll()).Returns(users);

            var request = new LoginModel
            {
                Username = "astan",
                Password = password
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding
                .ASCII
                .GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{users[0].FirstName} {users[0].LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, users[0].Id.ToString()),
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var expectedResult = new UserLoginDto
            {
                Id = users[0].Id,
                FirstName = users[0].FirstName,
                LastName = users[0].LastName,
                Token = tokenHandler.WriteToken(token)
            };

            var service = new UserService(_userRepository.Object, _options);

            //Act
            var result = service.Login(request);

            //Assert
            Assert.AreEqual(expectedResult.Id, result.Id);
            Assert.AreEqual(expectedResult.FirstName, result.FirstName);
            Assert.AreEqual(expectedResult.LastName, result.LastName);
            Assert.AreEqual(expectedResult.Token, result.Token);
        }
    }
}
