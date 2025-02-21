namespace FootballBetting.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private const int NameMaxLength = 100;

        [Key]
        public int Id { get; set; }

        [MaxLength(NameMaxLength)]
        [Required]
        [Unicode]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
    }
}
