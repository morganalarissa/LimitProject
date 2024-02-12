using LimitProject.Domain.Dtos;
using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LimitProject.Testes.Helper
{
    public static class ClientDtoFactory
    {
        public static ClientDto GetClientDto()
        {
            ClientDto client = new ClientDto
            {
                ClientId = 1,
                Document = "001",
                Name = "Morgana",
                AgencyNumber = 0001,
                AccountNumber = 12354,
                MaximumLimit = 500,
                CurrentLimit = 50,
                DateTransaction = DateTime.Now,
            };
            
            return client;
        }
    }
}
