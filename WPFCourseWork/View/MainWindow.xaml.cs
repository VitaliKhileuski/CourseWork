using System;
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
using WPFCourseWork.Data;
using WPFCourseWork.View;
using WPFCourseWork.ViewModels;
using WPFCourseWork.Models;
using WPFCourseWork.Models.ElementsOfUniversity;

namespace WPFCourseWork.ViewModels
{
    public interface IMainWindowsCodeBehind
    {
        void LoadView(ViewType typeView);
    }
    public enum ViewType
    {
        MainMenu,
        CreateGroup,
        LoginGroup,
        WeekList,
        TimeTable
       
}
public partial class MainWindow : Window, IMainWindowsCodeBehind
    {


        public StudentGroupsDataBase groupsDataBase=new StudentGroupsDataBase();
         
        public MainWindow()
        {
            
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            //data
            //загрузка вьюмодел для кнопок меню
            MainWindowViewModel viewModel = new MainWindowViewModel();
            //даем доступ к этому кодбихайнд
            viewModel.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = viewModel;

            //загрузка стартовой View
            LoadView(ViewType.MainMenu);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.MainMenu:
                    MainMenu view = new MainMenu();
                    MainMenuViewModel viewModel = new MainMenuViewModel(this);
                    //связываем их с собой
                    view.DataContext = viewModel;
                    //отображаем
                    this.Page.Content = view;
                    break;
                case ViewType.CreateGroup:
                    CreateGroup CreateGroupView = new CreateGroup();
                    CreateGroupViewModel CreateGroupViewModel = new CreateGroupViewModel(this,groupsDataBase);
                    CreateGroupView.DataContext =CreateGroupViewModel;
                    this.Page.Content =CreateGroupView;
                    break;
                case ViewType.LoginGroup:
                    LoginGroup LoginGroupView = new LoginGroup();
                    LoginGroupViewModel LoginGroupViewModel = new LoginGroupViewModel(this,groupsDataBase);
                    LoginGroupView.DataContext = LoginGroupViewModel;
                    this.Page.Content = LoginGroupView;
                    break;
                case ViewType.WeekList:
                    WeekList WeekListView = new WeekList();
                    WeekListViewModel WeekListViewModel = new WeekListViewModel(this);
                    WeekListView.DataContext = WeekListViewModel;
                    this.Page.Content = WeekListView;
                    break;
            }


        }
       
    }
}
