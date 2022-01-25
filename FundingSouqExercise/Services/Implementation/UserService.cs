using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using FundingSouqExercise.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAccountService accountService;

        public UserService(IUserRepository userRepository, IAccountService accountService)
        {
            this.userRepository = userRepository;
            this.accountService = accountService;
        }
        public async Task<ResultWrapper<UserServiceModel>> DeleteUser(int userId)
        {
            var user = userRepository.Find(x=>x.Id == userId);
            if (user == null) return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.UserNotFound,
                Value = null
            };
            
            userRepository.Delete(user);
            userRepository.Save();

            var response = new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
            };

            return response;
        }
        public async Task<ResultWrapper<UserServiceModel>> GetUser(int userId)
        {
            var user = userRepository.Get(x=>x.Id == userId).Include(y=>y.UserType).FirstOrDefault();
            if (user == null) return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.UserNotFound,
                Value = null
            };
            
            var userServiceModel = UserToUserServiceModel(user);
            return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = userServiceModel
            };
        }
        public async Task<ResultWrapper<UserServiceModel>> GetUser(string username)
        {
            var user = userRepository.Get(x => x.Username == username).FirstOrDefault();

            var userServiceModel = UserToUserServiceModel(user);
            return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = userServiceModel
            };
        }
        public async Task<ResultWrapper<List<UserServiceModel>>> GetUsers()
        {
            var users = userRepository.GetAll().Include(x=>x.UserType);
            List<UserServiceModel> usersServiceModel = new List<UserServiceModel>();
            foreach (var user in users)
            {
                usersServiceModel.Add(UserToUserServiceModel(user));
            }
            return new ResultWrapper<List<UserServiceModel>>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = usersServiceModel
            };
        }
        public async Task<ResultWrapper<UserServiceModel>> RegisterUser(UserRegisterDTO userRegisterDto)
        {
            var user = userRepository.Get(x => x.Username == userRegisterDto.Username);
            if (user.FirstOrDefault() != null) return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.UserAlreadyExists,
                Value = null
            };

            var hmac = new HMACSHA512();
            var newUser = new User
            {
                Username = userRegisterDto.Username,
                UserTypeId = userRegisterDto.RoleId,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key,
            };

            userRepository.Create(newUser);
            userRepository.Save();

            var createdUser = userRepository.Get(x => x.Username == newUser.Username).Include(y => y.UserType).FirstOrDefault();
            var createdUserServiceModel = UserToUserServiceModel(createdUser);
            return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = createdUserServiceModel
            };
        }
        public async Task<ResultWrapper<UserServiceModel>> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = userRepository.Find(x => x.Id == userUpdateDto.Id);
            if (user == null) return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.UserNotFound,
            };

            var hmac = new HMACSHA512();
            var newUser = new User
            {
                Id = userUpdateDto.Id,
                Username = userUpdateDto.Username,
                UserTypeId = userUpdateDto.RoleId,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userUpdateDto.Password)),
                PasswordSalt = hmac.Key,
            };

            userRepository.Update(newUser);
            userRepository.Save();
            return new ResultWrapper<UserServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
            };
        }

        #region Private Methods
        private UserServiceModel UserToUserServiceModel(User user)
        {
            UserServiceModel userServiceModel = new UserServiceModel
            {
                Id = user.Id,
                Username = user.Username,
                UserRoleId = user.UserTypeId,
                UserRoleType = user.UserType.Type
            };

            return userServiceModel;
        }
        #endregion
    }
}
