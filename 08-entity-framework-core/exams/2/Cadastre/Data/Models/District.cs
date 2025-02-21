namespace Cadastre.Data.Models
{
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class District
    {
        private const int NameMaxLength = 80;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string PostalCode { get; set; } 

        [Required]
        public Region Region { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
