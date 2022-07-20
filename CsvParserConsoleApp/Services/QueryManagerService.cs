using CsvParserApp.Models;

namespace CsvParserConsoleApp.Services
{
    public class QueryManagerService : IQueryManagerService
    {
        public List<string>? resultList { get; private set; } = new();

        public List<Person> ReturnAllPeople(List<Person> people) =>
            people;
    }
}
