using DecomposeNumberApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DecomposeNumberApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecomposeNumberController : ControllerBase
    {

        private readonly ILogger<DecomposeNumberController> _logger;
        private readonly DecomposeNumberService service;
        public DecomposeNumberController(ILogger<DecomposeNumberController> logger)
        {
            _logger = logger;
            service = new DecomposeNumberService();
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> GetAsync(int number)
        {
            var service = new DecomposeNumberService();

            try{ 
               
                return Ok(await service.GetDecomposeAsync(number));
            }
            catch (Exception){ return BadRequest();}
        }
    }
}
