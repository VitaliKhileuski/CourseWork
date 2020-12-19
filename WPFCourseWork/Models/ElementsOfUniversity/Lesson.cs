//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text;
//using System.Xml.Serialization;
//using WPFCourseWork.Models.Persons;

//namespace WPFCourseWork.Models.ElementsOfUniversity
//{
//    [Serializable]
//    [XmlInclude(typeof(Teacher))]
//    public  class Lesson
//    {
//        private  Teacher teacher;
        

//        private string discipline;

//        private ObservableCollection<Skip> skips;

//        public Teacher Teacher { get { return teacher; } set { teacher = value; } }
       
//        public string Discipline { get => discipline; set => discipline = value; }

//        public ObservableCollection<Skip> Skips { get => skips; set =>  skips= value; }

//        public Lesson(Teacher teacher,string discipline,ObservableCollection<Skip> skips)
//        {
//            Teacher = teacher;
//            Discipline = discipline;
//            Skips = skips;

//        }
//        public Lesson(Lesson lesson)
//        {
//            Teacher = lesson.Teacher;
//            Discipline = lesson.Discipline;
//            Skips = lesson.Skips;
//        }
//        public Lesson()
//        {
//            Teacher = new Teacher();
//            Discipline = null;
//            Skips = new ObservableCollection<Skip>();

//        }
//        public override string ToString()
//        {
//            return discipline;
//        }
//    }

//}
