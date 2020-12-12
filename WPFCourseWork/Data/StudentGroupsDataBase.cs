using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Models.ElementsOfUniversity;

namespace WPFCourseWork.Data
{
    public class StudentGroupsDataBase
    {
        public ObservableCollection<StudentGroup> studentGroups;



        public StudentGroupsDataBase()
        {

            studentGroups=Serializer.DeserializeStudentsDataBase();
        }
    }
}
