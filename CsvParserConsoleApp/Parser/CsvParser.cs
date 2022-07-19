using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsvParserConsoleApp.Parser
{
    public class CsvParser : IParser
    {
        public List<T> Parse<T>(List<string> fileData, string delimeter) where T : new()
        {
            List<T> list = new();
            var headers = GetHeaders(fileData, delimeter);
            return list;
        }

        public List<string> GetHeaders(List<string> lines, string delimeter) =>
            lines.First().Replace("_", "").Split(delimeter).ToList();
    }
}