using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using LimitProject.Domain.Entities;
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
        private readonly IDynamoDBContext _dbContext;

        public ClientRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dbContext = new DynamoDBContext(dynamoDBClient);
        }

        public async Task CreateAsync(Client client)
        {
            await _dbContext.SaveAsync(client);
        }

        public async Task UpdateAsync(Client client)
        {
            await _dbContext.SaveAsync(client);
        }

        public async Task DeleteAsync(string document, string name)
        {
            await _dbContext.DeleteAsync<Client>(document, name);
        }

        public async Task<Client> SearchAsync(int id)
        {
            return await _dbContext.LoadAsync<Client>(id);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _dbContext.ScanAsync<Client>(conditions).GetRemainingAsync();
        }
    }
}
