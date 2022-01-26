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

    }
}
