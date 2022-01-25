using FundingSouqExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using FundingSouqExercise.Services;
using FundingSouqExercise.Services.Abstraction;
using FundingSouqExercise.Data.Domain.POCO;

namespace FundingSouqExercise.Controllers
{
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly ITokenService tokenService;
        private readonly IAccountService accountService;

        public AccountController(ITokenService tokenService, IAccountService accountService)
        {
            this.tokenService = tokenService;
            this.accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDto)
        {
            try
            {
                var result = await accountService.VerifyUser(userLoginDto);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }
                // Create token
                var user = result.Value;
                var token = tokenService.CreateToken(user);

                // Produce response
                return Ok($"User successfully logged in. \n Username: {userLoginDto.Username} \n Token: Bearer {token}");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("");
            return RedirectToAction(nameof(Login));
        }
    }
}
