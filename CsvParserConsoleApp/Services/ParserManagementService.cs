using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;
using Newtonsoft.Json;

namespace CsvParserConsoleApp.Services
{
    public class ParserManagementService : IParserManagementService
    {
        public List<Person>? _people { get; private set; }

        public List<Person> RunParser(IParser parser, List<string> strPeople, string delimeter)
        {
            var recs = parser.Parse<Person>(strPeople, delimeter);
            var result = JsonConvert.SerializeObject(recs);
            //return _people = JsonConvert.DeserializeObject<List<Person>>(result)!;
            return recs!;
        }
    }
}