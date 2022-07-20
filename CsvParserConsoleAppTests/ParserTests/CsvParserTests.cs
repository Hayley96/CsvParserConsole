using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using CsvParserConsoleAppTests.Data;
using FluentAssertions;
using Moq;
using System.Reflection;

namespace CsvParserConsoleAppTests.ParserTests
{
    public class CsvParserTests
    {
        private IParser? _parser;
        private List<string> _strPeopleTestData;
        private List<Person> _ObjPeopleTestData;
        private string _delimeter;

        [SetUp]
        public void Setup()
        {
            _parser = new CsvParser();
            _strPeopleTestData = ListTestData.GetStringTestData();
            _ObjPeopleTestData = ListTestData.GetTestModelPersonData();
            _delimeter = ",";
        }

        [Test]
        public void RunParser_Returns_A_List_Of_Type_T_Person()
        {
            var testdata = ListTestData.GetStringTestDataWithHeaders();

            var result = _parser!.Parse<Person>(testdata, _delimeter);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }

        [Test]
        public void GetHeaders_Returns_A_List_Of_Headers()
        {

            var result = _parser!.GetHeaders(ListTestData.GetTestHeaders(), _delimeter);

            result.Should().BeOfType(typeof(List<string>));
            result.Count.Should().Be(11);
        }

        [Test]
        public void GetSystemPropertiesOfT_returns_All_Properties_Of_T()
        {
            List<PropertyInfo> result = _parser!.GetSystemPropertiesOfT<Person>();

            result.Count.Should().Be(11);
        }

        [Test]
        public void Create_returns_An_Instance_Of_T()
        {
            var result = _parser!.Create<Person>();

            Assert.That(result, Is.InstanceOf<Person>());
        }

        [Test]
        public void MapValuesToTypeTProperties_returns_An_Instance_Of_T_With_Correct_Property_Values()
        {
            var lines = _strPeopleTestData;
            var headers = _parser!.GetHeaders(ListTestData.GetTestHeaders(), _delimeter);
            List<PropertyInfo> props = _parser!.GetSystemPropertiesOfT<Person>();

            var result = _parser.MapValuesToTypeTProperties<Person>(lines[0], _delimeter, headers, props);

            Assert.That(result, Is.InstanceOf<Person>());
            Assert.That(result.Firstname == "Aleshia");
        }
    }
}