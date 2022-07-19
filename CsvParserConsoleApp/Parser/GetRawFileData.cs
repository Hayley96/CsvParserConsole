namespace CsvParserConsoleApp.Parser
{
    public static class GetRawFileData
    {
        public static List<string> RawFileData { get; private set; } = new();

        public static List<string> GetData(string fileDir)
        {
            return RawFileData = File.ReadLines(fileDir).ToList();
        }
    }
}