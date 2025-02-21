namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private const int ResultMaxLength = 10;

        [Key]
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        [Precision(5, 2)]
        public decimal HomeTeamBetRate { get; set; }

        [Precision(5, 2)]
        public decimal AwayTeamBetRate { get; set; }

        [Precision(5, 2)]
        public decimal DrawBetRate { get; set; }

        [Required]
        [MaxLength(ResultMaxLength)]
        public string Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();

        public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}
