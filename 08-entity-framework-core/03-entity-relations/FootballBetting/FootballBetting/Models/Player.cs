namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        private const int NameMaxLength = 100;
        private const int SquadNumberMinLength = 1;
        private const int SquadNumberMaxLength = 2;

        [Key]
        public int Id { get; set; }

        [Unicode]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Unicode(false)]
        [StringLength(SquadNumberMaxLength, MinimumLength = SquadNumberMinLength)]
        public string SquadNumber { get; set; }

        public int TownId { get; set; }

        public int PositionId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(TownId))]
        public Town Town { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(PositionId))]
        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public int TeamId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();
    }
}
