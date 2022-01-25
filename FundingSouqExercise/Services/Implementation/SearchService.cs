using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly ISearchedParameterRepository searchParameterRepository;

        public SearchService(ISearchedParameterRepository searchParameterRepository)
        {
            this.searchParameterRepository = searchParameterRepository;
        }

        public async Task<ResultWrapper<List<SearchedParameter>>> GetLastParameters(int userId)
        {
            var result = searchParameterRepository.GetSearchedParameters(userId);
            if (result.Count == 0) return new ResultWrapper<List<SearchedParameter>>
            {
                Status = ResultCodeEnum.UserNotFound,
                Value = null
            };

            return new ResultWrapper<List<SearchedParameter>>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = result
            };
        }
    }
}
