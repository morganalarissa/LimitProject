using LimitProject.Domain.Dtos;
using LimitProject.Domain.Entities;
using LimitProject.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LimitProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public List<ClientDto> Get()
        {
            try
            {
                List<Client> clients = _clientService.List();
                List<ClientDto> clientsDto = clients != null ? Client.ConvertToDto(clients) : null;

                return clientsDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("{id}")]
        public ClientDto Get(int id)
        {
            try
            {
                Client client = _clientService.Search(id);
                ClientDto dto = client != null ? client.ConvertToDto() : null;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                _clientService.Delete(id);
                return $"Cliente excluído com sucesso id:{id}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public string Post([Bind("name, document, agencyNumber, accountNumber, maximumLimit, currentLimit, dateTransaction")]ClientDto clientDto)
        {
            try
            {
                Client client = clientDto.ConvertToEntity();
                _clientService.Save(client);
                return $"{client.Name} sua conta foi criada com sucesso. Id: {client.ClientId}";
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        [HttpPut]
        public string Put([FromBody]ClientDto clientDto)
        {
            try
            {
                Client client = clientDto.ConvertToEntity();
                _clientService.Update(client);
                return $"Cliente: {client.Name} atualizado com sucesso. Id: {client.ClientId}";
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
