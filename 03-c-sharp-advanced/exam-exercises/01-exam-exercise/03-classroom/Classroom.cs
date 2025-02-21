using System.Text;
namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> _students;


        public Classroom(int capacity)
        {
            Capacity = capacity;
            _students = new();
        }


        public int Capacity { get; set; }
        public int Count { get { return _students.Count; } }


        public string RegisterStudent(Student student)
        {
            if (Capacity > 0)
            {
                _students.Add(student);
                Capacity--;
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student != null)
            {
                _students.Remove(student);
                Capacity++;
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var students = _students.Where(s => s.Subject == subject);
            if (students.Any())
            {
                StringBuilder statistics = new();

                statistics.AppendLine($"Subject: {subject}");
                statistics.AppendLine($"Students: ");
                foreach (var student in students)
                {
                    statistics.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return statistics.ToString();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return _students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = _students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student != null)
            {
                return student;
            }

            return null;
        }
    }
}
