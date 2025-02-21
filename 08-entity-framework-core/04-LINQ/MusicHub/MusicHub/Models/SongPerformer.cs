namespace MusicHub.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;

    [PrimaryKey(nameof(SongId), nameof(PerformerId))]
    public class SongPerformer
    {
        public int SongId { get; set; }

        [ForeignKey(nameof(SongId))]
        public virtual Song Song { get; set; }

        public int PerformerId { get; set; }

        [ForeignKey(nameof(PerformerId))]
        public virtual Performer Performer { get; set; }
    }
}