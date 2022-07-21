namespace CsvParserConsoleApp.Services
{
    public static class FilePath
    {
        public static string PathToFile { get; private set; } = string.Empty;

        public static string Path()
        {
            var currentDir = Directory.GetCurrentDirectory();

            if (currentDir.ToLower().Contains(@"\bin\debug") || currentDir.ToLower().Contains(@"\bin\release"))
                PathToFile = Directory.GetParent(currentDir)!.Parent!.Parent!.FullName + "\\Data\\input.csv".ToString();
            else
                PathToFile = $"{currentDir}\\Data\\input.csv".ToString();
            return PathToFile;
        }
    }
}