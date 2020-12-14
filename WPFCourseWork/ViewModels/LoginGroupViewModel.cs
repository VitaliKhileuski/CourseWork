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
    internal class LoginGroupViewModel : ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;



        private ObservableCollection<StudentGroup> studentGroups;

        private StudentGroup selectedStudentGroup;

        private StudentGroupsDataBase _studentGroupsDataBase;
        private string visibility = "hidden";

        public string Visibility { get => visibility; set => Set(ref visibility, value); }
        public StudentGroup SelectedStudentGroup { get => selectedStudentGroup; set => Set(ref selectedStudentGroup, value); }
        public StudentGroupsDataBase studentGroupsDataBase { get => _studentGroupsDataBase; set => Set(ref _studentGroupsDataBase, value); }

        public ObservableCollection<StudentGroup> StudentGroups { get => studentGroups; set => Set(ref studentGroups, value); }
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
        private bool CanDeleteGroupCommandExecute(object p) => p is StudentGroup && StudentGroups.Contains(p);

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is StudentGroup group))
            {
                return;
            }
            studentGroups.Remove(group);
            _studentGroupsDataBase.studentGroups.Remove(group);
            Serializer.SerializeStudentsDataBase(_studentGroupsDataBase.studentGroups);
            if (StudentGroups.Count == 0)
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
        private bool CanLoginGroupCommandExecute(object p) => p is StudentGroup && StudentGroups.Count != 0;

        private void OnLoginGroupCommandExecuted(object p)
        {
           Serializer.SerializeStudentsDataBase(_studentGroupsDataBase.studentGroups);
            _MainCodeBehind.LoadView(ViewType.WeekList);
        }
        public LambdaCommand LoginGroupCommand
        {
            get
            {
                return loginGroupCommand = new LambdaCommand(OnLoginGroupCommandExecuted, CanLoginGroupCommandExecute);
            }
        }
        public LoginGroupViewModel(IMainWindowsCodeBehind codeBehind, StudentGroupsDataBase data)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            _studentGroupsDataBase = data;
            StudentGroups = _studentGroupsDataBase.studentGroups;
            if (StudentGroups.Count == 0)
            {
                Visibility ="Visible";
            }
            



        }
    }
   

    

}

