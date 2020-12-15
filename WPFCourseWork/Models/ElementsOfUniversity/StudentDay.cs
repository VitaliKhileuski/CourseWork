using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    [Serializable]
    [XmlInclude(typeof(Lesson))]
    public   class StudentDay
    {
        private DateTime date;
        private List<Lesson> lessons;

        public List<Lesson> Lessons { get => lessons; set => lessons = value; }
        public DateTime Date { get => date; set => date = value; }


        public StudentDay()
        {
            Lessons = new List<Lesson>();
        }
        public StudentDay(DateTime date)
        {
            Date = date;
            Lessons = new List<Lesson>();
        }
    }
}
