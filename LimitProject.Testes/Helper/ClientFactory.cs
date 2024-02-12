using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Testes.Helper
{
    public class ClientFactory
    {
        public static Client GetClient() 
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

            return client;
        }

        public static Client GetNewClient()
        {
            Client client = new Client
            {
                ClientId = 15,
                Name = "Eliane",
                Document = "54848",
                AgencyNumber = 5,
                AccountNumber = 5515,
                MaximumLimit = 10,
                CurrentLimit = 10,
                DateTransaction = DateTime.Now,
            };
            return client;
        }
    }
}
