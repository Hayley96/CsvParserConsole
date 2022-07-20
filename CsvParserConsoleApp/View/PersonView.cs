using CsvParserApp.Models;

namespace CsvParserConsoleApp.View
{
    public static class PersonView
    {
        public static List<Person> DisplayResults(List<Person> people)
        {
            Console.WriteLine($"Count: {people.Count()}");
            people.ForEach(p => Console.WriteLine($"{p.ListPosition.ToString()} - {p.Firstname} {p.Lastname} - {p.Companyname}"));
            return people;
        }
    }
}