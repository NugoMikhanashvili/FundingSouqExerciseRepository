using FundingSouqExercise.Common;
using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using FundingSouqExercise.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Services.Implementation
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository clientRepository;
        public ClientService (IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<ResultWrapper<ClientServiceModel>> CreateClient(ClientDTO clientDto)
        {
            var client = clientRepository.Find(x => x.PersonalId == clientDto.PersonalId);
            if (client != null) return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.ClientWithThisPersonalIdAlreadyExists,
                Value = null
            };

            var newClient = new Client
            {
                Firstname = clientDto.Firstname,
                Lastname = clientDto.Lastname,
                PersonalId = clientDto.PersonalId,
                Sex = clientDto.Sex,
                ProfilePhoto = clientDto.ProfilePhoto,
                Email = clientDto.Email,
                MobileNumber = clientDto.MobileNumber,
                Country = clientDto.Country,
                City = clientDto.City,
                Street = clientDto.Street,
                ZipCode = clientDto.ZipCode,
            };

            clientRepository.Create(newClient);
            clientRepository.Save();

            var createdClient = clientRepository.Get(x => x.PersonalId == newClient.PersonalId).FirstOrDefault();
            var clientServiceModel = ClientToClientServiceModel(createdClient);
            var result = new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = clientServiceModel
            };

            return result;
        }

        public async Task<ResultWrapper<ClientServiceModel>> DeleteCLient(int personalId)
        {
            var client = clientRepository.Get(x => x.PersonalId == personalId).FirstOrDefault();
            if (client == null) return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.ClientNotFound,
                Value = null
            };

            clientRepository.Delete(client);
            clientRepository.Save();
            return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
            };
        }

        public async Task<ResultWrapper<ClientServiceModel>> UpdateClient(ClientDTO clientDto)
        {
            var client = clientRepository.Get(x => x.PersonalId == clientDto.PersonalId).FirstOrDefault();
            if (client == null) return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.ClientNotFound,
                Value = null
            };
            var newClient = new Client
            {
                Id = client.Id,
                Firstname = clientDto.Firstname,
                Lastname = clientDto.Lastname,
                Sex = clientDto.Sex,
                PersonalId = clientDto.PersonalId,
                ProfilePhoto = clientDto.ProfilePhoto,
                Email = clientDto.Email,
                MobileNumber = clientDto.MobileNumber,
                Country = clientDto.Country,
                City = clientDto.City,
                Street = clientDto.Street,
                ZipCode = clientDto.ZipCode
            };
            clientRepository.Update(newClient);
            clientRepository.Save();

            return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = ClientToClientServiceModel(newClient)
            };
        }

        public async Task<ResultWrapper<ClientServiceModel>> GetClient(int personalId)
        {
            var client = clientRepository.Get(x => x.PersonalId == personalId).FirstOrDefault();
            if (client == null) return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.ClientNotFound,
                Value = null,
            };

            return new ResultWrapper<ClientServiceModel>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = ClientToClientServiceModel(client)
            };
        }

        public async Task<ResultWrapper<List<ClientServiceModel>>> GetClients()
        {
            var clients = clientRepository.GetAll().ToList();
            if (clients == null) return new ResultWrapper<List<ClientServiceModel>>
            {
                Status = ResultCodeEnum.ClientNotFound,
                Value = null,
            };
            List<ClientServiceModel> clientsServiceModel = new List<ClientServiceModel>();
            foreach (var client in clients)
            {
                clientsServiceModel.Add(ClientToClientServiceModel(client));
            }

            return new ResultWrapper<List<ClientServiceModel>>
            {
                Status = ResultCodeEnum.Code200Success,
                Value = clientsServiceModel
            };
        }

        #region Private Methods
        private ClientServiceModel ClientToClientServiceModel(Client client)
        {
            ClientServiceModel clientServiceModel = new ClientServiceModel
            {

                Id = client.Id,
                Firstname = client.Firstname,
                Lastname = client.Lastname,
                Sex = client.Sex,
                PersonalId = client.PersonalId,
                ProfilePhoto = client.ProfilePhoto,
                Email = client.Email,
                MobileNumber = client.MobileNumber,
                Country = client.Country,
                City = client.City,
                Street = client.Street,
                ZipCode = client.ZipCode
            };
            return clientServiceModel;
        } 
        #endregion
    }
}
