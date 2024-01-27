using Lab9.Helpers.Attributes;
using Lab9.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Services.ComenziService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController:ControllerBase
    {
        public readonly IComenziService _comenziService;

        public ComenziController(IComenziService comenziService)
        {
            _comenziService = comenziService;
        }

        [HttpGet]
        //[Authorize(Role.Admin,Role.User)]
        public async Task<IActionResult> GetAllComenzi()
        {
            return Ok(await this._comenziService.GetAllC());
        }

        [HttpPost]
        //[Authorize(Role.Admin,Role.User)]
        public async Task<IActionResult> AddComanda(ComandaDTO comanda)
        {
             await this._comenziService.AddComanda(comanda);
            return Ok();
        }
    }
}
