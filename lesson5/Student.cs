using System;

namespace lesson5
{
    public class Student : Person
    {
        public Guid ClassId { get; set; }
        public string StudentId { get; private set; }
        public double Scholarship { get; set; }

        private static long studentCount = 1;

        public Student(string name, DateTime dob, Guid classId, double scholarship)
            : base(name, dob)
        {
            StudentId = generateStudentId();
            ClassId = classId;
            Scholarship = scholarship;
        }

        public override string ToString() => $"{Id} - {StudentId} - {Name} - {Age}";

        private string generateStudentId()
        {
            return $"{studentCount++:D3}-{Dob.Month:D2}{Dob.Day:D2}";
        }
    }
}