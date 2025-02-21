namespace Cadastre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Property
    {
        private const int PropertyIdentifierMaxLength = 20;
        private const int DetailsMaxLength = 500;
        private const int AddressMaxLength = 200;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new List<PropertyCitizen>();
    }
}
