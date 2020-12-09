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
        private string tempSpeciality;
        private int? tempGroupNumber;
        private int? tempSemestr;
        private bool isCheckBoxPressed;
        private string name;
        private string surname;
        private string thirdname;
        private StudentGroup studentGroup;
        private StudentGroupsDataBase _studentGroupsDataBase;
        private IMainWindowsCodeBehind _MainCodeBehind;
        private Student headOfTheGroup;

        public string TempSpeciality { get => tempSpeciality; set => Set(ref tempSpeciality, value); }

        public int? TempGroupNumber { get => tempGroupNumber; set => Set(ref tempGroupNumber, value); }
        public int? TempSemestr { get => tempSemestr; set => Set(ref tempSemestr, value); }
        public string Name { get => name; set => Set(ref name, value); }
        public string Surname { get => surname; set => Set(ref surname, value); }
        public string Thirdname { get => thirdname; set => Set(ref thirdname, value); }
        public string Speciality { get => speciality; set => Set(ref speciality, value); }

        public int? GroupNumber { get => groupNumber; set => Set(ref groupNumber, value); }

        public int? Semestr { get => semestr; set => Set(ref semestr, value); }

        public bool IsCheckBoxPressed { get => isCheckBoxPressed; set => Set(ref isCheckBoxPressed, value); }
        
        public Student HeadOfTheGroup { get => headOfTheGroup; set => Set(ref headOfTheGroup, value); }
        public ObservableCollection<Student> Students { get; set; }
        public StudentGroup StudentGroupProperty { get; }

        #endregion

        #region SavePropGroupCommand
        private LambdaCommand savePropGroupCommand;

        private bool CanSavePropGroupCommandExecute(object p)
        {
            if (TempGroupNumber == null || string.IsNullOrEmpty(TempSpeciality) || TempSemestr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void OnSavePropGroupCommandExecuted(object p)
        {
            GroupNumber = TempGroupNumber;
            Speciality = TempSpeciality;
            Semestr = TempSemestr;
            StudentGroupProperty.GroupNumber = TempGroupNumber;
            StudentGroupProperty.Speciality = TempSpeciality;
            StudentGroupProperty.Semestr = TempSemestr;
            
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
        private bool CanAddStudentCommandExecute(object p) {

            if (!(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) || string.IsNullOrEmpty(Thirdname)))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        private void OnAddStudentCommandExecuted(object p)
        {
            
                Student student = new Student(Name, Surname, Thirdname);
                Students.Insert(0, student);
            if (IsCheckBoxPressed == true)
            {
                HeadOfTheGroup =student;
                StudentGroupProperty.HeadOfTheGroup = HeadOfTheGroup;
                IsCheckBoxPressed = false;
            }
            ClearStudentTextBoxes();  
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
        #region BackCommand
        private LambdaCommand backCommand;

        private void OnBackCommandExecute(object p)
        {
            _MainCodeBehind.LoadView(ViewType.MainMenu);
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




        public CreateGroupViewModel(IMainWindowsCodeBehind codeBehind,StudentGroupsDataBase data)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            _studentGroupsDataBase = data;
            Students = new ObservableCollection<Student>();
            StudentGroupProperty = new StudentGroup();
           
        

        }


        #region Clear Functions
        private void ClearStudentTextBoxes()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Thirdname = string.Empty;
           
        }
        private void ClearGpoupTextBoxes()
        {
            
            TempSpeciality = String.Empty;
            TempGroupNumber = null;
            TempSemestr = null;

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
        #endregion
    }
}
