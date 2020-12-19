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

namespace WPFCourseWork.ViewModels
{
    internal class LoginGroupViewModel : ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;

        

        private StudentGroup studentGroup;

        private StudentGroup selectedStudentGroup;

        private WeeksDataBase weeksDataBase;
        private string visibility = "hidden";

        public string Visibility { get => visibility; set => Set(ref visibility, value); }
        public StudentGroup SelectedStudentGroup { get => selectedStudentGroup; set => Set(ref selectedStudentGroup, value); }

        public ObservableCollection<StudentGroup> StudentGroups { get; }
        public StudentGroup StudentGroup { get => studentGroup; set => Set(ref studentGroup, value); }
        #region Back command
        private LambdaCommand backCommand;
        private bool CanBackCommandExecuted(object p) => true;

        private void OnBackCommandExecute(object p)
        {
            _MainCodeBehind.LoadView(ViewType.MainMenu);
        }
        public LambdaCommand BackCommand
        {
            get
            {
                return backCommand = new LambdaCommand(OnBackCommandExecute, CanBackCommandExecuted);
            }

        }
        #endregion
        private LambdaCommand deleteGroupCommand;
        private bool CanDeleteGroupCommandExecute(object p) => p is StudentGroup;

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is StudentGroup group))
            {
                return;
            }
            StudentGroup=null;
            weeksDataBase.StudentGroup=null;
            Serializer.SerializeWeeksDataBase(weeksDataBase);
            if (StudentGroup==null)
            {
                Visibility = "visible";
            }
        }

        public LambdaCommand DeleteGroupCommand
        {
            get
            {
                return deleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);
            }
        }
        private LambdaCommand loginGroupCommand;
        private bool CanLoginGroupCommandExecute(object p) => p is StudentGroup && StudentGroup !=null;

        private void OnLoginGroupCommandExecuted(object p)
        {
          
            weeksDataBase.StudentGroup.Students= new ObservableCollection<Student>(weeksDataBase.StudentGroup.Students.OrderBy(x => x.Surname).ToList());
            Serializer.SerializeWeeksDataBase(weeksDataBase);
            _MainCodeBehind.LoadView(ViewType.WeekList);
        }
        public LambdaCommand LoginGroupCommand
        {
            get
            {
                return loginGroupCommand = new LambdaCommand(OnLoginGroupCommandExecuted, CanLoginGroupCommandExecute);
            }
        }
        public LoginGroupViewModel(IMainWindowsCodeBehind codeBehind,WeeksDataBase data)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            StudentGroups = new ObservableCollection<StudentGroup>();
            weeksDataBase = data;
            StudentGroup=weeksDataBase.StudentGroup;
            StudentGroups.Add(StudentGroup);
            if (StudentGroup ==null)
            {
                Visibility ="Visible";
            }
        }
    }
   

    

}

