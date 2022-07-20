using CsvParserApp.Models;
using CsvParserConsoleApp.Services;

namespace CsvParserConsoleAppTests.ServicesTests
{
    public class QueryServiceTests
    {
        private QueryManagerService queryManagerService;

        [SetUp]
        public void Setup()
        {
            queryManagerService = new();
        }

        [Test]
        public void GetAllPeople_Returns_All_People()
        {
            var data = GetTestModelPersonData();

            var people = queryManagerService.ReturnAllPeople(data);

            Assert.That(people.Count, Is.EqualTo(5));
            Assert.That(people[0].Firstname, Is.EqualTo("Aleshia"));
            Assert.That(people[1].Firstname, Is.EqualTo("Evan"));
            Assert.That(people[2].Firstname, Is.EqualTo("France"));
        }

        [Test]
        public void GetPeopleWithEsqInCompanyName_Returns_People_With_Esq_In_CompanyName()
        {
            var data = GetTestModelPersonData();

            var people = queryManagerService.ReturnPeopleWithEsqInCompanyName(data);

            Assert.That(people.Count, Is.EqualTo(1));
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