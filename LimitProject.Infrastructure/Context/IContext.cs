using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Infrastructure.Context
{
    public interface IContext
    {
        public void CreateClient(Client client);
        public List<Client> GetClient();
        public Client GetClientById(int id);        
        public void UpdateClient(Client client);
        public void DeleteClient(int id);
    }
}
