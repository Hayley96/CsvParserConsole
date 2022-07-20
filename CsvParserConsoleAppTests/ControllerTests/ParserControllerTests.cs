using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using CsvParserConsoleAppTests.Data;
using FluentAssertions;
using Moq;

namespace CsvParserConsoleAppTests.ControllerTests
{
    public class ParserControllerTests
    {
        private ParserManagementController? _controller;
        private Mock<IParserManagementService>? _mockParserManagementService;
        private Mock<IQueryManagerService>? _mockQueryManagerService;
        private Mock<IParser>? _mockParser;
        private List<string> _strPeopleTestData;
        private List<Person> _ObjPeopleTestData;
        private string _delimeter;

        [SetUp] 
        public void Setup()
        {
            _strPeopleTestData = ListTestData.GetStringTestData();
            _ObjPeopleTestData = ListTestData.GetTestModelPersonData();
            _delimeter = ",";
            _mockParserManagementService = new Mock<IParserManagementService>();
            _mockQueryManagerService = new Mock<IQueryManagerService>();
            _mockParser = new Mock<IParser>();
            _controller = new ParserManagementController(_mockParserManagementService.Object, _mockQueryManagerService.Object, 
                _mockParser.Object, _delimeter);
        }

        [Test]
        public void Parse_Correctly_Parses_List_Of_Strings_And_Returns_List_Of_Person()
        {

            _mockParserManagementService!.Setup(b => b.RunParser(_mockParser!.Object, _strPeopleTestData, _delimeter))
                .Returns(_ObjPeopleTestData);

            var result = _controller!.Parse(_strPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }

        [Test]
        public void QueryGetPeople_Returns_List_Of_Person()
        {
            _mockQueryManagerService!.Setup(b => b.ReturnAllPeople(_ObjPeopleTestData)).Returns(_ObjPeopleTestData);

            var result = _controller!.QueryGetPeople(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }

        [Test]
        public void QueryGetPeopleWithCompanyNameContainingEsq_Returns_List_of_Objects()
        {
            List<Person> expectedResult = _ObjPeopleTestData.Where(p => p.Firstname == "France").ToList();
            _mockQueryManagerService!.Setup(b => b.ReturnPeopleWithEsqInCompanyName(_ObjPeopleTestData)).Returns(expectedResult);

            var result = _controller!.QueryGetPeopleWithCompanyNameContainingEsq(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count().Should().Be(expectedResult.Count);
        }

        [Test]
        public void QueryGetPeopleFromDerbyshire_Returns_List_of_Objects()
        {
            List<Person> expectedResult = _ObjPeopleTestData.Where(p => p.County == "Derbyshire").ToList();
            _mockQueryManagerService!.Setup(b => b.ReturnPeopleWhoLiveInDerbyshire(_ObjPeopleTestData)).Returns(expectedResult);

            var result = _controller!.QueryGetPeopleFromDerbyshire(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count().Should().Be(expectedResult.Count);
        }

        [Test]
        public void QueryGetPeopleWhoseHouseNumberIsExactlyThreeDigits_Returns_List_of_Objects()
        {
            List<Person> expectedResult = _ObjPeopleTestData.Where(p => p.Address!.Substring(0, p.Address.IndexOf(" ")).Length == 3).ToList();
            _mockQueryManagerService!.Setup(b => b.ReturnPeopleWhoseHouseNumberIsThreeDigits(_ObjPeopleTestData)).Returns(expectedResult);

            var result = _controller!.QueryGetPeopleWhoseHouseNumberIsExactlyThreeDigits(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count().Should().Be(expectedResult.Count);
        }

        [Test]
        public void QueryGetPeopleWhoseURLLengthGreaterThan35_Returns_List_of_Objects()
        {
            List<Person> expectedResult = _ObjPeopleTestData.Where(p => p.Web!.Length>35).ToList();
            _mockQueryManagerService!.Setup(b => b.ReturnPeopleWhoseURLIsLongerThan35Chars(_ObjPeopleTestData)).Returns(expectedResult);

            var result = _controller!.QueryGetPeopleWhoseURLLengthGreaterThan35(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count().Should().Be(expectedResult.Count);
        }

        [Test]
        public void QueryGetPeopleWhoLiveInPostcodeWithSingleDigitValue_Returns_List_of_Objects()
        {
            List<Person> expectedResult = _ObjPeopleTestData.Where(p => p.Postal!.Substring(0, p.Postal.IndexOf(" ")).Count(i => Char.IsDigit(i)) == 1).ToList();
            _mockQueryManagerService!.Setup(b => b.ReturnPeopleWhoLiveInPostCodeSingleDigit(_ObjPeopleTestData)).Returns(expectedResult);

            var result = _controller!.QueryGetPeopleWhoLiveInPostcodeWithSingleDigitValue(_ObjPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count().Should().Be(expectedResult.Count);
        }

    }
}