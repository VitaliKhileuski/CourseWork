using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Models.ElementsOfUniversity;

namespace WPFCourseWork.Data
{

    [Serializable]
    [XmlInclude(typeof(Week))]
    public  class WeeksDataBase
    {
        public StudentGroup StudentGroup;
        public ObservableCollection<Week> Weeks;





        
    }
}
