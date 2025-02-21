namespace Cadastre.DataProcessor.ExportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Property")]
    public class ExportPropertyXmlDto
    {
        [Required]
        [XmlAttribute("postal-code")]
        public string DistrictPostalCode { get; set; }

        [Required]
        public string PropertyIdentifier { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [Required]
        public string DateOfAcquisition { get; set; }
    }
}
