using FundingSouqExercise.Common;
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
    public class AccountService : BaseService, IAccountService
    {
        private readonly DbContext dbContext;

        public AccountService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ResultWrapper<User>> VerifyUser(UserLoginDTO userLoginDto)
        {
            // Check user
            var user = dbContext.Set<User>().Where(x => x.Username == userLoginDto.Username).Include(y=>y.UserType).FirstOrDefault();
            if (user == null) return new ResultWrapper<User>
            {
                Status = ResultCodeEnum.UserNotFound,
                Value = null
            };

            // Decrypt password
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for (int i = 0; i < computerHash.Length; i++)
            {
                if (computerHash[i] != user.PasswordHash[i]) return null;
            }
            return new ResultWrapper<User>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = user
            };
        }
    }
}
