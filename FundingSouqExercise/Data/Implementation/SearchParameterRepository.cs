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
    }
}
