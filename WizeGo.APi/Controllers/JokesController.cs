using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WizeGo.APi.Interfaces;
using WizeGo.APi.Models;

namespace WizeGo.APi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokesService _jokes;
        private readonly ILogger<JokesController> _logger;
        public JokesController(IJokesService jokes, ILogger<JokesController> logger)
        {
            _jokes = jokes;
            _logger = logger;
        }

        [HttpGet("{category?}")]
        public async Task<ActionResult<JokeDTO>> GetJoke(string category)
        {   
            try
            {
                var joke = await _jokes.GetJoke(category);  
                if (joke.Id == 0)
                    return NotFound();

                return Ok(new JokeDTO { Start = joke.Setup , Finish = joke.Punchline });
            }
            catch (System.Exception ex)
            {
                _logger.LogError((EventId) 0,ex,"An error occured while fetching a joke..");
                return StatusCode(500);
                throw;
            }
        }
    }
}
