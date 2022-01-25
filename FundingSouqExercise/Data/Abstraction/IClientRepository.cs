using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using FundingSouqExercise.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Data.Abstraction
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        public IQueryable<Client> GetClients();
        public PagedList<Client> GetClients(PagingParameters pagingParameter);
        public IQueryable<Client> GetClient(int clientId);

    }
}
