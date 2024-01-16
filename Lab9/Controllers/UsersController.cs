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

namespace Lab9.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtUtils _JwtToken;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Test(UserLoginDto userLoginDto)
        {
            return Ok("Users");
        }

        [AllowAnonymous]
        [HttpGet("showData")]
        public async Task<List<User>> GetAllUsers()
        {
            return (await _userService.GetAllAsync());
        }

        [AllowAnonymous]
        [HttpGet("get-user-by-name")]
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
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Models.Enums.Role.User);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRegisterDto userRegisterDto)
        {
            var response = await _userService.Register(userRegisterDto, Models.Enums.Role.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

       


        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok("Account is logged in");
        }


        [Authorize(Role.User)]
        [HttpGet("check-auth-user")]
        public IActionResult GetTextUser()
        {
            return Ok("User is logged in");
        }

        [Authorize(Role.Admin)]
        [HttpGet("check-auth-admin")]
        public IActionResult GetTextAdmin()
        {
            return Ok("Admin is logged in");
        }

        [Authorize(Role.Admin, Role.User)]
        [HttpGet("check-auth-admin-and-user")]
        public IActionResult GetTextAdminUser()
        {
            return Ok("Account is user or admin");
        }

        [AllowAnonymous]
        [HttpDelete("Delete-user")]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            await _userService.Delete(username);
            return Ok();
        }

    }
}
