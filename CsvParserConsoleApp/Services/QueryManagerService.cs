using CsvParserApp.Models;

namespace CsvParserConsoleApp.Services
{
    public class QueryManagerService : IQueryManagerService
    {
        public List<string>? resultList { get; private set; } = new();

        public List<Person> ReturnAllPeople(List<Person> people) =>
            people;

        public List<Person> ReturnPeopleWithEsqInCompanyName(List<Person> people) =>
            people.Where(p => p.Companyname!.Contains("Esq")).ToList();

        public List<Person> ReturnPeopleWhoLiveInDerbyshire(List<Person> people) =>
            people.Where(p => p.County!.Equals("Derbyshire")).ToList();

        public List<Person> ReturnPeopleWhoseHouseNumberIsThreeDigits(List<Person> people) =>
            people.Where(p => p.Address!.Substring(0, p.Address.IndexOf(" ")).Length == 3).ToList();

        public List<Person> ReturnPeopleWhoseURLIsLongerThan35Chars(List<Person> people) =>
            people.Where(p => p.Web!.Length > 35).ToList();
    }
}