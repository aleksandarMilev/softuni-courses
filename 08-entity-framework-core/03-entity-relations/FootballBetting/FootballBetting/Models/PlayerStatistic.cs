namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;

    [PrimaryKey(nameof(GameId), nameof(PlayerId))]
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        public int PlayerId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int Assists { get; set; }

        public int MinutesPlayed { get; set; }
    }
}
