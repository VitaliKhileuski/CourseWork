using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPFCourseWork.Commands;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {



        public MainWindowViewModel()
        {
            
        }


        public IMainWindowsCodeBehind CodeBehind { get; set; }

        



    }
}