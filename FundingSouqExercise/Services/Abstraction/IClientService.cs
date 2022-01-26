using FundingSouqExercise.Common;
using FundingSouqExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Abstraction
{
    public interface IClientService : IBaseService
    {
        public Task<ResultWrapper<ClientServiceModel>> CreateClient(ClientDTO client);
        public Task<ResultWrapper<ClientServiceModel>> GetClient(int id);
        public Task<ResultWrapper<List<ClientServiceModel>>> GetClients();
        public Task<ResultWrapper<List<ClientServiceModel>>> GetClients(PagingParameters pagingParameters);
        public Task<ResultWrapper<List<ClientServiceModel>>> FilterClients(ClientServiceModel clientServiceModel);
        public Task<ResultWrapper<ClientServiceModel>> DeleteCLient(int clientId);
        public Task<ResultWrapper<ClientServiceModel>> UpdateClient(ClientDTO clientDto);

    }
}
