using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    [Serializable]
    [XmlInclude(typeof(Student))]
    public   class StudentGroup
    {
        private string speciality;
        private ObservableCollection<Student> students;
        private Student headOfTheGroup;
        private int? groupnumber;
        private int? semestr;


        public ObservableCollection<Student> Students { get { return students; } set { students = value; } }
       
        public Student HeadOfTheGroup { get { return headOfTheGroup; } set { headOfTheGroup = value; } }
        
        public string Speciality { get { return speciality; } set { speciality = value; } }

        public int? GroupNumber { get { return groupnumber; } set { groupnumber = value; } }

        public int? Semestr { get { return semestr; } set { semestr = value;  } }


        public StudentGroup(string speciality, ObservableCollection<Student> students, Student headOfTheGroup,int groupNumber,int semestr)
        {
            Speciality = speciality;
            Students = students;
            HeadOfTheGroup = headOfTheGroup;
            GroupNumber = groupNumber;
            Semestr = semestr;
        }
        public StudentGroup()
        {
            Students = new  ObservableCollection<Student>();
            HeadOfTheGroup = new Student();
        }

        public int GetAmountOfStudents()
        {
            return Students.Count;
        }

        public override string ToString()
        {
            return $"{Speciality}-{GroupNumber}, {HeadOfTheGroup.Surname} {HeadOfTheGroup.Name}";
        }






    }
}
