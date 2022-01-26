using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
using FundingSouqExercise.Services;
using FundingSouqExercise.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Controllers
{
    [ApiController]
    public class ClientsController : BaseApiController
    {
        private readonly IClientService clientService;
        private readonly IClientAccountService clientAccountService;
        private readonly ISearchService searchService;

        public ClientsController(IClientService clientService, IClientAccountService clientAccountService, ISearchService searchService)
        {
            this.clientService = clientService;
            this.clientAccountService = clientAccountService;
            this.searchService = searchService;
        }

        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            try
            {
                var result = await clientService.CreateClient(clientDto);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update(ClientDTO clientDto)
        {
            try
            {
                var result = await clientService.UpdateClient(clientDto);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("getclient/{clientId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetClient(int clientId)
        {
            try
            {
                var result = await clientService.GetClient(clientId);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getallclients")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var result = await clientService.GetClients();
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getclients")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetClients([FromQuery] PagingParameters pagingParameters)
        {
            try
            {
                var result = await clientService.GetClients(pagingParameters);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("filter")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> FilterClients([FromBody] ClientServiceModel clientServiceModel)
        {
            try
            {
                var result = await clientService.FilterClients(clientServiceModel);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{clientId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            try
            {
                var result = await clientService.DeleteCLient(clientId);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok(result.Status.ToString());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("createclientaccount")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateClientAccount([FromQuery] ClientAccountServiceModel clientAccount)
        {
            try
            {
                var result = await clientAccountService.Create(clientAccount.ClientId, clientAccount.AccountName);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok("New client account creates succesfully.");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
