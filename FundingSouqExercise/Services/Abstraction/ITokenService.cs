using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface ITokenService
    {
        public string CreateToken(UserLoginDTO userLoginDto);
    }
}
