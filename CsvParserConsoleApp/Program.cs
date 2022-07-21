using CsvParserApp.Models;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using CsvParserConsoleApp.UI;

const string DELIMITER = ",";
bool continueRunning = true;

IParser parser = new CsvParser();
Query query = new();

string file = FileLoader.Path();
var data = FileLoader.Load(file);
var people = parser.Parse<Person>(data, DELIMITER);

while (continueRunning)
{
    string selectedOption = DisplayMenu.PrintMainMenu();
    query.Run(selectedOption, people);
    continueRunning = DisplayMenu.ShowContinuePrompt();
}