namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        private const int NameMaxlength = 50;

        [Key]
        public int Id { get; set; }

        [Unicode]
        [Required]
        [MaxLength(NameMaxlength)]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
