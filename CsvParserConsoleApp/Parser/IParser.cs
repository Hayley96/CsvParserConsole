using System.Reflection;

namespace CsvParserConsoleApp.Parser
{
    public interface IParser
    {
        List<T> Parse<T>(List<string> fileData, string delimeter) where T : new();
        List<string> GetHeaders(List<string> lines, string delimeter);
        List<PropertyInfo> GetSystemPropertiesOfT<T>();
        T Create<T>() where T : new();
        T MapValuesToTypeTProperties<T>(string line, string delimeter, List<string> columnNames, List<PropertyInfo> properties) where T : new();
    }
}