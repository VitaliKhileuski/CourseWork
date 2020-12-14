using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseWork.Commands;

namespace WPFCourseWork.ViewModels
{
    class TimeTableViewModel : ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;

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


        public TimeTableViewModel(IMainWindowsCodeBehind codeBehind)
        {
            _MainCodeBehind = codeBehind;

        }
    }
}
