namespace CsvParserConsoleApp.Services
{
    public static class FileIOManagerService
    {
        public static List<string> RawFileData { get; private set; } = new();

        public static List<string> GetData(string fileDir)
        {
            return RawFileData = File.ReadLines(fileDir).ToList();
        }
    }
}