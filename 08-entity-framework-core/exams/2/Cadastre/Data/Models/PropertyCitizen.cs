namespace Cadastre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PropertyCitizen
    {
        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }

        [Required]
        public int CitizenId { get; set; }

        [ForeignKey(nameof(CitizenId))]
        public Citizen Citizen { get; set; }
    }
}
