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
using WPFCourseWork.Data;
using WPFCourseWork.Models.ElementsOfUniversity;
using WPFCourseWork.Models.Persons;

namespace WPFCourseWork.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {



        public MainWindowViewModel()
        {
        //    List<Discipline> disciplines1 = new List<Discipline>
        //    {
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Безопасность жизнедеятельности человека"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"ГрГУ имени Янки Купалы: миссия, история, структура"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Иностранный язык"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"История Беларуси в контексте европейской цивилизации"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Коррупция и её общественная опасность"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Математика"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Организация и функционирование компьютерных систем"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Основы алгоритмизации и программирования"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Практика программирования"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Русский язык как иностранный"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура(легкая атлетика)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Адаптивный курс математики")
        //    };
        //    List<Discipline> disciplines2 = new List<Discipline>
        //    {
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Белорусский язык (культура речи)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Иностранный язык"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Иностранный язык (профессиональное использование)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Культура мировых цивилизаций"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Курсовая работа по дисциплине 'Основы алгоритмизации и программирования'"),
        //        new Discipline(new Teacher("Иван", "Иванов", "Иванович"), "Математика"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Основы алгоритмизации и программирования"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Права человека"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Прикладное программирование"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физика"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура(легкая атлетика)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Языки программирования"),
        //    };
        //    List<Discipline> disciplines3 = new List<Discipline>
        //    {
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Военная подготовка (младшие командиры)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Дискретная математика"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Иностранный язык (профессиональное использование)"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Компьютерные технологии в математике"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Курсовой проект по дисциплине 'Языки программирования'"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Математика"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Основы инновационного предпринимательства"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Основы компьютерных сетей"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Программирование сервисов для платформы Arduino"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Социология"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Экономическая теория"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Языки программирования"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура"),
        //        new Discipline(new Teacher("Иван", "Иванов","Иванович"),"Физическая культура(легкая атлетика)")
        //    };

            //    Semestre first = new Semestre(1, disciplines1);
            //    Semestre second = new Semestre(2, disciplines2);
            //    Semestre third = new Semestre(3, disciplines3);

            //    List<Semestre> semestres = new List<Semestre>()
            //    {
            //        first,second,third
            //};
            //    DisciplinesDataBase data = new DisciplinesDataBase();
            //    Serializer.SerializeDisciplinesDataBase(semestres);

            }


        public IMainWindowsCodeBehind CodeBehind { get; set; }

    }



    }
