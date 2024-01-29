using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Services.ArticoleService;
using Proiect.Services.ComenziArticoleService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoleController: ControllerBase
    {
        public readonly IArticoleService _articoleService;
        public readonly IComenziArticolService _comenziArticolService;
    
        public ArticoleController(IArticoleService articoleService, IComenziArticolService comenziArticolService)
        {
            _articoleService = articoleService;
            _comenziArticolService = comenziArticolService;
        }

        [HttpPost("Create Articol")]
        public async Task<IActionResult> AddArticol(ArticolDTO articol)
        {
            await this._articoleService.AddArticol(articol);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticole()
        {
            return Ok(await this._articoleService.GetAllAsync());
        }
        [HttpPost("AddArticolToComanda")]
        public async Task<IActionResult> AddArticolToComanda(Guid idArticol,Guid idComanda)
        {
            await _comenziArticolService.AddArticolToComanda( idComanda, idArticol);
            return Ok();
        }
    }
}
