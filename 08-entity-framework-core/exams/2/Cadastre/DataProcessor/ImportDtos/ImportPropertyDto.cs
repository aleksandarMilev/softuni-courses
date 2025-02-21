namespace Cadastre.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Property")]
    public class ImportPropertyDto
    {
        private const int PropertyIdentifierMinLength = 16;
        private const int PropertyIdentifierMaxLength = 20;

        private const int DetailsMinLength = 5;
        private const int DetailsMaxLength = 500;

        private const int AddressMinLength = 2;
        private const int AddressMaxLength = 200;


        [Required]
        [MinLength(PropertyIdentifierMinLength)]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [MinLength(DetailsMinLength)]
        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; }

        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public string DateOfAcquisition { get; set; }
    }
}
