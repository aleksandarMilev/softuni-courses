﻿using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using System;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private readonly List<int> coveredExams;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new();
        }

        public int Id { get; private set; }
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                lastName = value;
            }
        }
        public IReadOnlyCollection<int> CoveredExams
            => coveredExams.AsReadOnly();

        public IUniversity University { get; set; }

        public void CoverExam(ISubject subject)
            => coveredExams.Add(subject.Id);

        public void JoinUniversity(IUniversity university)
            => University = university;
    }
}
