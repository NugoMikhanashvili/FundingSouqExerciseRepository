using FundingSouqExercise.Data.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Abstraction
{
    public interface ISearchedParameterRepository
    {
        List<SearchedParameter> GetSearchedParameters(int userId);
    }
}
