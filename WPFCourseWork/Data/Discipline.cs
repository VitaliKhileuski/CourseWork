using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.Data
{
    [Serializable]
    [XmlInclude(typeof(Teacher))]
    public  class Discipline
    {
        private string discipline;
        private Teacher teacher;
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public string DisciplineP { get => discipline; set => discipline = value; }

        public Discipline(Teacher teacher,string discipline)
        {
            Teacher = teacher;
            DisciplineP = discipline;
        }
        public Discipline()
        {

        }
    }
}
