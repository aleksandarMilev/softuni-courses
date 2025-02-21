namespace Cadastre.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    [XmlType("District")]
    public class ImportDistrictsDto
    {
        private const int PostalCodeLength = 8;
        private const int NameMinLength = 2;
        private const int NameMaxLength = 80;

        private string postalCode;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string PostalCode
        {
            get => postalCode;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    value.Length == PostalCodeLength &&
                    IsMatchPattern(value))
                {
                    postalCode = value;
                }
            }
        }

        [Required]
        [XmlAttribute("Region")]
        public string Region { get; set; }

        [XmlArray("Properties")]
        public ImportPropertyDto[] Properties { get; set; }

        private static bool IsMatchPattern(string str)
            => Regex.IsMatch(str, "\\b[A-Z]{2}-[\\d]{5}\\b");
    }
}
