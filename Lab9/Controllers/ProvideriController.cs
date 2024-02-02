using Lab9.Helpers.Attributes;
using Lab9.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Repositories.ProvideriRepository;
using Proiect.Services.ProvideriService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvideriController : ControllerBase
    {
        public readonly IProvideriService _provideriService;

        public ProvideriController(IProvideriService provideriService)
        {
            _provideriService = provideriService;
        }

        [Authorize]
        [HttpPost("Create Provider")]
        public async Task<IActionResult> AddProvider(ProviderDTO provider)
        {

            await this._provideriService.AddProvider(provider);
            return Ok();
        }

        [HttpGet("Show all providers")]
        public async Task<IActionResult> GetAllProvideri()
        {
            return Ok(await this._provideriService.GetAllP());

        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteProviderByName(string name)
        {
            await _provideriService.DeleteProvider(name);
            return Ok();
        }

        [Authorize]
        [HttpPatch("Update Provider")]
        public async Task<IActionResult> UpdateProvider(UpdateProviderDTo provider)
        {
            await _provideriService.Update(provider);
            return Ok();    
        }
    }
}
