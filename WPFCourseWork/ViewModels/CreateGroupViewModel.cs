using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.ViewModels
{
    class CreateGroupViewModel : ViewModel
    {
        #region fields and properties
        private string speciality;
        private int groupnumber;
        private int semestr;
        private string name;
        private string surname;
        private string thirdname;

        public string Name { get => name; set => Set(ref name, value); }
        public string Surname { get => surname; set => Set(ref surname, value); }
        public string Thirdname { get => thirdname; set => Set(ref thirdname, value); }
        public string Speciality { get => speciality; set => Set(ref speciality, value); }

        public int GroupNumber { get => groupnumber; set => Set(ref groupnumber, value); }

        public int Semestr { get => semestr; set => Set(ref semestr, value); }

        public ObservableCollection<Student> Students { get; }
        public StudentGroup studentGroup { get; }

        #endregion

        #region save group properties
        private LambdaCommand savePropGroupCommand;

        private bool CanSavePropGroupCommandExecute(object p) => true;
        private void OnSavePropGroupCommandExecuted(object p)
        {

            

        }
        public LambdaCommand SavePropGroupCommand
        {
            get
            {
                return savePropGroupCommand = savePropGroupCommand ??
                new LambdaCommand(OnSavePropGroupCommandExecuted, CanSavePropGroupCommandExecute);
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
                ClearTextBoxes();
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
        private  LambdaCommand saveGroupCommand;

        private void OnSaveGroupCommandExecute(object p)
        {
           
        }
        private bool CanSaveGroupCommandExecuted(object p) => true;



        private IMainWindowsCodeBehind _MainCodeBehind;
        public CreateGroupViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;


            Students = new ObservableCollection<Student>();
        

        }
        private void ClearTextBoxes()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Thirdname = string.Empty;
        }
    }
}
