using CsvParserApp.Models;
using CsvParserConsoleApp.Services;
using CsvParserConsoleAppTests.Data;
using FluentAssertions;

namespace CsvParserConsoleAppTests.ServicesTests
{
    public class QueryServiceTests
    {
        private QueryManagerService queryManagerService;
        private List<Person> _ObjPeopleTestData;

        [SetUp]
        public void Setup()
        {
            queryManagerService = new();
            _ObjPeopleTestData = ListTestData.GetTestModelPersonData();
        }

        [Test]
        public void ReturnAllPeople_Returns_All_People()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnAllPeople(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(5);
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Firstname, Is.EqualTo("Aleshia"));
                Assert.That(result[1].Firstname, Is.EqualTo("Evan"));
                Assert.That(result[2].Firstname, Is.EqualTo("France"));
            });
        }

        [Test]
        public void ReturnPeopleWithEsqInCompanyName_Returns_People_With_Esq_In_CompanyName()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnPeopleWithEsqInCompanyName(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(1);
        }

        [Test]
        public void ReturnPeopleWhoLiveInDerbyshire_Returns_People_With_County_Derbyshire()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnPeopleWhoLiveInDerbyshire(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(2);
        }

        [Test]
        public void ReturnPeopleWhoseHouseNumberIsThreeDigits_Returns_People_With_House_Number_Consisting_of_3_Digits_Only()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnPeopleWhoseHouseNumberIsThreeDigits(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(4);
        }

        [Test]
        public void ReturnPeopleWhoseURLIsLongerThan35Chars_Returns_People_With_URL_Length_Greater_Than_35()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnPeopleWhoseURLIsLongerThan35Chars(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(1);
        }

        [Test]
        public void GetPeopleWhoLiveInPostCodeSingleDigit_Returns_People_With_PostCode_With_Single_Digit()
        {
            var data = _ObjPeopleTestData;

            var result = queryManagerService.ReturnPeopleWhoLiveInPostCodeSingleDigit(data);

            result.Should().BeOfType(typeof(List<Person>));
            result.Count.Should().Be(2);
        }
    }
}