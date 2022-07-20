using CsvParserApp.Models;

namespace CsvParserConsoleApp.Services
{
    public interface IQueryManagerService
    {
        List<Person> ReturnAllPeople(List<Person> people);
        List<Person> ReturnPeopleWithEsqInCompanyName(List<Person> people);
        List<Person> ReturnPeopleWhoLiveInDerbyshire(List<Person> people);
        List<Person> ReturnPeopleWhoseHouseNumberIsThreeDigits(List<Person> people);
    }
}
