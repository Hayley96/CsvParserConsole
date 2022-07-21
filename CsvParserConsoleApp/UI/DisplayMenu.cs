namespace CsvParserConsoleApp.UI
{
    public static class DisplayMenu
    {
        public static string PrintToScreen<T>(T DisplayText, Func<List<string>, string> queryOptionMethodToRun, List<string> listOptions)
        {
            Console.Write($"\r{DisplayText}");
            return queryOptionMethodToRun(listOptions);
        }

        public static string DisplayQueryOptions(List<string> options)
        {
            List<string> queryOptions = new();
            foreach (var item in options)
            {
                AddToList(queryOptions, item);
            }
            return Menu.MultipleChoice(true, queryOptions);
        }

        public static List<T> AddToList<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }
    }
}
