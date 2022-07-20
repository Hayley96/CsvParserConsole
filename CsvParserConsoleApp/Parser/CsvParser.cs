﻿using System.Reflection;


namespace CsvParserConsoleApp.Parser
{
    public class CsvParser : IParser
    {
        public List<T> Parse<T>(List<string> fileData, string delimeter) where T : new()
        {
            List<T> list = new();
            var headers = GetHeaders(fileData, delimeter);
            var properties = GetSystemPropertiesOfT<T>();
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
    }
}