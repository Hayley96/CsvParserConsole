namespace CsvParserConsoleApp.UI
{
    public static class DisplayMenu
    {
        public static string PrintMainMenu()
        {
            return PrintToScreen("\rSelect Query To Run:", DisplayQueryOptions, MenuOptions.QueryOptions);
        }
        public static string PrintToScreen<T>(T DisplayText, Func<List<string>, string> menuOptionMethodToRun, List<string> listOptions)
        {
            Console.Clear();
            Console.Write($"\r{DisplayText}");
            var result = menuOptionMethodToRun(listOptions);
            Console.Clear();
            return result;
        }

        public static string DisplayQueryOptions(List<string> options)
        {
            return Menu.MultipleChoice(true, options);
        }

        public static bool ShowContinuePrompt()
        {
            Console.WriteLine($"\nPress 'R' to run another query or any other key to exit......");
            var continueOption = Console.ReadLine();

            return continueOption!.Equals("R") ? true : false;
        }
    }
}