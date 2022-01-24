using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Implementation
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly DbContext dbContext;

        public ClientRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Client> GetClient(int clientId)
        {
            return dbContext.Set<Client>().Where(c => c.Id == clientId);
        }
        public IQueryable<Client> GetClients()
        {
            throw new NotImplementedException();
        }
    }
}
