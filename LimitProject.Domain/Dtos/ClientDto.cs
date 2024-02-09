using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Domain.Dtos
{
    public class ClientDto
    {        
            public int ClientId { get; set; }
            public string Document { get; set; }
            public string Name { get; set; }
            public int AgencyNumber { get; set; }
            public int AccountNumber { get; set; }
            public decimal MaximumLimit { get; set; }
            public decimal CurrentLimit { get; set; }
            public DateTime DateTransaction { get; set; } = DateTime.Now;
            public Client ConvertToEntity()
            {
                return new Client
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
            public static List<Client> ConvertToEntity(List<ClientDto> clientsDto)
            {
                List<Client> clients = new List<Client>();

                foreach (ClientDto client in clientsDto)
                {
                    Client entity = client.ConvertToEntity();
                    clients.Add(entity);
                }
                return clients;
            }
    }
}

