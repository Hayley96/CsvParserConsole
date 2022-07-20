using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;

string delimeter = ",";

ParserManagementController controller = new(new ParserManagerService(), new QueryManagerService(), new CsvParser(), delimeter);
var PersonRawData = controller.GetRawDataFromFile(); //list of raw data from file - FileIO
var peopleresult = controller.Parse(PersonRawData);  //list of people parsed - Parser

var derbyshirepeople = controller.QueryGetPeopleFromDerbyshire(peopleresult); //sample query call - Query