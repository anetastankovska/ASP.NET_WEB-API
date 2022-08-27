using SEDC.WebApi.MovieManager.ServiceModels.UserModels;

namespace SEDC.WebApi.MovieManager.Services.Interfaces
{
    public interface IUserService 
    {
        public IEnumerable<UserDto> GetAll();
        public UserDto GetById(int id);
        public void Insert(CreateUserDto entity);
        public void Update(UpdateUserDto entity);
        public void Delete(int id);
        public IEnumerable<UserDto> FilterBy(Func<UserDto, bool> filter);
    }
}
