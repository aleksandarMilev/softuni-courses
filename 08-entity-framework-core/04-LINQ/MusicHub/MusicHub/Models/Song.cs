namespace MusicHub.Models
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Song
    {
        private const int NameMaxLength = 20;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }   

        public TimeSpan Duration { get; set; }   

        public DateTime CreatedOn { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }   

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }   

        public int? WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public Writer Writer { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; } = new List<SongPerformer>();
    }
}