using LimitProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Infrastructure.Repositories
{
    public interface IClientRepository
    {
        public void Save(Client client);
        public void Update(Client client);
        public void Delete(int id);
        public Client Search(int id);
        public List<Client> List();

    }
}
