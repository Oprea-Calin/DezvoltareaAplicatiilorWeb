using Microsoft.AspNetCore.Mvc;
using Proiect.Data.DTOs;
using Proiect.Services.ArticoleService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoleController: ControllerBase
    {
        public readonly IArticoleService _articoleService;
    
        public ArticoleController(IArticoleService articoleService)
        {
            _articoleService = articoleService;
        }

        [HttpPost]
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
    }
}
