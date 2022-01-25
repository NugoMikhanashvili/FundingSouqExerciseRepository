using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class ClientAccountRepository : BaseRepository<ClientAccount>, IClientAccountRepository
    {
        private readonly DbContext dbContext;

        public ClientAccountRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
