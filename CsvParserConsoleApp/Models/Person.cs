using System.ComponentModel.DataAnnotations.Schema;

namespace CsvParserApp.Models
{
    public class Person
    {
        public int ListPosition { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Companyname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string Postal { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string Phone2 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Web { get; set; } = string.Empty;
    }
}