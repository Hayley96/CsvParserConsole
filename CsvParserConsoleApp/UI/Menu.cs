namespace CsvParserConsoleApp.UI
{
    public  class Menu
    {
        private static string? selectType;
        public static string MultipleChoice(bool canCancel, List<string> options)
        {
            const int startX = 0;
            int startY = Console.CursorTop + 1;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;
            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"{i + 1}: {options[i]}");
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Count)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return "-1";
                            break;
                        }
                }

            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            selectType = options[currentSelection];
            return selectType!;
        }
    }
}