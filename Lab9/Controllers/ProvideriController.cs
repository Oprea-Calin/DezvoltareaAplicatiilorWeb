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

        [HttpPost("Create Provider")]
        public async Task<IActionResult> AddProvider(ProviderDTO provider)
        {

            await this._provideriService.AddProvider(provider);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProvideri()
        {
            return Ok(await this._provideriService.GetAllP());

        }
    }
}
