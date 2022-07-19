using CsvParserApp.Models;
using CsvParserConsoleApp.Controllers;
using CsvParserConsoleApp.Parser;
using CsvParserConsoleApp.Services;
using FluentAssertions;
using Moq;

namespace CsvParserConsoleAppTests.ServicesTests
{
    public class ParserServicesTests
    {
        private ParserManagementController? _controller;
        private ParserManagementService? _parserManagementService;
        private Mock<IParser>? _parser;
        private List<string> _strPeopleTestData;
        private string _delimeter;

        [SetUp]
        public void Setup()
        {
            _strPeopleTestData = GetStringTestData();
            _delimeter = ",";
            _parser = new Mock<IParser>();
            _parserManagementService = new();
        }

        [Test]
        public void RunParser_Returns_A_List_Of_Type_T_Person()
        {

            _parser!.Setup(b => b.Parse<Person>(_strPeopleTestData, _delimeter)).Returns(GetTestModelPersonData());

            var result = _parserManagementService!.RunParser(_parser!.Object, _strPeopleTestData, _delimeter);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
        }

        private List<string> GetStringTestData()
        {
            return new List<string>
            {
                    {
                        @"Aleshia,
                        Tomkiewicz,
                        Alan D Rosenburg Cpa Pc,
                        147 Taylor St,
                        St. Stephens Ward,
                        Derbyshire
                        C2 7PP,
                        01835-703597,
                        01944-369967,
                        atomkiewicz@hotmail.com,
                        http://www.alandrosenburgcpapc.co.uk"
                    },
                    {
                       @"Evan,
                       Zigomalas,
                       Cap Gemini America,
                       555 Binney St,
                       Abbey Ward,
                       Buckinghamshire,
                       H91 2AX,
                       01937-864715,
                       01714-737668,
                       evan.zigomalas@gmail.com,
                       http://www.capgeminiamerica.co.uk"
                    },
                    {
                        @"France,
                        Andrade,
                        Elliott, John W Esq,
                        8 Moor Place,
                        East Southbourne and Tuckton W,
                        Derbyshire,
                        B6 3BE,
                        01347-368222,
                        01935-821636,
                        france.andrade@hotmail.com,
                        http://www.elliottjohnwesq.co.uk"
                    },
                    {
                       @"Zoe,
                       Zigomalas,
                       Cap Gemini America,
                       555 Binney St,
                       Abbey Ward,
                       Buckinghamshire,
                       H21 2AX,
                       01937-864715,
                       01714-737668,
                       evan.zigomalas@gmail.com,
                       http://www.capgeminiamerica.co.uk"
                   },
                   {
                       @"Marvin,
                       Zigomalas,
                       Cap Gemini America,
                       555 Binney St,
                       Abbey Ward,
                       Buckinghamshire,
                       SE21 2AX,
                       01937-864715,
                       01714-737668,
                       evan.zigomalas@gmail.com,
                       http://www.capgeminiamerica.co.uk"
                   },
            }.ToList();
        }

        private List<Person> GetTestModelPersonData()
        {
            return new List<Person>
            {
                new Person()
                    {
                        Firstname = "Aleshia",
                        Lastname = "Tomkiewicz",
                        Companyname = "Alan D Rosenburg Cpa Pc",
                        Address = "147 Taylor St",
                        City = "St. Stephens Ward",
                        County = "Derbyshire",
                        Postal = "C2 7PP",
                        Phone1 = "01835-703597",
                        Phone2 = "01944-369967",
                        Email = "atomkiewicz@hotmail.com",
                        Web = "http://www.alandrosenburgcpapc.co.uk",
                    },
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
