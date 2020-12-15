using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPFCourseWork.Data
{
    [Serializable]
    [XmlInclude(typeof(Semestre))]
   public class DisciplinesDataBase
    {
        public List<Semestre> allDisciplines;


        public DisciplinesDataBase()
        {
            allDisciplines = Serializer.DeserializeDisciplinesDataBase();
        }
    }
}
