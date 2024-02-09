using Amazon.DynamoDBv2.DataModel;
using LimitProject.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Domain.Entities
{
    [DynamoDBTable("clients")]
    public class Client
    {
        [DynamoDBProperty("id")] 
        public int ClientId { get; set; }

        [DynamoDBHashKey("document")]
        public string Document { get; set; }

        [DynamoDBRangeKey("name")]
        public string Name { get; set; }

        [DynamoDBProperty("agencyNumber")]
        public int AgencyNumber { get; set; }

        [DynamoDBProperty("accountNumber")]
        public int AccountNumber { get; set; }

        [DynamoDBProperty("maximumLimit")]
        public decimal MaximumLimit { get; set; }

        [DynamoDBProperty("currentLimit")]
        public decimal CurrentLimit { get; set; }

        [DynamoDBProperty("dateTransaction")]
        public DateTime DateTransaction { get; set; } = DateTime.Now;

        public ClientDto ConvertToDto()
        {
            return new ClientDto
            {
                ClientId = this.ClientId,
                Document = this.Document,
                Name = this.Name,
                AgencyNumber = this.AgencyNumber,
                AccountNumber = this.AccountNumber,
                MaximumLimit = this.MaximumLimit,
                CurrentLimit = this.CurrentLimit,
                DateTransaction = this.DateTransaction
            };
        }
        public static List<ClientDto> ConvertToDto(List<Client> clients)
        {
            List<ClientDto> clientsDto = new List<ClientDto>();

            foreach (Client client in clients)
            {
                ClientDto dto = client.ConvertToDto();
                clientsDto.Add(dto);
            }
            return clientsDto;
        }
    }
}
