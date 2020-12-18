using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        private ObservableCollection<StudentDay> studentDays; 
        private List<Discipline> disciplines;
        private DisciplinesDataBase allDisciplines;
        private Discipline selectedDiscipline;
        private StudentDay tempCell;
        public Lesson TempLesson { get; set; }

        

        public StudentDay TempCell { get => tempCell; set => Set(ref tempCell, value); }
        public Discipline SelectedDiscipline { get => selectedDiscipline; set => Set(ref selectedDiscipline, value); }
        public List<Discipline> Disciplines { get => disciplines; set => Set(ref disciplines, value); }
        public Week CurrentWeek { get => currentWeek; set => Set(ref currentWeek, value); }
        public ObservableCollection<StudentDay> StudentDays { get => studentDays; set => Set(ref studentDays,value); }

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


        #region Set Discipline Command
        private LambdaCommand setDisciplineCommand;
        private bool CanSetDisciplineCommandExecute(object p) => true;
        private void OnSetDisciplineCommandExecuted(object p)
        {
            SetDiscipline();
            
        }
        public LambdaCommand SetDisciplineCommand
        {
            get
            {
                return setDisciplineCommand = new LambdaCommand(OnSetDisciplineCommandExecuted, CanSetDisciplineCommandExecute);
            }
        }
        #endregion


        #region fill skips
        private LambdaCommand fillSkipsCommand;

        private bool CanFillSkipsCommandExecute(object p) => true;
        private void OnFillSkipsCommandExecuted(object p)
        {
            skips SkipsWindow = new skips();
            SkipsWindow.Show();
        }
        public LambdaCommand FillSkipsCommand
        {
            get
            {
                return fillSkipsCommand = new LambdaCommand(OnFillSkipsCommandExecuted, CanFillSkipsCommandExecute);
            }
        }
        #endregion
        public TimeTableViewModel(IMainWindowsCodeBehind codeBehind, WeeksDataBase weeksDataBase, DisciplinesDataBase disciplinesDataBase,TimeTable view)
        {
            _MainCodeBehind = codeBehind;
            weeksData = weeksDataBase;
            CurrentWeek = weeksData.SelectedWeek;
            StudentDays = CurrentWeek.StudentDays;
            
            allDisciplines = disciplinesDataBase;
            Disciplines = SetDisciplines(weeksData.StudentGroup, allDisciplines).Disciplines;
            
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


        public void SetDiscipline()
        {
           
            int res = timeTableView.DataGrid.SelectedCells[0].Column.DisplayIndex;
            if (res == 0 || res == 1)
            {
                return;
            }
            TempCell =(StudentDay)timeTableView.DataGrid.SelectedCells[0].Item;
           for(int i = 0; i < StudentDays.Count; i++)
            {
                if (TempCell.DayOfWeek == StudentDays[i].DayOfWeek)
                {
                    StudentDays[i].Lessons[res-2] = SelectedDiscipline;
                    
                    break;
                }
            }
            timeTableView.DataGrid.ItemsSource = null;
            timeTableView.DataGrid.ItemsSource = StudentDays;
        }
    }
}