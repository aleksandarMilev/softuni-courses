namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        private const int NameMaxLength = 100;
        private const int InitialsLength = 3;

        [Key]
        public int Id { get; set; }

        [MaxLength(NameMaxLength)]
        [Required]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [Unicode(false)]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(InitialsLength, MinimumLength = InitialsLength)]
        public string Initials { get; set; }

        [Precision(18, 2)]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(PrimaryKitColorId))]
        public Color PrimaryKitColor { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(SecondaryKitColorId))]
        public Color SecondaryKitColor { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeTeamGames { get; set; } = new List<Game>();

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayTeamGames { get; set; } = new List<Game>();
    }
}
