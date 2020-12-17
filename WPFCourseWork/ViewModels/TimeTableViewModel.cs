using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.View;

namespace WPFCourseWork.ViewModels
{
    class TimeTableViewModel : ViewModel
    {
        private TimeTable timeTableView;
        private WeeksDataBase weeksData;
        private IMainWindowsCodeBehind _MainCodeBehind;
        private Week currentWeek;
        private List<StudentDay> studentDays; 
        private List<Discipline> disciplines;
        private DisciplinesDataBase allDisciplines;
        private Discipline selectedDiscipline;
        private StudentDay tempCell;
        public Lesson TempLesson { get; set; }

        

        public StudentDay TempCell { get => tempCell; set => Set(ref tempCell, value); }
        public Discipline SelectedDiscipline { get => selectedDiscipline; set => Set(ref selectedDiscipline, value); }
        public List<Discipline> Disciplines { get => disciplines; set => Set(ref disciplines, value); }
        public Week CurrentWeek { get => currentWeek; set => Set(ref currentWeek, value); }
        public List<StudentDay> StudentDays { get => studentDays; set => Set(ref studentDays,value); }

        #region BackCommand
        private LambdaCommand backCommand;

        private void OnBackCommandExecute(object p)
        {
            _MainCodeBehind.LoadView(ViewType.WeekList);
        }
        private bool CanBackCommandExecuted(object p) => true;
        public LambdaCommand BackCommand
        {
            get
            {
                return backCommand = new LambdaCommand(OnBackCommandExecute, CanBackCommandExecuted);
            }
        }
        #endregion


        #region cell command
        private LambdaCommand cellCommand;
        private bool CanCellCommandExecute(object p) => true;
        private void OnCellCommandExecuted(object p)
        {
            SetTempCell();
        }
        public LambdaCommand CellCommand
        {
            get
            {
                return cellCommand = new LambdaCommand(OnCellCommandExecuted, CanCellCommandExecute);
            }
        }
        #endregion
        public TimeTableViewModel(IMainWindowsCodeBehind codeBehind, WeeksDataBase weeksDataBase, DisciplinesDataBase disciplinesDataBase,TimeTable view)
        {
            _MainCodeBehind = codeBehind;
            weeksData = weeksDataBase;
            CurrentWeek = weeksData.SelectedWeek;
            StudentDays = CurrentWeek.StudentDays;
            StudentDays[0].Lessons[0].DisciplineP = "sraka";
            allDisciplines = disciplinesDataBase;
            Disciplines = SetDisciplines(weeksData.StudentGroup, allDisciplines).Disciplines;
            TempLesson = new Lesson(null, "sraka");
            timeTableView = view;
          

        }


        private Semestre SetDisciplines(StudentGroup group, DisciplinesDataBase data)
        {
            Semestre temp = new Semestre();
            for (int i = 0; i < data.allDisciplines.Count; i++)
            {
                if (group.Semestr == data.allDisciplines[i].number)
                {
                    temp = data.allDisciplines[i];
                }
            }
           
         return temp;
        }


        public void SetTempCell()
        {
            TempCell = (StudentDay)timeTableView.DataGrid.SelectedCells[0].Item;
        }
    }
}