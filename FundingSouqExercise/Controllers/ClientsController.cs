using FundingSouqExercise.Data.Domain.POCO;
using FundingSouqExercise.Models;
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

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost("create")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpDelete("deleteclient/{personalId}")]
        [Authorize]
        public async Task<IActionResult> DeleteClient(int personalId)
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
    }
}
