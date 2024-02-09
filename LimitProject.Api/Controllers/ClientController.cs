//using LimitProject.Domain.Dtos;
using LimitProject.Domain.Entities;
using LimitProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LimitProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            await _clientRepository.CreateAsync(client);
            return Ok(client);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientRepository.SearchAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            await _clientRepository.UpdateAsync(client);
            return Ok(client);
        }

        [HttpDelete("{document}")]
        public async Task<IActionResult> DeleteClient(string document, string name)
        {
            await _clientRepository.DeleteAsync(document, name);
            return NoContent();
        }
    }
}