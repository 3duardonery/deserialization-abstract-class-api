using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] CarteiraDeClientes carteira)
        {
            var carteiraCopia = carteira;

            return Created("success", carteiraCopia);
        }
    }
}
