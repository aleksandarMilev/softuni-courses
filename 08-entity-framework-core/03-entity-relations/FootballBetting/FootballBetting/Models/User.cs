namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private const int StringsMaxLength = 100;

        [Key]
        public int Id {get; set;}

        [Unicode]
        [Required]
        [MaxLength(StringsMaxLength)]
        public string Username {get; set;}

        [Unicode]
        [Required]
        [MaxLength(StringsMaxLength)]
        public string Password {get; set;}

        [Unicode]
        [Required]
        [MaxLength(StringsMaxLength)]
        public string Email {get; set;}

        [Precision(20, 2)]
        public decimal Balance {get; set; }

        [Unicode]
        [Required]
        [MaxLength(StringsMaxLength)]
        public string Name {get; set;}

        public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}
