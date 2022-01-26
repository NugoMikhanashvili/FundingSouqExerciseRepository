using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using FundingSouqExercise.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly IClientFilterRepository clientFilterRepository;
        private readonly IUserRepository userRepository;

        public SearchService(IClientFilterRepository clientFilterRepository, IUserRepository userRepository)
        {
            this.clientFilterRepository = clientFilterRepository;
            this.userRepository = userRepository;
        }

        public async Task<ResultWrapper<List<ClientFilter>>> GetLastFilters(int userId)
        {
            var filterHistory = clientFilterRepository.Get(x => x.UserId == userId);
            if(filterHistory.Count() > 3)
            {
                var lastThree = filterHistory.Skip(filterHistory.Count() - 3).ToList();
                return new ResultWrapper<List<ClientFilter>>
                {
                    Status = ResultCodeEnum.Code200Success,
                    Value = lastThree
                };
            }

            return new ResultWrapper<List<ClientFilter>>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = filterHistory.ToList()
            };
                
        }

        public async Task<ResultWrapper<ResultCodeEnum>> SaveSearchedFilter(ClientServiceModel clientServiceModel, int userId)
        {
            var newClientFilter = new ClientFilter
            {
                UserId = userId,
                ClientId = clientServiceModel.Id,
                Firstname = clientServiceModel.Firstname,
                Lastname = clientServiceModel.Lastname,
                Sex = clientServiceModel.Sex,
                PersonalId = clientServiceModel.PersonalId,
                ProfilePhoto = clientServiceModel.ProfilePhoto,
                Email = clientServiceModel.Email,
                MobileNumber = clientServiceModel.MobileNumber,
                Country = clientServiceModel.Country,
                City = clientServiceModel.City,
                Street = clientServiceModel.Street,
                ZipCode = clientServiceModel.ZipCode
            };

            clientFilterRepository.Create(newClientFilter);
            clientFilterRepository.Save();
            return new ResultWrapper<ResultCodeEnum>
            {
                Status = ResultCodeEnum.Code200Success
            };
        }
    }
}
