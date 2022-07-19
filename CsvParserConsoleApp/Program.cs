using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;

IParser parser;
parser = new CsvParser();

string delimeter = ",";

ParserManagementController controller = new(new ParserManagementService(), new CsvParser(), delimeter);
var PersonRawData = controller.GetRawDataFromFile();
var peopleresult = controller.Parse(PersonRawData);

//PersonRawData.ForEach(x => Console.WriteLine(x));
//peopleresult.ForEach(x => Console.WriteLine(x));
//Console.WriteLine(peopleresult.Count);

var headers = parser.GetHeaders(PersonRawData, delimeter);
headers.ForEach(x => Console.WriteLine(x));

var props = parser.GetSystemPropertiesOfT<Person>();
props.ForEach(x => Console.WriteLine(x));