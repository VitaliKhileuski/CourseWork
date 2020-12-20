using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WPFCourseWork
{
   public class DocxTable
    {
        private WeeksDataBase data;
        private Week week;


        public DocxTable(WeeksDataBase dataBase)
        {
            data = dataBase;
            week = data.SelectedWeek;
            CreateTable();
        }
        public void CreateTable()
        {
            string fileName = @"C:\test\exempleWord3.docx";
            var doc = DocX.Create(fileName);
            int numberOfSkips = CalculateSkips();
            Table t = doc.AddTable(1 + numberOfSkips, 5);
            t.Alignment = Alignment.center;
            t = FillTable(t);
            doc.InsertTable(t);
            doc.Save();
        }
        private Table FillTable(Table table)
        {
            int rowIndex = 0;
            int columnIndex = 0;
            
            DateTime dateOfSkip=new DateTime();
            Student student=null;
            string description="";
            Teacher teacher=null;
            string discipline="";
            const int numberOfHours = 2;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("ФИО Студента");
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Дата пропуска");
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Количество пропущенных часов");
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Название дисциплины, (преподаватель)");
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("ПРичина");
            columnIndex = 0;
            
            foreach(var studentDay in week.StudentDays)
            {
                for(int i = 0; i < studentDay.Lessons.Count; i++)
                {
                    if (studentDay.Lessons[i] != null)
                    {
                        for(int j = 0; j < studentDay.Lessons[i].Skips.Count; j++)
                        {
                            if (studentDay.Lessons[i].Skips[j].IsAbsent == true)
                            {
                                dateOfSkip = studentDay.Date;
                                student = studentDay.Lessons[i].Skips[j].Student;
                                description = studentDay.Lessons[i].Skips[j].Description;
                                teacher = studentDay.Lessons[i].Teacher;
                                discipline = studentDay.Lessons[i].DisciplineP;
                                rowIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(student.ToString());
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(dateOfSkip.ToString());
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(numberOfHours.ToString());
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append($"{discipline}({teacher})");
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(description);
                                columnIndex = 0;
                            }
                        }
                    }
                }
            }


            


            return table;
        }
        private int CalculateSkips()
        {
            int n = 0;
            foreach (var studentDay in week.StudentDays)
            {
                foreach(var lesson in studentDay.Lessons)
                {
                    if (lesson != null)
                    {
                        foreach (var skip in lesson.Skips)
                        {
                            if (skip.IsAbsent == true)
                            {
                                n++;
                            }
                        }
                    }
                }
            }
            
            return n;
        }

    }
}
