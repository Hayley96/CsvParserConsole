using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using CsvParserConsoleAppTests.Data;
using FluentAssertions;
using Moq;

namespace CsvParserConsoleAppTests.ServicesTests
{
    public class ParserServicesTests
    {
        private ParserManagementService _parserManagementService;
        private Mock<IParser>? _parser;
        private List<string> _strPeopleTestData;
        private List<Person> _ObjPeopleTestData;
        private string _delimeter;

        [SetUp]
        public void Setup()
        {
            _strPeopleTestData = ListTestData.GetStringTestData();
            _ObjPeopleTestData = ListTestData.GetTestModelPersonData();
            _delimeter = ",";
            _parser = new Mock<IParser>();
            _parserManagementService = new();
        }

        [Test]
        public void RunParser_Returns_A_List_Of_Type_T_Person()
        {

            _parser!.Setup(b => b.Parse<Person>(_strPeopleTestData, _delimeter)).Returns(_ObjPeopleTestData);

            var result = _parserManagementService!.RunParser(_parser!.Object, _strPeopleTestData, _delimeter);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }
    }
}
