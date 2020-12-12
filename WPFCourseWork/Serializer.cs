using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork
{
    public static class Serializer
    {
        public static void SerializeStudentsDataBase(ObservableCollection<StudentGroup> studentsGroups)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<StudentGroup>));
            using FileStream fileStream = new FileStream("GroupOfStudentsDataBase.xml", FileMode.Create);
            formatter.Serialize(fileStream,studentsGroups);
        }
        public static ObservableCollection<StudentGroup> DeserializeStudentsDataBase()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<StudentGroup>));
            using FileStream fileStream = new FileStream("GroupOfStudentsDataBase.xml", FileMode.OpenOrCreate);
            ObservableCollection<StudentGroup> studentGroups = (ObservableCollection<StudentGroup>)formatter.Deserialize(fileStream);
            return studentGroups;
        }
    }
}
