using LimitProject.Domain.Entities;
using LimitProject.Infrastructure.Context;
using LimitProject.Testes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Testes.Contexts
{
    public class FakeContextTest
    {
        private readonly IContext _context;
        public FakeContextTest()
        {
            _context = new FakeContext();
        }

        public void Execute()
        {
            TestList();
            TestInclusion();
        }
        private void TestList()
        {
            List<Client> clients = _context.GetClient();
            foreach (Client item in clients)
            {
                Console.WriteLine($"Id:{item.ClientId}, Nome:{item.Name}");
            }
        }

        private void TestInclusion()
        {
            Client client = ClientFactory.GetNewClient();
            client.ClientId = 40;
            _context.CreateClient(client);
            Client result = _context.GetClientById(client.ClientId);
        }

    }
}
