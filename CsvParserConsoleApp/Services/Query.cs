using CsvParserApp.Models;
using CsvParserConsoleApp.View;

namespace CsvParserConsoleApp.Services
{
    public class Query
    {
        private const int StartIndex = 0;

        public List<Person> ReturnAllPeople(List<Person> people) =>
            people;

        public List<Person> ReturnPeopleWithEsqInCompanyName(List<Person> people) =>
            people.Where(p => p.Companyname!.Contains("Esq")).ToList();

        public List<Person> ReturnPeopleWhoLiveInDerbyshire(List<Person> people) =>
            people.Where(p => p.County!.Equals("Derbyshire")).ToList();

        public List<Person> ReturnPeopleWhoseHouseNumberIsThreeDigits(List<Person> people) =>
            people.Where(p => p.Address!.Substring(StartIndex, p.Address.IndexOf(" ")).Length == 3).ToList();

        public List<Person> ReturnPeopleWhoseURLIsLongerThan35Chars(List<Person> people) =>
            people.Where(p => p.Web!.Length > 35).ToList();

        public List<Person> ReturnPeopleWhoLiveInPostCodeSingleDigit(List<Person> people) =>
            people.Where(p => p.Postal!.Substring(StartIndex, p.Postal.IndexOf(" ")).Count(i => Char.IsDigit(i)) == 1).ToList();

        public void Run(string selectedOption, List<Person> people)
        {
            switch (selectedOption)
            {
                case "Return All People":
                    PersonView.DisplayResults(ReturnAllPeople(people!));
                    break;
                case "Return People With String 'Esq' In CompanyName":
                    PersonView.DisplayResults(ReturnPeopleWithEsqInCompanyName(people!));
                    break;
                case "Return People Who Live In County Derbyshire":
                    PersonView.DisplayResults(ReturnPeopleWhoLiveInDerbyshire(people!));
                    break;
                case "Return People Whose House Number Is Exactly Three Digits":
                    PersonView.DisplayResults(ReturnPeopleWhoseHouseNumberIsThreeDigits(people!));
                    break;
                case "Return People Whose URL Is Longer Than 35 Chars":
                    PersonView.DisplayResults(ReturnPeopleWhoseURLIsLongerThan35Chars(people!));
                    break;
                case "Return People Who Live In A PostCode With A Single Digit Following The City Code":
                    PersonView.DisplayResults(ReturnPeopleWhoLiveInPostCodeSingleDigit(people!));
                    break;
            }
        }
    }
}