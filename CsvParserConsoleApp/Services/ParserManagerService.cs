using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;
using Newtonsoft.Json;

namespace CsvParserConsoleApp.Services
{
    public class ParserManagerService : IParserManagerService
    {
        public List<Person> RunParser(IParser parser, List<string> strPeople, string delimeter)
        {
            var result = parser.Parse<Person>(strPeople, delimeter);
            return result!;
        }
    }
}