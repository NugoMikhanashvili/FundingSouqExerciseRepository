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
    public class ClientAccountService : IClientAccountService
    {
        private readonly IClientAccountRepository clientAccountRepository;
        private readonly IClientRepository clientRepository;

        public ClientAccountService(IClientAccountRepository clientAccountRepository, IClientRepository clientRepository)
        {
            this.clientAccountRepository = clientAccountRepository;
            this.clientRepository = clientRepository;
        }

        public async Task<ResultWrapper<ResultCodeEnum>> Create(int clientId, string accountName)
        {
            var client = clientRepository.Find(x => x.Id == clientId);
            if (client == null) return new ResultWrapper<ResultCodeEnum>
            {
                Status = ResultCodeEnum.ClientNotFound,
            };

            var newAccount = new ClientAccount
            {
                ClientId = clientId,
                AccoundName = accountName
            };

            clientAccountRepository.Create(newAccount);
            clientAccountRepository.Save();
            return new ResultWrapper<ResultCodeEnum>
            {
                Status = ResultCodeEnum.Code200Success,
            };
        }
    }
}
