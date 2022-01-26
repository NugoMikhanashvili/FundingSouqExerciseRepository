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
        private readonly IUserRepository userRepository;

        public SearchService(ISearchedParameterRepository searchParameterRepository, IUserRepository userRepository)
        {
            this.searchParameterRepository = searchParameterRepository;
            this.userRepository = userRepository;
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

        public async Task<ResultWrapper<ResultCodeEnum>> SaveSearchedParameter(string username, string searchParameterName, string searchParameterValue)
        {
            var user = userRepository.Find(x => x.Username == username);
            if (user == null) return new ResultWrapper<ResultCodeEnum>
            {
                Status = ResultCodeEnum.UserNotFound
            };

            var newSearchedParameter = new SearchedParameter
            {
                UserId = user.Id,
                ParameterName = searchParameterName,
                ParameterValue = searchParameterValue
            };

            searchParameterRepository.Create(newSearchedParameter);
            searchParameterRepository.Save();
            return new ResultWrapper<ResultCodeEnum>
            {
                Status = ResultCodeEnum.Code200Success,
            };
        }
    }
}
