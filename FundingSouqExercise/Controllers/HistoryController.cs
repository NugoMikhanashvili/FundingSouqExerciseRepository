using FundingSouqExercise.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Controllers
{
    [ApiController]
    public class HistoryController : BaseApiController
    {
        private readonly ISearchService searchService;

        public HistoryController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet("lastparameters/{userId}")]
        public async Task <IActionResult> GetLastSearchParameters(int userId)
        {
            try
            {
                var result = await searchService.GetLastParameters(userId);
                if (result.Status != Common.ResultCodeEnum.Code200Success) return BadRequest(result.Status.ToString());

                return Ok(result.Value);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
