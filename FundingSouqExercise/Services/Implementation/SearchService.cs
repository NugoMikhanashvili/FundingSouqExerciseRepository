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


    }
}
