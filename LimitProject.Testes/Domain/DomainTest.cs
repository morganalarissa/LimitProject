using LimitProject.Domain.Dtos;
using LimitProject.Domain.Entities;
using LimitProject.Testes.Helper;
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
            Client client = ClientFactory.GetClient();

            string message = $"Id: {client.ClientId}, Name: {client.Name}";
            Console.WriteLine(message);
        }

        private void TestDto()
        {
            ClientDto client = ClientDtoFactory.GetClientDto();

            string message = $"Id: {client.ClientId}, Name: {client.Name}";
            Console.WriteLine(message);
        }

        private void ConvertTestEntityToDto()
        {
            Client client = ClientFactory.GetClient();

            ClientDto dto = client.ConvertToDto();

            string message = $"Id: {dto.ClientId}, Name: {dto.Name}";
            Console.WriteLine(message);
        }

        private void ConvertTestDtoToEntity()
        {
            ClientDto client = ClientDtoFactory.GetClientDto();

            Client entity = client.ConvertToEntity();
            string message = $"Id: {entity.ClientId}, Name: {entity.Name}";
            Console.WriteLine(message);
        }
    }
}
