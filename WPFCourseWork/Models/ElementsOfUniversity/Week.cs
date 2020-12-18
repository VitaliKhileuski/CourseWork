using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFCourseWork.Models.ElementsOfUniversity
{
    [Serializable]
    [XmlInclude(typeof(StudentDay))]
    public class Week
    {   

        private DateTime startOfTheWeek;
        private DateTime endOfTheWeek;
        private ObservableCollection<StudentDay> studentDays;

        public ObservableCollection<StudentDay> StudentDays { get => studentDays; set => studentDays = value; }
        public DateTime StartOfTheWeek { get => startOfTheWeek;
            set
            {
                startOfTheWeek = value;
                EndOfTheWeek = startOfTheWeek.AddDays(6);
            }
        }

        public DateTime EndOfTheWeek { get => endOfTheWeek; set => endOfTheWeek = value; }


        public Week()
        {
            StudentDays = new ObservableCollection<StudentDay>();

        }
        public Week(DateTime startOfTheWeek)
        {
            StartOfTheWeek = startOfTheWeek;
            StudentDays = new ObservableCollection<StudentDay>();
            for(int i = 0; i < 7; i++)
            {
                StudentDays.Add(new StudentDay(StartOfTheWeek.AddDays(i)));
            }
           
             
            

            

        }


        public override string ToString()
        {
            return $"{StartOfTheWeek.Day}.{StartOfTheWeek.Month}.{StartOfTheWeek.Year}-{EndOfTheWeek.Day}.{EndOfTheWeek.Month}.{EndOfTheWeek.Year}";
        }


        

    }
}
