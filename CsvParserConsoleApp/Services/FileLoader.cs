namespace CsvParserConsoleApp.Services
{
    public static class FileLoader
    {
        public static List<string> RawFileData { get; private set; } = new();

        public static List<string> Load(string file)
        {
            return RawFileData = File.ReadLines(file).ToList();
        }
    }
}