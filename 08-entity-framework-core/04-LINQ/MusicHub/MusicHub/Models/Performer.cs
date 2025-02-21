namespace MusicHub.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        private const int NamesMaxLength = 20;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NamesMaxLength)]
        public int FirstName { get; set; }

        [Required]
        [MaxLength(NamesMaxLength)]
        public int LastName { get; set; }

        public int Age { get; set; }

        [Precision(18, 2)]
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = new List<SongPerformer>();
    }
}