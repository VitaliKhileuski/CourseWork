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
    class CreateGroupViewModel : ViewModel
    {
        #region fields and properties
        private string speciality;
        private int? groupNumber;
        private int? semestr;
        private string name;
        private string surname;
        private string thirdname;
        private StudentGroup studentGroup;
        private StudentGroupsDataBase _studentGroupsDataBase;
        private IMainWindowsCodeBehind _MainCodeBehind;

        public string Name { get => name; set => Set(ref name, value); }
        public string Surname { get => surname; set => Set(ref surname, value); }
        public string Thirdname { get => thirdname; set => Set(ref thirdname, value); }
        public string Speciality { get => speciality; set => Set(ref speciality, value); }

        public int? GroupNumber { get => groupNumber; set => Set(ref groupNumber, value); }

        public int? Semestr { get => semestr; set => Set(ref semestr, value); }

        public ObservableCollection<Student> Students { get; set; }
        public StudentGroup StudentGroupProperty { get; }

        #endregion

        #region SavePropGroupCommand
        private LambdaCommand savePropGroupCommand;

        private bool CanSavePropGroupCommandExecute(object p) => true;
        private void OnSavePropGroupCommandExecuted(object p)
        {
            StudentGroupProperty.GroupNumber = GroupNumber;
            StudentGroupProperty.Speciality = Speciality;
            StudentGroupProperty.Semestr = Semestr;
            ClearGpoupTextBoxes();
        }
        public LambdaCommand SavePropGroupCommand
        {
            get
            {
                return savePropGroupCommand =new LambdaCommand(OnSavePropGroupCommandExecuted, CanSavePropGroupCommandExecute);
            }

        }
        #endregion
        #region add student command
        private LambdaCommand addStudentCommand;
        private bool CanAddStudentCommandExecute(object p) => true;
        private void OnAddStudentCommandExecuted(object p)
        {
            if (!(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) || string.IsNullOrEmpty(Thirdname)))
            {
                Student student = new Student(Name, Surname, Thirdname);
                Students.Insert(0, student);
                ClearStudentTextBoxes();
            }
        }
        public LambdaCommand AddStudentCommand
        {
            get
            {
                return addStudentCommand = new LambdaCommand(OnAddStudentCommandExecuted, CanAddStudentCommandExecute);
            }
        }
        #endregion
        #region SaveGroupCommand
        private LambdaCommand saveGroupCommand;

        private void OnSaveGroupCommandExecute(object p)
        {
            StudentGroupProperty.Students = Students;
            _studentGroupsDataBase.studentGroups.Add(StudentGroupProperty);
            Serializer.SerializeStudentsDataBase(_studentGroupsDataBase.studentGroups);
            ClearProperties();
            _MainCodeBehind.LoadView(ViewType.MainMenu);
        }
        private bool CanSaveGroupCommandExecuted(object p) => true;
        public LambdaCommand SaveGroupCommand
        {
            get
            {
                return saveGroupCommand = new LambdaCommand(OnSaveGroupCommandExecute, CanSaveGroupCommandExecuted);
            }
        }
        #endregion



        public CreateGroupViewModel(IMainWindowsCodeBehind codeBehind,StudentGroupsDataBase data)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            _studentGroupsDataBase = data;
            Students = new ObservableCollection<Student>();
            StudentGroupProperty = new StudentGroup();
           
        

        }
        private void ClearStudentTextBoxes()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Thirdname = string.Empty;
           
        }
        private void ClearGpoupTextBoxes()
        {
            Speciality = String.Empty;
            GroupNumber = null;
            Semestr = null;

        }
        private void ClearProperties()
        {
            Speciality=string.Empty;
            GroupNumber = 0;
            Semestr=0;
            Name=string.Empty;
            Surname=string.Empty;
            Thirdname= string.Empty;
            studentGroup=new StudentGroup();
            Students = new ObservableCollection<Student>();
    }
    }
}
