using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;

namespace CsvParserConsoleApp.Controllers
{
    public class ParserManagementController
    {
        private readonly IParserManagementService? _parserManagementService;
        private readonly IQueryManagerService? _queryManagerService;
        private readonly IParser? _parser;
        private string _delimeter;
        public List<string> RawFileData { get; private set; } = new();
        public List<Person> People { get; private set; } = new();

        public ParserManagementController(IParserManagementService? parserManagementService, IQueryManagerService? queryManagerService, IParser parser, string delimeter)
        {
            _parserManagementService = parserManagementService;
            _queryManagerService = queryManagerService;
            _parser = parser;
            _delimeter = delimeter;
        }

        public List<string> GetRawDataFromFile()
        {
            var GetAppDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
            var fileDir = $"{GetAppDir}\\Data\\input.csv".ToString();
            return RawFileData = FileIOManagerService.GetData(fileDir);
        }

        public List<Person> Parse(List<string> RawFileData)
        {
            return People = _parserManagementService!.RunParser(_parser!, RawFileData, _delimeter);
        }

        public List<Person> QueryGetPeople(List<Person> people)
        {
            return _queryManagerService!.ReturnAllPeople(people);
        }

        public List<Person> QueryGetPeopleWithCompanyNameContainingEsq(List<Person> people)
        {
            return _queryManagerService!.ReturnPeopleWithEsqInCompanyName(people);
        }

        public List<Person> QueryGetPeopleFromDerbyshire(List<Person> people)
        {
            return _queryManagerService!.ReturnPeopleWhoLiveInDerbyshire(people);
        }

        public List<Person> QueryGetPeopleWhoseHouseNumberIsExactlyThreeDigits(List<Person> people)
        {
            return _queryManagerService!.ReturnPeopleWhoseHouseNumberIsThreeDigits(people);
        }

        public List<Person> QueryGetPeopleWhoseURLLengthGreaterThan35(List<Person> people)
        {
            return _queryManagerService!.ReturnPeopleWhoseURLIsLongerThan35Chars(people);
        }

        public List<Person> QueryGetPeopleWhoLiveInPostcodeWithSingleDigitValue(List<Person> people)
        {
            return _queryManagerService!.ReturnPeopleWhoLiveInPostCodeSingleDigit(people);
        }
    }
}