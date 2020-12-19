using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
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
        }


    }
}
