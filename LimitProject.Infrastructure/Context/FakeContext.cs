using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LimitProject.Infrastructure.Context
{
    public class FakeContext : IContext
    {
        private List<Client> _clients;
        public FakeContext() 
        {
            LoadData();
        }

        public void CreateClient(Client client)
        {
            _clients.Add(client);
        }

        public List<Client> GetClient()
        {
            return _clients
                .OrderBy(p => p.ClientId)
                .ToList();
        }

        public Client GetClientById(int id)
        {
            Client result = _clients.FirstOrDefault(p => p.ClientId.Equals(id));

            return result;
        }

        public void UpdateClient(Client client)
        {
            Client searchObj = GetClientById(client.ClientId);
            _clients.Remove(searchObj);

            searchObj = new Client
            {
                Name = !string.IsNullOrEmpty(client.Name) ? client.Name : searchObj.Name,
                Document = !string.IsNullOrEmpty(client.Document) ? client.Document : searchObj.Document
            };
            _clients.Add(searchObj);
        }

        public void DeleteClient(int id)
        {
            Client client = GetClientById(id);
            if (client != null) 
                _clients.Remove(client);
        }

        private void LoadData()
        {
            _clients = new List<Client>();

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
            _clients.Add(client);
            client = new Client
            {
                ClientId = 2,
                Document = "001",
                Name = "Pedro",
                AgencyNumber = 0001,
                AccountNumber = 12354,
                MaximumLimit = 500,
                CurrentLimit = 50,
                DateTransaction = DateTime.Now,
            };
            _clients.Add(client);
        }
    }
}
