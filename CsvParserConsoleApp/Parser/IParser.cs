using System.Reflection;

namespace CsvParserConsoleApp.Parser
{
    public interface IParser
    {
        List<T> Parse<T>(List<string> fileData, string delimeter) where T : new();
        List<string> GetHeaders(List<string> lines, string delimeter);
        List<PropertyInfo> GetSystemPropertiesOfT<T>();
    }
}