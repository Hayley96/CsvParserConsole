using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;

string delimeter = ",";

ParserManagementController controller = new(new ParserManagementService(), new CsvParser(), delimeter);
var PersonRawData = controller.GetRawDataFromFile();
var peopleresult = controller.Parse(PersonRawData);

PersonRawData.ForEach(x => Console.WriteLine(x));
peopleresult.ForEach(x => Console.WriteLine(x));
Console.WriteLine(peopleresult.Count);