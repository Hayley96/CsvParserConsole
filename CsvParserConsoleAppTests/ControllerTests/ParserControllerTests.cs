using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
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
            _strPeopleTestData = GetStringTestData();
            _ObjPeopleTestData = GetTestModelPersonData();
            _delimeter = ",";
            _mockParserManagementService = new Mock<IParserManagementService>();
            _mockQueryManagerService = new Mock<IQueryManagerService>();
            _mockParser = new Mock<IParser>();
            _controller = new ParserManagementController(_mockParserManagementService.Object, _mockQueryManagerService.Object, 
                _mockParser.Object, _delimeter);
        }

        [Test]
        public void GetRawDataFromFile_Returns_A_List_Of_Strings()
        {

            var result = _controller!.GetRawDataFromFile();

            result.Should().BeOfType(typeof(List<string>));
            result.Count.Should().Be(31);
        }

        [Test]
        public void Parse_Correctly_Parses_List_Of_Strings_And_Returns_List_Of_Person()
        {

            _mockParserManagementService!.Setup(b => b.RunParser(_mockParser!.Object, _strPeopleTestData, _delimeter))
                .Returns(GetTestModelPersonData());

            var result = _controller!.Parse(_strPeopleTestData);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }

        [Test]
        public void QueryGetPeople_Returns_List_Of_Person()
        {
            _mockQueryManagerService!.Setup(b => b.ReturnAllPeople(_ObjPeopleTestData)).Returns(GetTestModelPersonData());

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

        private List<string> GetTestHeaders()
        {
            return new List<string>
            {
                { @"Firstname,Lastname,Companyname,Address,City,County,Postal,Phone1,Phone2,Email,Web" },
            };
        }

        List<string> GetStringTestData()
        {
            return new List<string>
            {
                { @"Aleshia,Tomkiewicz,Alan D Rosenburg Cpa Pc,147 Taylor St, St. Stephens Ward, Derbyshire, C2 7PP,01835-703597,01944-369967,atomkiewicz@hotmail.com,http://www.alandrosenburgcpapc.co.uk" },
                { @"Evan,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward, Buckinghamshire, H91 2AX, 01937-864715, 01714-737668, evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" },
                { @"France,Andrade,Elliott, John W Esq,8 Moor Place,East Southbourne and Tuckton W,Derbyshire,B6 3BE,01347-368222,01935-821636,france.andrade@hotmail.com,http://www.elliottjohnwesq.co.uk" },
                { @"Zoe,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward,Buckinghamshire,H21 2AX,01937-864715,01714-737668,evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" },
                { @"Marvin,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward,Buckinghamshire,SE21 2AX,01937-864715,01714-737668,evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" }
            };
        }

        List<string> GetStringTestDataWithHeaders()
        {
            return new List<string>
            {
                { @"Firstname,Lastname,Companyname,Address,City,County,Postal,Phone1,Phone2,Email,Web" },
                { @"Aleshia,Tomkiewicz,Alan D Rosenburg Cpa Pc,147 Taylor St, St. Stephens Ward, Derbyshire, C2 7PP,01835-703597,01944-369967,atomkiewicz@hotmail.com,http://www.alandrosenburgcpapc.co.uk" },
                { @"Evan,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward, Buckinghamshire, H91 2AX, 01937-864715, 01714-737668, evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" },
                { @"France,Andrade,Elliott, John W Esq,8 Moor Place,East Southbourne and Tuckton W,Derbyshire,B6 3BE,01347-368222,01935-821636,france.andrade@hotmail.com,http://www.elliottjohnwesq.co.uk" },
                { @"Zoe,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward,Buckinghamshire,H21 2AX,01937-864715,01714-737668,evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" },
                { @"Marvin,Zigomalas,Cap Gemini America,555 Binney St,Abbey Ward,Buckinghamshire,SE21 2AX,01937-864715,01714-737668,evan.zigomalas@gmail.com,http://www.capgeminiamerica.co.uk" }
            };
        }

        private List<Person> GetTestModelPersonData()
        {
            return new List<Person>
            {
                new Person()
                    { Firstname = "Aleshia", Lastname = "Tomkiewicz", Companyname = "Alan D Rosenburg Cpa Pc", Address = "147 Taylor St", City = "St. Stephens Ward", County = "Derbyshire", Postal = "C2 7PP",Phone1 = "01835-703597",Phone2 = "01944-369967",Email = "atomkiewicz@hotmail.com",Web = "http://www.alandrosenburgcpapc.co.uk" },
                new Person()
                   {
                       Firstname = "Evan",
                       Lastname = "Zigomalas",
                       Companyname = "Cap Gemini America",
                       Address = "555 Binney St",
                       City = "Abbey Ward",
                       County = "Buckinghamshire",
                       Postal = "H91 2AX",
                       Phone1 = "01937-864715",
                       Phone2 = "01714-737668",
                       Email = "evan.zigomalas@gmail.com",
                       Web = "http://www.capgeminiamerica.co.uk"
                   },
                new Person()
                    {
                        Firstname = "France",
                        Lastname = "Andrade",
                        Companyname = "Elliott, John W Esq",
                        Address = "8 Moor Place",
                        City = "East Southbourne and Tuckton W",
                        County = "Derbyshire",
                        Postal = "B6 3BE",
                        Phone1 = "01347-368222",
                        Phone2 = "01935-821636",
                        Email = "france.andrade@hotmail.com",
                        Web = "http://www.elliottjohnwesq.co.uk"
                    },
                new Person()
                   {
                       Firstname = "Zoe",
                       Lastname = "Zigomalas",
                       Companyname = "Cap Gemini America",
                       Address = "555 Binney St",
                       City = "Abbey Ward",
                       County = "Buckinghamshire",
                       Postal = "H21 2AX",
                       Phone1 = "01937-864715",
                       Phone2 = "01714-737668",
                       Email = "evan.zigomalas@gmail.com",
                       Web = "http://www.capgeminiamerica.co.uk"
                   },
                new Person()
                   {
                       Firstname = "Marvin",
                       Lastname = "Zigomalas",
                       Companyname = "Cap Gemini America",
                       Address = "555 Binney St",
                       City = "Abbey Ward",
                       County = "Buckinghamshire",
                       Postal = "SE21 2AX",
                       Phone1 = "01937-864715",
                       Phone2 = "01714-737668",
                       Email = "evan.zigomalas@gmail.com",
                       Web = "http://www.capgeminiamerica.co.uk"
                   },
            }.ToList();
        }
    }
}