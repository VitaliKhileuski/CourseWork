using System;
using System.Collections.Generic;
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
        public static void SerializeStudentsDataBase(List<StudentGroup> studentsGroups)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<StudentGroup>));
            using FileStream fileStream = new FileStream("StudentsDataBase.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fileStream,studentsGroups);
        }
        public static List<StudentGroup> DeserializeStudentsDataBase()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using FileStream fileStream = new FileStream("StudentsDataBase.xml", FileMode.OpenOrCreate);
            List<StudentGroup> studentGroups = (List<StudentGroup>)formatter.Deserialize(fileStream);
            return studentGroups;
        }
    }
}
