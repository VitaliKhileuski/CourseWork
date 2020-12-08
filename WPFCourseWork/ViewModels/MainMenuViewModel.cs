using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCourseWork.Commands;

namespace WPFCourseWork.ViewModels
{
    class MainMenuViewModel:ViewModel
    {

        private IMainWindowsCodeBehind CodeBehind { get; set; }




        #region CreateGroup
        private LambdaCommand toCreateGroupView;
        private bool CanToCreateGroupViewExecute(object p) => true;
        private void OnToCreateGroupViewExecuted(object p)
        {
            CodeBehind.LoadView(ViewType.CreateGroup);
        }

        
        public LambdaCommand ToCreateGroupView
        {
            get
            {
                return toCreateGroupView = toCreateGroupView ??
                 new LambdaCommand(OnToCreateGroupViewExecuted,CanToCreateGroupViewExecute);
            }
        }
        #endregion
        #region LoginGroup
        private LambdaCommand toLoginGroupView;
        private bool CanToLoginGroupViewExecute(object p) => true;
        private void OnToLoginGroupViewExecuted(object p)
        {

            CodeBehind.LoadView(ViewType.LoginGroup);
        }


        public LambdaCommand ToLoginGroupView
        {
            get
            {
                return toLoginGroupView = toLoginGroupView ??
                 new LambdaCommand(OnToLoginGroupViewExecuted, CanToLoginGroupViewExecute);
            }
        }
        #endregion













        public MainMenuViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            CodeBehind = codeBehind;


        }
    }
}
