using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface ISearchService
    {
        Task<ResultWrapper<List<SearchedParameter>>> GetLastParameters(int userId);
    }
}
