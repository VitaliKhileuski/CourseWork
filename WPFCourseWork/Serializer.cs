using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork
{
    public static class Serializer
    {
        public static void SerializeWeeksDataBase(WeeksDataBase weeksDataBase)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(WeeksDataBase));
            using FileStream fileStream = new FileStream("WeeksDataBase.xml", FileMode.Create);
            formatter.Serialize(fileStream,weeksDataBase);
        }
        public static WeeksDataBase DeserializeWeeksDataBase()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(WeeksDataBase));
            using FileStream fileStream = new FileStream("WeeksDataBase.xml", FileMode.OpenOrCreate);
            WeeksDataBase weeks = (WeeksDataBase)formatter.Deserialize(fileStream);
            return weeks;
        }

        public static void SerializeDisciplinesDataBase(List<Semestre> semestres)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Semestre>));
            using FileStream fileStream = new FileStream("DisciplinesDataBase.xml", FileMode.Create);
            formatter.Serialize(fileStream,semestres);
        }
        public static List<Semestre> DeserializeDisciplinesDataBase()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Semestre>));
            using FileStream fileStream = new FileStream("DisciplinesDataBase.xml", FileMode.OpenOrCreate);
            List<Semestre> allDisciplines = (List<Semestre>)formatter.Deserialize(fileStream);
            return allDisciplines;
        }

    }
}
