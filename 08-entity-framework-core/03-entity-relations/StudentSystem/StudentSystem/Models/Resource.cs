namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Models.Enums;

    public class Resource
    {
        private const int NameMaxLength = 50;

        [Key]
        public int Id { get; set; }

        [Required]
        [Unicode]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Url { get; set; }

        [EnumDataType(typeof(ResourceType))]
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
