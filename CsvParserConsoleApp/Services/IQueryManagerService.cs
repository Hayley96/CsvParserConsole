using CsvParserApp.Models;

namespace CsvParserConsoleApp.Services
{
    public interface IQueryManagerService
    {
        List<Person> ReturnAllPeople(List<Person> people);
        List<Person> ReturnPeopleWithEsqInCompanyName(List<Person> people);
    }
}
