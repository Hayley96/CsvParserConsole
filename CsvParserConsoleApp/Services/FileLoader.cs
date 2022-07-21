namespace CsvParserConsoleApp.Services
{
    public static class FileLoader
    {
        public static List<string> RawFileData { get; private set; } = new();
        public static string FilePath { get; private set; } = string.Empty;

        public static string Path()
        {
            var currentDir = Directory.GetCurrentDirectory();

            if (currentDir.ToLower().Contains(@"\bin\debug") || currentDir.ToLower().Contains(@"\bin\release"))
                FilePath = Directory.GetParent(currentDir)!.Parent!.Parent!.FullName + "\\Data\\input.csv".ToString();
            else
                FilePath = $"{currentDir}\\Data\\input.csv".ToString();
            return FilePath;
        }

        public static List<string> Load(string file)
        {
            return RawFileData = File.ReadLines(file).ToList();
        }
    }
}