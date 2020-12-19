using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Data;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    [Serializable]
    [XmlInclude(typeof(Discipline))]
    public class StudentDay
    {
        private DayOfWeek dayOfWeek;
        private DateTime date;
        private List<Discipline> lessons;

        public List<Discipline> Lessons { get => lessons; set => lessons = value; }
        public DateTime Date { get => date; set => date = value; }
        public DayOfWeek DayOfWeek{ get => dayOfWeek; set => dayOfWeek=value;}

        public StudentDay()
        {
            
            Lessons = new List<Discipline>();
           
        }
        public StudentDay(DateTime date)
        {
            Date = date;
            Lessons = new List<Discipline>();
            for (int i = 0; i < 5; i++)
            {
                Lessons.Add(new Discipline());
            }
            DayOfWeek = date.DayOfWeek;
        }
        public override string ToString()
        {
            return $"{Date.Day}.{Date.Month}";
            
        }
    }
}
