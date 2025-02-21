namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Color
    {
        private const int NameMaxlength = 50;

        [Key]
        public int Id { get; set; }

        [Unicode]
        [Required]
        [MaxLength(NameMaxlength)]
        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public virtual ICollection<Team> PrimaryTeamKits { get; set; } = new List<Team>();

        [InverseProperty("SecondaryKitColor")]
        public virtual ICollection<Team> SecondaryTeamKits { get; set; } = new List<Team>();
    }
}
