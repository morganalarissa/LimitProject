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
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(string document, string name);
        Task<Client> SearchAsync(int id);
        Task<List<Client>> GetAllAsync();

    }
}
