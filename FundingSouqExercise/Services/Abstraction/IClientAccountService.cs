using FundingSouqExercise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface IClientAccountService
    {
        public Task<ResultWrapper<ResultCodeEnum>> Create(int clientId, string accountName);
    }
}
