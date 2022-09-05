using SEDC.WebApi.Workshop.Notes.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUser registerUser);
        UserLoginDto Login(LoginModel request);
    }
}
