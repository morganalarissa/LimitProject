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

        public async Task<bool> ProcessPixTransaction(int clientId, decimal transactionAmount)
        {
            var client = await _clientRepository.GetClientByIdAsync(clientId);
            if (client == null) return false;

            if (client.CurrentLimit >= transactionAmount)
            {
                client.CurrentLimit -= transactionAmount;
                await _clientRepository.UpdateAsync(client);
                return true;
            }
            return false;
        }
    }
}
