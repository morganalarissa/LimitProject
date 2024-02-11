using LimitProject.Domain.Dtos;
using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Testes.Domain
{
    public class DomainTest
    {
        public void Execute()
        {
            TestEntity();
            TestDto();
            ConvertTestEntityToDto();
            ConvertTestDtoToEntity();
        }
        private void TestEntity()
        {
            Client client = new Client
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

            string message = $"Id: {client.ClientId}, Name: {client.Name}";
            Console.WriteLine(message);
        }

        private void TestDto()
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

            string message = $"Id: {client.ClientId}, Name: {client.Name}";
            Console.WriteLine(message);
        }

        private void ConvertTestEntityToDto()
        {
            Client client = new Client
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

            ClientDto dto = client.ConvertToDto();

            string message = $"Id: {dto.ClientId}, Name: {dto.Name}";
            Console.WriteLine(message);
        }

        private void ConvertTestDtoToEntity()
        {
            ClientDto client = new ClientDto
            {
                ClientId = 1,
                Document = "001",
                Name = "Pedro",
                AgencyNumber = 0001,
                AccountNumber = 12354,
                MaximumLimit = 500,
                CurrentLimit = 50,
                DateTransaction = DateTime.Now,
            };

            Client entity = client.ConvertToEntity();
            string message = $"Id: {entity.ClientId}, Name: {entity.Name}";
            Console.WriteLine(message);
        }
    }
}
