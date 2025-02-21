namespace StudentSystem.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private const int NameMaxLength = 100;
        private const int PhoneNumberLength = 10;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Unicode(false)]
        [StringLength(PhoneNumberLength, MinimumLength = PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
