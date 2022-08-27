using AutoMapper;
using SEDC.WebApi.MovieManager.Common.MappingHelpers;
using SEDC.WebApi.MovieManager.DataAccess;
using SEDC.WebApi.MovieManager.DataModels.Models;
using SEDC.WebApi.MovieManager.ServiceModels.UserModels;
using SEDC.WebApi.MovieManager.Services.Interfaces;

namespace SEDC.WebApi.MovieManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userReporitory;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userReporitory, IMapper mapper)
        {
            _userReporitory = userReporitory;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userReporitory.GetAll().Select(_mapper.Map<User, UserDto>);
            if (users.Any())
            {
                return users;
            }
            else
            {
                throw new Exception("No users found");
            }
        }
        public UserDto GetById(int id)
        {
            var user = _userReporitory.GetAll().FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            return user.Map();
        }
        public void Insert(CreateUserDto entity)
        {
            var user = _userReporitory.Insert(_mapper.Map<User>(entity));
        }
        public void Update(UpdateUserDto entity)
        {

        }
        public void Delete(int id)
        {
            var userTodelete = _userReporitory.GetAll().FirstOrDefault(x => x.Id == id);
            if (userTodelete != null)
            {
                _userReporitory.Delete(userTodelete);
            }
            else
            {
                throw new Exception("The user cannot be found");
            }
        }
        public IEnumerable<UserDto> FilterBy(Func<UserDto, bool> filter)
        {
            var userdtos = _userReporitory.GetAll().Select(_mapper.Map<User, UserDto>);
            return userdtos.Where(filter);
        }
    }
}
