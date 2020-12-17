using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    [Serializable]
    [XmlInclude(typeof(Teacher))]
    public  class Lesson
    {
        private  Teacher teacher;
        

        private string discipline;

        public Teacher Teacher { get { return teacher; } set { teacher = value; } }
       
        public string Discipline { get => discipline; set => discipline = value; }

        public Lesson(Teacher teacher,string discipline)
        {
            Teacher = teacher;
            Discipline = discipline;

        }
        public Lesson(Lesson lesson)
        {
            Teacher = lesson.Teacher;
            Discipline = lesson.Discipline;
        }
        public Lesson()
        {
            Teacher = new Teacher();
            Discipline = null;
        }
        public override string ToString()
        {
            return discipline;
        }
    }

}
