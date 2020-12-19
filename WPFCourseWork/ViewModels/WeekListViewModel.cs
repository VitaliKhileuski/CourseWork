using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;


namespace WPFCourseWork.ViewModels
{
    internal class WeekListViewModel : ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;

        private StudentGroup studentGroup;

        private Week selectedWeek;

        private WeeksDataBase weeksData;
        private ObservableCollection<Week> weeks;

        private Discipline selectedDiscipline;
        public Week SelectedWeek { get => selectedWeek; set => Set(ref selectedWeek, value); }

        public ObservableCollection<Week> Weeks { get => weeks; set => Set(ref weeks, value); }

        public Discipline SelectedDiscipline { get => selectedDiscipline; set => Set(ref selectedDiscipline, value); }
        

        public StudentGroup StudentGroup { get => studentGroup; set => Set(ref studentGroup, value); }

        #region BackCommand
        private LambdaCommand backCommand;

        private void OnBackCommandExecute(object p)
        {
            
            _MainCodeBehind.LoadView(ViewType.LoginGroup);
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
        #region Choose week command
        private LambdaCommand chooseWeekCommand;

        private bool CanChooseWeekCommandExecute(object p) => true;

        private void OnChooseWeekCommandExecuted(object p)
        {
            weeksData.SelectedWeek = SelectedWeek;
            _MainCodeBehind.LoadView(ViewType.TimeTable);
            
            
        }
        public LambdaCommand ChoosewWeekCommand{

            get
            {
                return chooseWeekCommand = new LambdaCommand(OnChooseWeekCommandExecuted, CanChooseWeekCommandExecute);
            }
            }
        #endregion
        

        public WeekListViewModel(IMainWindowsCodeBehind codeBehind ,WeeksDataBase weeksData) 
        {
            _MainCodeBehind = codeBehind;
            StudentGroup = weeksData.StudentGroup;
            this.weeksData = weeksData;
            Weeks = weeksData.Weeks;
            CreateWeekList();
            Weeks=SortByDateLinq(Weeks);

            SelectedWeek = Weeks[0];
            
        }

        public void CreateWeekList()
        {
            DateTime temp = DateTime.Today;
            if (Weeks.Count==0)
            {
                SetNewWeek(temp);
                
            }
            else
            {
                while (DateTime.Today.Subtract(Weeks[Weeks.Count-1].EndOfTheWeek).Days > 7)
                {
                    Week week = new Week(Weeks[Weeks.Count - 1].EndOfTheWeek.AddDays(1));
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            for (int z = 0; z < weeksData.StudentGroup.Students.Count; i++)
                            {
                                week.StudentDays[i].Lessons[j].Skips[z] = new Skip();
                            }
                        }
                    }

                    Weeks.Add(week);
                }
            }
           
        }
        private void SetNewWeek(DateTime temp)
        {
            while (temp.DayOfWeek != DayOfWeek.Monday)
            {
                temp = temp.AddDays(-1);
            }
            
            Week week = new Week(temp);
            for(int i = 0; i < 7; i++)
            {
                for( int j = 0; j < 5; j++)
                {
                    for(int z = 0; z < weeksData.StudentGroup.Students.Count; z++)
                    {
                        week.StudentDays[i].Lessons[j].Skips.Add(new Skip());
                    }
                }
            }
                Weeks.Add(week);
            
        }
      
        public ObservableCollection<Week> SortByDateLinq(ObservableCollection<Week> weeks)
        {
            
           return new ObservableCollection<Week>(weeks.OrderByDescending(x => x.StartOfTheWeek).ToList());
        }

    }
}
