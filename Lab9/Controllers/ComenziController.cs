using Lab9.Helpers.Attributes;
using Lab9.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Data.Models;
using Proiect.Services.ComenziArticoleService;
using Proiect.Services.ComenziService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController:ControllerBase
    {
        public readonly IComenziService _comenziService;
        public readonly IComenziArticolService _comenziArticolService;

        public ComenziController(IComenziService comenziService, IComenziArticolService comenziArticolService)
        {
            _comenziService = comenziService;
            _comenziArticolService = comenziArticolService;
        }

        [HttpGet]
        [Authorize(Role.Admin,Role.User)]
        public async Task<IActionResult> GetAllComenzi()
        {
            return Ok(await this._comenziService.GetAllC());
        }
        [HttpPost("Create comanda")]
        public async Task<IActionResult> AddComanda(ComandaDTO comanda)
        {
            await this._comenziService.AddComanda(comanda);
            return Ok();
        }

        [Authorize(Role.Admin, Role.User)]
        [HttpPost("Add Articol to comanda")]
        public async Task<IActionResult> AddArticolToComanda(Guid IdComanda, Guid IdUser)
        {
            await this._comenziArticolService.AddArticolToComanda(IdComanda,IdUser);
            return Ok();
        }


        [Authorize(Role.Admin, Role.User)]
        [HttpDelete]
        public async Task<IActionResult> DeleteComanda(Guid id)
        {
            await _comenziService.DeleteComanda(id);
            return Ok();
        }
    }
}
