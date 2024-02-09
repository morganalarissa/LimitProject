
using LimitProject.Testes;

public class Program
{
    static void Main(string[] args)
    {
        ValidateDomain();
    }

    private static void ValidateDomain()
    {
        DomainTest test = new DomainTest();
        test.TestEntity();
        test.TestDto();
        test.ConvertTestEntityToDto();
        test.ConvertTestDtoToEntity();
    }
}