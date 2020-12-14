using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;

namespace WPFCourseWork.ViewModels
{
    internal class WeekListViewModel : ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;

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
            _MainCodeBehind.LoadView(ViewType.TimeTable);
        }
        public LambdaCommand ChoosewWeekCommand{

            get
            {
                return chooseWeekCommand = new LambdaCommand(OnChooseWeekCommandExecuted, CanChooseWeekCommandExecute);
            }
            }
        #endregion

        public WeekListViewModel(IMainWindowsCodeBehind codeBehind) 
        {
            _MainCodeBehind = codeBehind;

        }
    }
}
