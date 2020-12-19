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
        private Discipline selectedDisciplineForSkips;
        private StudentDay tempCell;
        private int dayindex;
        private int lessonIndex;
        private Discipline newSelectedItem;

        private Discipline temp;

        public Discipline NewSelectedItem { get => newSelectedItem; set => Set(ref newSelectedItem, value); }
        public  Discipline Temp{ get => temp; set => Set(ref temp, value); }
        public int DayIndex { get => dayindex; set => Set(ref dayindex, value); }
        public int LessonIndex { get => lessonIndex; set => Set(ref lessonIndex, value); }
        public Discipline SelectedDisciplineForSKips { get => selectedDisciplineForSkips; set => Set(ref selectedDisciplineForSkips, value); }
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
            Serializer.SerializeWeeksDataBase(weeksData);
            
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

        private bool CanFillSkipsCommandExecute(object p) => p is Discipline;
        private void OnFillSkipsCommandExecuted(object p)
        {
            if (p is Discipline discipline)
            {
                skips SkipsWindow = new skips();
                SkipsViewModel skipsViewModel = new SkipsViewModel(weeksData, SkipsWindow,discipline,DayIndex,LessonIndex);
                SkipsWindow.DataContext = skipsViewModel;
                SkipsWindow.Show();
            }
        }
        public LambdaCommand FillSkipsCommand
        {
            get
            {
                return fillSkipsCommand = new LambdaCommand(OnFillSkipsCommandExecuted, CanFillSkipsCommandExecute);
            }
        }
        #endregion

        private LambdaCommand selectedCommand;
        private bool CanSelectedCommandExecute(object p) => true;
        private void OnSelectedCommandExecuted(object p)
        {
           
            var res = timeTableView.DataGrid.CurrentCell.Column.DisplayIndex;
            StudentDay a = (StudentDay)timeTableView.DataGrid.CurrentCell.Item;
            NewSelectedItem = a.Lessons[res - 2];
        

        }
        public LambdaCommand SelectedCommand
        {
            get
            {
                return selectedCommand = new LambdaCommand(OnSelectedCommandExecuted, CanSelectedCommandExecute);
            }
        }
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
           int p=0;
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
                    p = i;
                    DayIndex = i;
                    LessonIndex = res - 2;
                    break;
                }
            }
            timeTableView.DataGrid.ItemsSource = null;
            timeTableView.DataGrid.ItemsSource = StudentDays;
            SelectedDisciplineForSKips = StudentDays[p].Lessons[res - 2];
        }
    }
}