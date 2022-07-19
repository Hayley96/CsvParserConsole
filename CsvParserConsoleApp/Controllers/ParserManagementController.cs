using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;

namespace CsvParserConsoleApp.Controllers
{
    public class ParserManagementController
    {
        public List<string> RawFileData { get; private set; } = new();
        public List<string> GetRawDataFromFile()
        {
            var GetAppDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())!.ToString())!.ToString());
            var fileDir = $"{GetAppDir}\\Data\\input.csv".ToString();
            return RawFileData = GetRawFileData.GetData(fileDir);
        }
    }
}