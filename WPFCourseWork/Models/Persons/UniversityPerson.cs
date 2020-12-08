using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCourseWork.Models.Persons
{
    [Serializable]
    public abstract partial   class UniversityPerson
    {
        
        private string name;
        private string surname;
        private string thirdname;
        
        //private int age;
       

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Thirdname { get { return thirdname; } set { thirdname = value; } }
        //public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
       // public int Age { get { return age; } set { } }

   

        
        
        public UniversityPerson(string name,string surname,string thirdname)
        {
            Name = name;
            Surname = surname;
            Thirdname = thirdname;
            
            //age = GetAge();
           
        }
        public UniversityPerson()
        {

        }

        //private int GetAge()
        //{
        //    var now = DateTime.Today;
        //    return now.Year - birthDate.Year - 1 +
        //        ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        //}
        

    }
}
