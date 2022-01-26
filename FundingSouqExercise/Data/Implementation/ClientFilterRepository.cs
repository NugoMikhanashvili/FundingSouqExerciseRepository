using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class ClientFilterRepository : BaseRepository<ClientFilter>, IClientFilterRepository
    {
        private DbContext dbContext;

        public ClientFilterRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
