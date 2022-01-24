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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace FundingSouqExercise.Controllers
{
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IAccountService accountService)
        {
            _dbContext = dbContext;
            _accountService = accountService;
            _userService = userService;
        }

        [HttpGet("getuser/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var result = await _userService.GetUser(userId);
                if (result.Value == null) return BadRequest(result.Status.ToString());

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getallusers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetUsers();
                if (result.Value == null) return BadRequest(result.Status.ToString());
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> RegisterUser(UserRegisterDTO userRegisterDto)
        {
            try
            {
                var result = await _userService.RegisterUser(userRegisterDto);
                if (result.Value == null) return BadRequest(result.Status.ToString());

                return Ok($"User registered successfully. \n UserId: {result.Value.Id} \n UserName: {result.Value.Username} \n " +
                          $"RoleId: Role: {result.Value.UserRoleId} \nRole: {result.Value.UserRoleType}");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var result = await _userService.UpdateUser(userUpdateDto);
                if (result.Status != Common.ResultCodeEnum.Code200Success)
                {
                    return BadRequest(result.Status.ToString());
                }

                return Ok($"User updated successfully. \n UserId: {userUpdateDto.Id} \n Username: {userUpdateDto.Username} " +
                          $"\n UserRoleId: {userUpdateDto.RoleId}");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{userId}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var result = await _userService.GetUser(userId);
                if (result.Value == null) return BadRequest(result.Status.ToString());

                var response = await _userService.DeleteUser(result.Value.Id);
                if (response.Status != Common.ResultCodeEnum.Code200Success) return BadRequest(response.Status);

                return Ok(response.Status);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
