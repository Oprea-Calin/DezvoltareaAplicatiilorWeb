using Lab9.Data.DTOs;
using Lab9.Helpers.Attributes;
using Lab9.Models.Enums;
using Lab9.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Lab9.Helpers.JwtUtil;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok( await _userService.GetAllAsync());
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
        [HttpPut("AssignRole")]
        [Authorize(Role.Admin)] 
        public async Task<IActionResult> AssignRoleToUser([FromQuery] string username, [FromQuery] Role role)
        {
            try
            {
                await _userService.AssignRoleToUser(username, role);
                return Ok("Rolul a fost atribuit cu succes.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProfile")]
        [Authorize(Role.Admin)]
        public async Task<IActionResult> UpdateProfile([FromBody] Role model)
        {
            // Obținem ID-ul utilizatorului autentificat din claim-urile token-ului JWT
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Jti);

            var result = await _userService.UpdateUserRole(userId, model);
            if (result)
            {
                return Ok(new { message = " Profilul a fost actualizat cu succes." });
            }
            return BadRequest("Actualizarea profilului a eșuat.");
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
    }
}
