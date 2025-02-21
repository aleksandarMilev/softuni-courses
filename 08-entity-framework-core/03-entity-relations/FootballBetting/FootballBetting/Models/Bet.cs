namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Precision(20, 2)]
        public decimal Amount { get; set; }

        [Precision(10, 2)]
        public decimal Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int? UserId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int? GameId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}
