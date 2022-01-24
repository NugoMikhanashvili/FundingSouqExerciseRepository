using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface IAccountService : IBaseService
    {
        public Task<ResultWrapper<User>> VerifyUser(UserLoginDTO userLoginDto);
    }
}
