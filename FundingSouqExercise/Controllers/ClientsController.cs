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

        public ClientsController(IClientService clientService, IClientAccountService clientAccountService)
        {
            this.clientService = clientService;
            this.clientAccountService = clientAccountService;
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

        [HttpGet("getclient/{personalId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetClient(int personalId)
        {
            try
            {
                var result = await clientService.GetClient(personalId);
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
                return Ok($"Count: {result.Value.Count} \n {result}");
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

        [HttpDelete("deleteclient/{personalId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteClient(string personalId)
        {
            try
            {
                var result = await clientService.DeleteCLient(personalId);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                return Ok();
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
