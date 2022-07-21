namespace CsvParserConsoleApp.UI
{
    public static class PersonQueryOptions
    {
        public static readonly List<string> QueryOptions = new()
        {
            { "Return All People" },
            { "Return People With String 'Esq' In CompanyName" },
            { "Return People Who Live In County Derbyshire" },
            { "Return People Whose House Number Is Exactly Three Digits" },
            { "Return People Whose URL Is Longer Than 35 Chars" },
            { "Return People Who Live In A PostCode With A Single Digit Following The City Code" }
        };
    }
}