namespace Cadastre.Data.Models
{
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class Citizen
    {
        private const int NamesMaxLength = 30;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NamesMaxLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new List<PropertyCitizen>();
    }
}
