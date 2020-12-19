using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;
using WPFCourseWork.View;

namespace WPFCourseWork.ViewModels
{
    class SkipsViewModel:ViewModel
    {



        

        private ObservableCollection<Skip> skips;

        private int dayIndex;
        private int lessonIndex;
        private WeeksDataBase weeksDataBase;
        private skips codeBehind;
        private Teacher teacher;
        private string discipline;


        private Discipline currentDiscipline;


        public Teacher Teacher { get => teacher; set => Set(ref teacher, value); }
        public string Discipline { get => discipline; set => Set(ref discipline, value); }
        public int DayIndex { get => dayIndex; set => Set(ref dayIndex, value); }
        public int LessonIndex { get => lessonIndex; set => Set(ref lessonIndex, value); }
        public Discipline CurrentDiscipline { get => currentDiscipline; set => Set(ref currentDiscipline, value); }
        public ObservableCollection<Skip> Skips { get => skips; set=> Set(ref skips, value); } 


        #region save skips command
        private LambdaCommand saveSkipsCommand;
        private bool CanSaveSkipsCommandExecute(object p) => true;

        private void OnSaveSkipsCommandExecuted(object p)
        {
            SaveSkips();
            codeBehind.Close();
           
        }
        public LambdaCommand SaveSkipsCommand
        {
            get
            {
                return saveSkipsCommand = new LambdaCommand(OnSaveSkipsCommandExecuted, CanSaveSkipsCommandExecute);
            }
        }
        #endregion

        public SkipsViewModel(WeeksDataBase weeksData, skips view, Discipline discipline,int dayindex,int lessonIndex)
        {
            weeksDataBase=weeksData;
            Skips = new ObservableCollection<Skip>();
            codeBehind = view;
           // SetGroupSkips();
            CurrentDiscipline = discipline;
            Teacher = CurrentDiscipline.Teacher;
            Discipline = CurrentDiscipline.DisciplineP;
            
            DayIndex = dayindex;
            LessonIndex = lessonIndex;
            Skips = CurrentDiscipline.Skips;
            SetEmptySkips();

        }



      
        private void SetEmptySkips()
        {
            if (Skips.Count == 0)
            {
                for (int i = 0; i < weeksDataBase.StudentGroup.Students.Count; i++)
                {
                    Skips.Add(new Skip());

                    Skips[i].Student = new Student(weeksDataBase.StudentGroup.Students[i]);
                }
            }
        }
        private void SaveSkips()
        {
            for(int i = 0; i < weeksDataBase.Weeks.Count; i++)
            {
                if (weeksDataBase.Weeks[i].StartOfTheWeek == weeksDataBase.SelectedWeek.StartOfTheWeek)
                {
                    weeksDataBase.Weeks[i].StudentDays[DayIndex].Lessons[lessonIndex].Skips = skips;
                    Serializer.SerializeWeeksDataBase(weeksDataBase);
                    break;
                }
            }
        }
    }
}
