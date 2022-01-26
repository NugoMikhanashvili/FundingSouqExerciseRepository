using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface ISearchService
    {
        public Task<ResultWrapper<ResultCodeEnum>> SaveSearchedFilter (ClientServiceModel clientServiceModel, int userId);
        public Task<ResultWrapper<List<ClientFilter>>> GetLastFilters(int userId);
    }
}