using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;

ParserManagementController controller = new();
var PersonRawData = controller.GetRawDataFromFile();

PersonRawData.ForEach(x => Console.WriteLine(x));
Console.WriteLine(PersonRawData.Count);