using LimitProject.Domain.Entities;
using LimitProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Services.Service
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public List<Client> List()
        {
            return _clientRepository.List();
        }
        public Client Search(int id)
        {
            return _clientRepository.Search(id);
        }

        public void Save(Client client) 
        {
            _clientRepository.Save(client);
        }
        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }
    }
}
