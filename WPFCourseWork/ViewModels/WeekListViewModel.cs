using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseWork.ViewModels
{
   internal class WeekListViewModel :ViewModel
    {
        private IMainWindowsCodeBehind _MainCodeBehind;




        public WeekListViewModel(IMainWindowsCodeBehind codeBehind) 
        {
            _MainCodeBehind = codeBehind;

        }
    }
}
