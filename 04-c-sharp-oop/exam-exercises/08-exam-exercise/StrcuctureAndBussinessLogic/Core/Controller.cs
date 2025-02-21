using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> subjectRepository;
        private IRepository<IStudent> studentRepository;
        private IRepository<IUniversity> universityRepository;

        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjectRepository.Models.Any(s => s.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = CreateSubject(subjectName, subjectType);

            subjectRepository.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjectRepository.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> subjectsIds = new();

            foreach (string reqSubjectName in requiredSubjects)
            {
                subjectsIds.Add(subjectRepository.FindByName(reqSubjectName).Id);
            }

            int universityID = universityRepository.Models.Count() + 1;

            IUniversity university = new University(universityID, universityName, category, capacity, subjectsIds);

            universityRepository.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universityRepository.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (studentRepository.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int studentID = studentRepository.Models.Count() + 1;

            IStudent student = new Student(studentID, firstName, lastName);

            studentRepository.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, studentRepository.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!studentRepository.Models.Any(s => s.Id == studentId))
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            if (!subjectRepository.Models.Any(s => s.Id == subjectId))
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            IStudent student = studentRepository.FindById(studentId);
            ISubject subject = subjectRepository.FindById(subjectId);

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentFullName = studentName.Split();

            if (!studentRepository.Models.Any(s => s.FirstName == studentFullName[0] && s.LastName == studentFullName[1]))
            {
                return string.Format(OutputMessages.StudentNotRegitered, studentFullName[0], studentFullName[1]);
            }

            if (!universityRepository.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            Student student = studentRepository.FindByName(studentName) as Student;
            IUniversity university = universityRepository.FindByName(universityName);

            if (!student.CoveredExams.SequenceEqual(university.RequiredSubjects))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, studentFullName[0], studentFullName[1], universityName);
            }

            student.University = university;

            return string.Format(OutputMessages.StudentSuccessfullyJoined, studentFullName[0], studentFullName[1], universityName);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);

            int studentsAdmitted = studentRepository.Models.Where(s => s.University == university).Count();

            StringBuilder result = new();

            result.AppendLine($"*** {university.Name} ***");
            result.AppendLine($"Profile: {university.Category}");
            result.AppendLine($"Students admitted: {studentsAdmitted}");
            result.AppendLine($"University vacancy: {university.Capacity - studentsAdmitted}");

            return result.ToString().TrimEnd();
        }

        private ISubject CreateSubject(string subjectName, string subjectType)
        {
            int subjectId = subjectRepository.Models.Count() + 1;

            switch (subjectType)
            {
                case "TechnicalSubject":
                    return new TechnicalSubject(subjectId, subjectName);
                case "EconomicalSubject":
                    return new EconomicalSubject(subjectId, subjectName);
                case "HumanitySubject":
                    return new HumanitySubject(subjectId, subjectName);
                default:
                    throw new ArgumentException("Invalid subjectType!");
            }
        }
    }
}
