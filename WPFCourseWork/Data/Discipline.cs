using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Data
{
    [Serializable]
    [XmlInclude(typeof(Teacher))]
    public  class Discipline
    {
        private string discipline;
        private Teacher teacher;
        private ObservableCollection<Skip> skips;
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public string DisciplineP { get => discipline; set => discipline = value; }

        public ObservableCollection<Skip> Skips { get => skips; set => skips = value; }



        public Discipline()
        {
            Teacher = null;
            Skips = new ObservableCollection<Skip>();

        }
        public Discipline(Teacher teacher,string discipline,ObservableCollection<Skip> skips)
        {
            Teacher = teacher;
            DisciplineP = discipline;
            Skips = skips;
        }
        public Discipline(Discipline discipline)
        {
            this.DisciplineP = discipline.DisciplineP;
            this.Teacher = discipline.Teacher;
            this.Skips = discipline.Skips;
        }
        public override string ToString()
        {
            //string s=string.Empty;

            //string[] temp = DisciplineP.Split(' ');
            //if (temp.Length > 2)
            //{
            //    for(int i = 0; i < temp.Length; i++)
            //    {
            //        if (i % 2 == 1)
            //        {
            //            s +=temp[i]+"\n";
            //        }
            //        else s += temp[i];

            //    }
            //    return s;
            //}
            return discipline;
        }
    }
}
