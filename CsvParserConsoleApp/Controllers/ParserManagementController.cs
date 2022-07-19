using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;

namespace CsvParserConsoleApp.Controllers
{
    public class ParserManagementController
    {
        private readonly IParserManagementService? _parserManagementService;
        private readonly IParser? _parser;
        private string _delimeter;
        public List<string> RawFileData { get; private set; } = new();
        public List<Person> People { get; private set; } = new();

        public ParserManagementController(IParserManagementService? parserManagementService, IParser parser, string delimeter)
        {
            _parserManagementService = parserManagementService;
            _parser = parser;
            _delimeter = delimeter;
        }

        public List<string> GetRawDataFromFile()
        {
            var GetAppDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
            var fileDir = $"{GetAppDir}\\Data\\input.csv".ToString();
            return RawFileData = GetRawFileData.GetData(fileDir);
        }

        public List<Person> Parse(List<string> RawFileData)
        {
            return People = _parserManagementService!.RunParser(_parser!, RawFileData, _delimeter);
        }
    }
}