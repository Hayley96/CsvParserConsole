using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;

namespace CsvParserConsoleApp.Services
{
    public interface IParserManagementService
    {
        List<Person> RunParser(IParser parser, List<string> strPeople, string delimeter);
    }
}