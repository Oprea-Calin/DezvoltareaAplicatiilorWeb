using Lab9.Data.DTOs;
using Lab9.Helpers.Attributes;
using Lab9.Models.Enums;
using Lab9.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Lab9.Helpers.JwtUtil;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Lab9.Models;
using Proiect.Data.DTOs;

namespace Lab9.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {   
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

       

        [AllowAnonymous]
        [HttpGet("getAllUsers")]
        public async Task<List<User>> GetAllUsers()
        {
            return (await _userService.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet("getUserById")]
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return (await _userService.GetById(id));
        }

        [AllowAnonymous]
        [HttpGet("getUserByName")]
        public async Task<User> GetUserById(string name)
        {
            return (await _userService.GetByName(name));
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var response = await _userService.Login(userLoginDto);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Role.User);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Role.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            await _userService.Delete(username);
            return Ok();
        }

        [Authorize(Role.Admin)]
        [HttpPatch("Update User")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO user)
        {
            await _userService.Update(user);
            return Ok();
        }

    }
}
