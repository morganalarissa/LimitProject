using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LimitProject.Testes.Contexts;
using LimitProject.Testes.Domain;
using LimitProject.Testes.Repositories;
using LimitProject.Testes.Services;

namespace LimitProject.Testes.Main
{
    public class AppMainTest
    {
        private readonly RepositoryTest _repositoryTest;
        private readonly ServiceTest _serviceTest;
        public AppMainTest(RepositoryTest repositoryTest, ServiceTest serviceTest)
        {
            _repositoryTest = repositoryTest;
            _serviceTest = serviceTest;
        }

        public void Execute()
        {
            ValidateDomain();
            ValidateInfrastructure_Context();
            ValidateRepository();
            ValidateService();
        }

        private void ValidateInfrastructure_Context()
        {
            FakeContextTest test = new FakeContextTest();
            test.Execute();
        }

        private void ValidateDomain()
        {
            DomainTest test = new DomainTest();
            test.Execute();
        }

        private void ValidateRepository()
        {
            _repositoryTest.Execute();
        }

        private void ValidateService()
        {
            _serviceTest.Execute();
        }
    }


}
