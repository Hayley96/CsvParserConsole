using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using System.Reflection;

IParser parser;
parser = new CsvParser();

string delimeter = ",";

ParserManagementController controller = new(new ParserManagementService(), new CsvParser(), delimeter);
var PersonRawData = controller.GetRawDataFromFile();
var peopleresult = controller.Parse(PersonRawData);

peopleresult.ForEach(person => Console.WriteLine(person.Firstname));