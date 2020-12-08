using System;
using System.Collections.Generic;
using System.Text;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    class Lesson
    {
        private  Teacher teacher;
        private StudentGroup group;
        private DateTime date;

        


        public Teacher TeacherP { get { return teacher; }set { teacher = value; } }
        public StudentGroup Group { get { return group; } set { group = value; } }
        public DateTime Date { get { return date; } set { date = value; } }

        public Lesson(Teacher teacher,StudentGroup studentGroup,DateTime dateTime)
        {
            TeacherP = teacher;
            Group = studentGroup;
            Date = dateTime;

        }
        public Lesson()
        {

        }
    }

}
