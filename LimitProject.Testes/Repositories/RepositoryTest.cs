using LimitProject.Domain.Entities;
using LimitProject.Infrastructure.Repositories;
using LimitProject.Testes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitProject.Testes.Repositories
{
    public class RepositoryTest
    {
        private readonly IClientRepository _clientRepository;
        public RepositoryTest(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
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
            List<Client> clients = _clientRepository.List();
            foreach (Client client in clients)
            {
                Console.WriteLine($"Ïd:{client.ClientId}, Documento: {client.Document}, Nome:{client.Name}," +
                    $" Agencia:{client.AgencyNumber}, Conta:{client.AccountNumber}, Limite:{client.MaximumLimit}," +
                    $" Limite Atual: {client.CurrentLimit}, $ Data:{client.DateTransaction}");
            }
        }

        private void ValidateClientSearch()
        {
            int id = 1;
            Client client = _clientRepository.Search(id);

            Console.WriteLine($"Ïd:{client.ClientId}, Documento: {client.Document}, Nome:{client.Name}," +
                $" Agencia:{client.AgencyNumber}, Conta:{client.AccountNumber}, Limite:{client.MaximumLimit}," +
                $" Limite Atual: {client.CurrentLimit}, $ Data:{client.DateTransaction}");
        }

        private void ValidateClientRegister()
        {
            Client client = ClientFactory.GetNewClient();
            int id = client.ClientId;

            _clientRepository.Save(client);

            Client searchObj = _clientRepository.Search(id);
            if (searchObj != null)
            {
                
                Console.WriteLine($"Ïd:{searchObj.ClientId}, Documento: {searchObj.Document}, Nome:{searchObj.Name}," +
                    $" Agencia:{searchObj.AgencyNumber}, Conta:{searchObj.AccountNumber}, Limite:{searchObj.MaximumLimit}," +
                    $" Limite Atual: {searchObj.CurrentLimit}, $ Data:{searchObj.DateTransaction}");
            }
        }

        private void ValidateClientUpdate()
        {
            int id = 1;
            Client client = _clientRepository.Search(id);
            client.Name = "Josefa Update";
            _clientRepository.Update(client);

            Client searchObj = _clientRepository.Search(id);
            Console.WriteLine($"Ïd:{searchObj.ClientId}, Documento: {searchObj.Document}, Nome:{searchObj.Name}," +
                $" Agencia:{searchObj.AgencyNumber}, Conta:{searchObj.AccountNumber}, Limite:{searchObj.MaximumLimit}," +
                $" Limite Atual: {searchObj.CurrentLimit}, $ Data:{searchObj.DateTransaction}");
        }

        private void ValidateClientExclusion()
        {
            int id = 15;
            _clientRepository.Delete(id);

            Client client = _clientRepository.Search(id);
        }
    }
}
