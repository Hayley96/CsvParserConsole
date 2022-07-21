using System.Reflection;
using System.Text.RegularExpressions;

namespace CsvParserConsoleApp.Parser
{
    public class CsvParser : IParser
    {
        private int _index = 1;
        public List<T> Parse<T>(List<string> fileData, string delimeter) where T : new()
        {
            List<T> list = new();
            var headers = GetHeaders(fileData, delimeter);
            var properties = GetSystemPropertiesOfT<T>();
            fileData.Skip(1).ToList().ForEach(line => list.Add(MapValuesToTypeTProperties<T>(line, delimeter, headers, properties)));
            return list;
        }

        public List<string> GetHeaders(List<string> lines, string delimeter) =>
            lines.First().Replace("_", "").Split(delimeter).Select(h => h.Substring(0, 1).ToUpper() + h.Substring(1)).ToList();

        public List<PropertyInfo> GetSystemPropertiesOfT<T>()
        {
            return typeof(T).GetProperties().ToList();
        }

        public T Create<T>() where T : new() =>
            new T();

        public T MapValuesToTypeTProperties<T>(string line, string delimeter, List<string> columnNames, List<PropertyInfo> properties) where T : new()
        {
            T obj = Create<T>();
            List<string> cells = new();
            var fieldValues = Regex.Split(line, $"{delimeter}(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").ToList();
            fieldValues.ForEach(field => cells.Add(field.Replace("\"", "")));
            int index = 0;

            columnNames.ForEach(column =>
            {
                var prop = properties.SingleOrDefault(p => p.Name == column);
                Type propertyType = prop!.PropertyType;
                var value = cells[index++];
                prop.SetValue(obj, Convert.ChangeType(value, propertyType));
            });

            if (obj!.GetType().GetProperty("ListPosition") != null)
                obj!.GetType().GetProperty("ListPosition")!.SetValue(obj, _index++);
            return obj;
        }
    }
}