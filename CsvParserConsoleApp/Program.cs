using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using CsvParserConsoleApp.UI;

string delimeter = ",";
bool continueRunning = true;

ParserManagementController controller = new(new ParserManagerService(), new QueryManagerService(), new CsvParser(), delimeter);
var dataFromFile = controller.GetRawDataFromFile();
var dataFromParser = controller.Parse(dataFromFile);

while (continueRunning)
{
    Console.Clear();
    string QueryOptions = DisplayMenu.PrintToScreen("\rSelect Query To Run:", DisplayMenu.DisplayQueryOptions, PersonQueryOptions.QueryOptions);
    Console.Clear();
    QueryOptionSwitchCase(QueryOptions);
    Console.WriteLine($"\nPress 'R' to run another query or any other key to exit......");
    var continueOption = Console.ReadLine();

    if (continueOption != "R")
        continueRunning = false;
}

void QueryOptionSwitchCase(string QueryOptions)
{
    switch (QueryOptions)
    {
        case "Return All People":
            controller.QueryGetPeople(dataFromParser!);
            break;
        case "Return People With String 'Esq' In CompanyName":
            controller.QueryGetPeopleWithCompanyNameContainingEsq(dataFromParser!);
            break;
        case "Return People Who Live In County Derbyshire":
            controller.QueryGetPeopleFromDerbyshire(dataFromParser!);
            break;
        case "Return People Whose House Number Is Exactly Three Digits":
            controller.QueryGetPeopleWhoseHouseNumberIsExactlyThreeDigits(dataFromParser!);
            break;
        case "Return People Whose URL Is Longer Than 35 Chars":
            controller.QueryGetPeopleWhoseURLLengthGreaterThan35(dataFromParser!);
            break;
        case "Return People Who Live In A PostCode With A Single Digit Following The City Code":
            controller.QueryGetPeopleWhoLiveInPostcodeWithSingleDigitValue(dataFromParser!);
            break;
    }
}