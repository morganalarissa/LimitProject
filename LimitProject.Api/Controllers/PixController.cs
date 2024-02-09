using LimitProject.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimitProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PixController : ControllerBase
    {
        private readonly ClientService _clientService;

        public PixController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("processPix")]
        public async Task<IActionResult> ProcessPix(int clientId, decimal amount)
        {
            bool result = await _clientService.ProcessPixTransaction(clientId, amount);
            if (!result)
            {
                return BadRequest("Transação negada: limite insuficiente.");
            }
            return Ok("Transação processada com sucesso.");
        }

    }
}
