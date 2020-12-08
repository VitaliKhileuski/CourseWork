using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCourseWork.Models.Persons
{
     public class Student : UniversityPerson
    {

       
        
        public Student(string name, string surname, string thirdname) : base(name, surname, thirdname)
        {
            
         
        }
        public Student()
        {

        }
        //public void TransferToNextCourse()
        //{
        //    if ()
        //    {
        //        CourseNumber++;
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("student already on the last course");
        //    }
        //}
    }
}
