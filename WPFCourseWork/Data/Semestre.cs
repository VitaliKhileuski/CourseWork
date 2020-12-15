using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseWork.Data
{
    [Serializable]

    public class Semestre
    {
        public List<Discipline> Disciplines;
        public int number;
        public Semestre()
        {

            Disciplines = new List<Discipline>();
        }
        public Semestre(int number, List<Discipline> disciplines)
        {
            this.number = number;
            Disciplines = disciplines;
        }
    }
}
