﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCourseWork.Models.ElementsOfUniversity;

namespace WPFCourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для TimeTable.xaml
    /// </summary>
    public partial class TimeTable : UserControl
    {
        public TimeTable()
        {
            InitializeComponent();
            
            var a = DataGrid.CurrentCell.Item.ToString(); 
        }
    }
}
