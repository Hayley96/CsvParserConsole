using CsvParserConsoleApp.Controllers;
using FluentAssertions;

namespace CsvParserConsoleAppTests.ControllerTests
{
    public class ParserControllerTests
    {
        private ParserManagementController? _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ParserManagementController();
        }

        [Test]
        public void CreateData_Parses_Data_Correctly_And_Returns_Row_Count()
        {

            var result = _controller!.GetRawDataFromFile();

            result.Should().BeOfType(typeof(List<string>));
            result.Count.Should().Be(501);
        }
    }
}