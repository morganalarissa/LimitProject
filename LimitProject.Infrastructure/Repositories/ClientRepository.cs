using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using LimitProject.Domain.Entities;
using LimitProject.Domain.Enum;
using LimitProject.Domain.Setup;
using LimitProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IContext _context;
        public ClientRepository() 
        { 
            if(AppConfiguration.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                _context = new FakeContext();
            }
        }
        public void Delete(int id)
        {
            _context.DeleteClient(id);
        }

        public List<Client> List()
        {
            return _context.GetClient();   
        }

        public void Save(Client client)
        {
            _context.CreateClient(client);
        }

        public Client Search(int id)
        {
            return _context.GetClientById(id);
        }

        public void Update(Client client)
        {
            _context.UpdateClient(client);
        }
    }
}
