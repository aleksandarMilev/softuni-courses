namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using StudentSystem.Models.Enums;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Unicode(false)]
        public string Content { get; set; }

        [EnumDataType(typeof(ContentType))]
        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int CourseId { get; set; }

        [Required]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public int StudentId { get; set; }

        [Required]
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
    }
}
