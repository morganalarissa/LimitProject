using LimitProject.Domain.Entities;
using LimitProject.Infrastructure.Repositories;
using LimitProject.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Testes.Services
{
    public class ServiceTest
    {
        private readonly ClientService _clientService;
        public ServiceTest(ClientService clientService)
        {
            _clientService = clientService;

        }

        public void Execute()
        {
            try
            {
                ValidateClientList();
                ValidateClientSearch();
                ValidateClientRegister();
                ValidateClientUpdate();
                ValidateClientExclusion();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ValidateClientList()
        {
            Console.WriteLine("\nService Test : ValidateClientList");
            List<Client> clients = _clientService.List();
            foreach (Client client in clients)
            {
                Console.WriteLine($"Ïd:{client.ClientId}, Documento: {client.Document}, Nome:{client.Name}," +
                    $" Agencia:{client.AgencyNumber}, Conta:{client.AccountNumber}, Limite:{client.MaximumLimit}," +
                    $" Limite Atual: {client.CurrentLimit}, $ Data:{client.DateTransaction}");
            }
        }

        private void ValidateClientSearch()
        {
            Console.WriteLine("\nService Test : ValidateClientSearch");
            int id = 5;
            Client client = _clientService.Search(id);

            Console.WriteLine($"Ïd:{client.ClientId}, Documento: {client.Document}, Nome:{client.Name}," +
                $" Agencia:{client.AgencyNumber}, Conta:{client.AccountNumber}, Limite:{client.MaximumLimit}," +
                $" Limite Atual: {client.CurrentLimit}, $ Data:{client.DateTransaction}");
        }

        private void ValidateClientRegister()
        {
            Console.WriteLine("\nService Test : ValidateClientRegister");
            int id = 100;

            Client client = new Client
            {
                ClientId = 100,
                Document = "111111111111",
                Name = "Naruto",
                AgencyNumber = 1,
                AccountNumber = 1,
                MaximumLimit = 1000,
                CurrentLimit = 1000,
                DateTransaction = DateTime.Now,
            };

            _clientService.Save(client);

            Client searchObj = _clientService.Search(id);
            Console.WriteLine($"Ïd:{searchObj.ClientId}, Documento: {searchObj.Document}, Nome:{searchObj.Name}," +
                $" Agencia:{searchObj.AgencyNumber}, Conta:{searchObj.AccountNumber}, Limite:{searchObj.MaximumLimit}," +
                $" Limite Atual: {searchObj.CurrentLimit}, $ Data:{searchObj.DateTransaction}");
        }

        private void ValidateClientUpdate()
        {
            Console.WriteLine("\nService Test : ValidateClientUpdate");
            int id = 3;
            Client client = _clientService.Search(id);
            client.Name = "Josefa Up2";
            _clientService.Update(client);

            Client searchObj = _clientService.Search(id);
            Console.WriteLine($"Ïd:{searchObj.ClientId}, Documento: {searchObj.Document}, Nome:{searchObj.Name}," +
                $" Agencia:{searchObj.AgencyNumber}, Conta:{searchObj.AccountNumber}, Limite:{searchObj.MaximumLimit}," +
                $" Limite Atual: {searchObj.CurrentLimit}, $ Data:{searchObj.DateTransaction}");
        }

        private void ValidateClientExclusion()
        {
            Console.WriteLine("\nService Test : ValidateClientExclusion");
            int id = 1;
            _clientService.Delete(id);

            Client client = _clientService.Search(id);
        }
    }
}
