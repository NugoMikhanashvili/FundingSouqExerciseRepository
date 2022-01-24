using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface IUserService : IBaseService
    {
        public Task<ResultWrapper<UserServiceModel>> RegisterUser(UserRegisterDTO userRegisteDto);
        public Task<ResultWrapper<UserServiceModel>> GetUser(int userId);
        public Task<ResultWrapper<UserServiceModel>> GetUser(string username);
        public Task<ResultWrapper<List<UserServiceModel>>> GetUsers();
        public Task<ResultWrapper<UserServiceModel>> UpdateUser(UserUpdateDto userUpdateDto);
        public Task<ResultWrapper<UserServiceModel>> DeleteUser(int userId);
    }
}
