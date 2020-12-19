using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    public class Skip
    {
        private Student student;
        private bool isAbsent;
        private string description;


        public Student Student { get => student; set => student = value; }
        public bool IsAbsent { get => isAbsent; set => isAbsent = value; }

        public string Description { get => description; set => description = value; }

        public Skip()
        {
            Student = new Student();
            IsAbsent = false;
        }
        public Skip(Student student, bool isAbsent,string description)
        {
            Student = student;
            IsAbsent = isAbsent;
            Description = description;
        }

    }
}
