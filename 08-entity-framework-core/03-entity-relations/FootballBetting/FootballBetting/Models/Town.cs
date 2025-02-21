namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        private const int NameMaxLength = 100;

        [Key]
        public int Id { get; set; }

        [Unicode]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } 

        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>(); 

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
