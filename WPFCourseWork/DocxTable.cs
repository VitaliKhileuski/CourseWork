using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;
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
            
            string fileName1 = "";
            SaveFileDialog path = new SaveFileDialog();
            
            path.DefaultExt = "docx";
            
            path.ShowDialog();
            fileName1=path.FileName;

            string temp = Getstring();
            var doc = DocX.Create(fileName1);
            
            
            doc.InsertParagraph($"Пропуски за неделю ({data.StudentGroup.Semestr} семестр)").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center;
            doc.InsertParagraph();
            doc.InsertParagraph("(").Bold().FontSize(12).Font("TimesNewRoman").Append(temp).Bold().FontSize(12).Font("TimesNewRoman").Highlight(Highlight.yellow).Append(")").Bold().FontSize(12).Font("TimesNewRoman").Alignment = Alignment.center;
            doc.InsertParagraph();
            doc.InsertParagraph($"СДП-{data.StudentGroup.Speciality}-{data.StudentGroup.GroupNumber}").FontSize(12).Font("TimesNewRoman").Highlight(Highlight.yellow).Bold().Alignment = Alignment.center; 
            doc.InsertParagraph();
            doc.InsertParagraph("Староста: ").Font("TimesNewRoman").FontSize(12).Bold().Append($"{ data.StudentGroup.HeadOfTheGroup.Surname} {data.StudentGroup.HeadOfTheGroup.Name[0]}.{data.StudentGroup.HeadOfTheGroup.Thirdname[0]}.").Highlight(Highlight.yellow).Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center;
            doc.InsertParagraph();
           


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

            
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("ФИО Студента").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Дата пропуска").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Количество пропущенных часов").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Название дисциплины, (преподаватель)").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
            columnIndex++;
            table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append("Причина").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
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
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(student.ToString()).Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center;
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append($"{dateOfSkip.Day}.{dateOfSkip.Month}").Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center;
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(numberOfHours.ToString()).Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center;
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append($"{discipline}\n({teacher})").Font("TimesNewRoman").FontSize(12).Alignment = Alignment.center;
                                columnIndex++;
                                table.Rows[rowIndex].Cells[columnIndex].Paragraphs.First().Append(description).Font("TimesNewRoman").FontSize(12).Bold().Alignment = Alignment.center; 
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

        private string Getstring()
        {
            
            string[] months = new string[12]
            {
                "января",
                "февраля",
                "марта",
                "апреля",
                "мая",
                "июня",
                "июля",
                "августа",
                "сентября",
                "октября",
                "ноября",
                "декабря",
            };
            string currentMonth = months[week.StartOfTheWeek.Month - 1];
            

            string temp =$"с {week.StartOfTheWeek.Day} по {week.EndOfTheWeek.Day} {currentMonth} {week.StartOfTheWeek.Year} года";
            




            return temp;
        }


    }
}
