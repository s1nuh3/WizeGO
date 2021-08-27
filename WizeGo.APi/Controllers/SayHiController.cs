using Microsoft.AspNetCore.Mvc;

namespace WizeGo.APi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SayHiController : ControllerBase
    {
        [HttpGet]
        public object GetGreetings()
        {            
            return Ok(new { greetings = "Hello World" });
        }
    }
}
