using System.ComponentModel.DataAnnotations.Schema;

namespace CsvParserApp.Models
{
    public class Person
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Companyname { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Postal { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        public string? Web { get; set; }
    }
}