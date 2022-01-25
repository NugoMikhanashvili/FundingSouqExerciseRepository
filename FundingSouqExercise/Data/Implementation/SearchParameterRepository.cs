using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class SearchedParameterRepository : BaseRepository<SearchedParameter>, ISearchedParameterRepository
    {
        private DbContext dbContext;

        public SearchedParameterRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<SearchedParameter> GetSearchedParameters(int userId)
        {
            var result = Get().Where(x => x.UserId == userId).OrderByDescending(y => y.Id);
            int count = result.Count();
            if (count > 3)
            {
                var lastThree = result.Skip(count - 3).ToList();
                return lastThree;
            }

            return result.ToList();
        }
    }
}
