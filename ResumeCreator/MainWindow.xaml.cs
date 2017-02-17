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
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;

namespace ResumeCreator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Constructor pdf;
        private uint page = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            switch (page)
            {
                case 1:
                    lblPanel1.Foreground = Brushes.Black;
                    lblPanel2.Foreground = Brushes.White;
                    //////////////////////////////////////////
                    lblRow1.Content = "E-Mail";
                    iHint1.Visibility = Visibility.Hidden;
                    Target.Visibility = Visibility.Hidden;
                    EMail.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow3.Content = "Мобильный телефон";
                    iHint3.Visibility = Visibility.Visible;
                    Surname.Visibility = Visibility.Hidden;
                    MPhone.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow5.Content = "Домашний телефон";
                    iHint5.Visibility = Visibility.Hidden;
                    Name.Visibility = Visibility.Hidden;
                    HPhone.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow7.Content = "Город";
                    iHint7.Visibility = Visibility.Visible;
                    Patronymic.Visibility = Visibility.Hidden;
                    City.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow9.Content = "Адрес";
                    Num.Visibility = Visibility.Hidden;
                    Month.Visibility = Visibility.Hidden;
                    Year.Visibility = Visibility.Hidden;
                    Address.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow11.Content = "Гражданство";
                    Salary.Visibility = Visibility.Hidden;
                    Nationality.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow13.Visibility = Visibility.Hidden;
                    Schedule.Visibility = Visibility.Hidden;
                    lblRow15.Visibility = Visibility.Hidden;
                    Employment.Visibility = Visibility.Hidden;
                    //////////////////////////////////////////
                    Next.IsEnabled = false;
                    page++;
                    break;
                case 2:
                    lblPanel2.Foreground = Brushes.Black;
                    lblPanel3.Foreground = Brushes.White;
                    //////////////////////////////////////////
                    lblRow1.Content = "Организация";
                    iHint1.Visibility = Visibility.Visible;
                    EMail.Visibility = Visibility.Hidden;
                    Company.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow3.Content = "Описание деятельности организации";
                    iHint3.Visibility = Visibility.Hidden;
                    MPhone.Visibility = Visibility.Hidden;
                    Description.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow5.Content = "Начало работы";
                    iHint5.Visibility = Visibility.Visible;
                    HPhone.Visibility = Visibility.Hidden;
                    BeginMonth.Visibility = Visibility.Visible;
                    BeginYear.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow7.Content = "Конец работы";
                    City.Visibility = Visibility.Hidden;
                    EndMonth.Visibility = Visibility.Visible;
                    EndYear.Visibility = Visibility.Visible;
                    Present.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow9.Content = "Должность";
                    iHint9.Visibility = Visibility.Visible;
                    Address.Visibility = Visibility.Hidden;
                    Position.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow11.Content = "Основные обязанности";
                    iHint11.Visibility = Visibility.Visible;
                    Nationality.Visibility = Visibility.Hidden;
                    Duties.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow14.Content = "Достижения";
                    lblRow14.Visibility = Visibility.Visible;
                    Achievements.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    Next.IsEnabled = false;
                    page++;
                    break;
                case 3:
                    lblPanel3.Foreground = Brushes.Black;
                    lblPanel4.Foreground = Brushes.White;
                    //////////////////////////////////////////
                    lblRow1.Content = "Учебное заведение";
                    Company.Visibility = Visibility.Hidden;
                    Institution.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow3.Content = "Окончание обучения";
                    iHint3.Visibility = Visibility.Visible;
                    Description.Visibility = Visibility.Hidden;
                    LearnMonth.Visibility = Visibility.Visible;
                    LearnYear.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow5.Content = "Уровень образования";
                    BeginMonth.Visibility = Visibility.Hidden;
                    BeginYear.Visibility = Visibility.Hidden;
                    Education.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow7.Content = "Специальность";
                    EndMonth.Visibility = Visibility.Hidden;
                    EndYear.Visibility = Visibility.Hidden;
                    Present.Visibility = Visibility.Hidden;
                    Specialty.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow9.Visibility = Visibility.Hidden;
                    iHint9.Visibility = Visibility.Hidden;
                    Position.Visibility = Visibility.Hidden;
                    lblRow11.Visibility = Visibility.Hidden;
                    iHint11.Visibility = Visibility.Hidden;
                    Duties.Visibility = Visibility.Hidden;
                    lblRow14.Visibility = Visibility.Hidden;
                    Achievements.Visibility = Visibility.Hidden;
                    //////////////////////////////////////////
                    Next.IsEnabled = false;
                    page++;
                    break;
                case 4:
                    lblPanel4.Foreground = Brushes.Black;
                    lblPanel5.Foreground = Brushes.White;
                    //////////////////////////////////////////
                    lblRow1.Content = "Загрузите фотографию";
                    iHint1.Visibility = Visibility.Hidden;
                    Institution.Visibility = Visibility.Hidden;
                    ImagePath.Visibility = Visibility.Visible;
                    btnImage.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow3.Content = "Провессиональные навыки";
                    lblRow5.Visibility = Visibility.Hidden;
                    iHint5.Visibility = Visibility.Hidden;
                    Education.Visibility = Visibility.Hidden;
                    LearnMonth.Visibility = Visibility.Hidden;
                    LearnYear.Visibility = Visibility.Hidden;
                    Skills.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow7.Content = "Язык";
                    iHint7.Visibility = Visibility.Hidden;
                    Specialty.Visibility = Visibility.Hidden;
                    Language.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow9.Content = "Уровень знания языка";
                    lblRow9.Visibility = Visibility.Visible;
                    Level.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    lblRow11.Content = "Дополнительные сведения";
                    lblRow11.Visibility = Visibility.Visible;
                    Additionally.Visibility = Visibility.Visible;
                    //////////////////////////////////////////
                    Next.Content = "Создать";
                    Next.IsEnabled = false;
                    page++;
                    break;
                case 5:
                    pdf = new Constructor(
                        ImagePath.Text, Surname.Text, Name.Text, Patronymic.Text,
                        Num.Text, Month.Text, Year.Text, Nationality.Text, City.Text,
                        Address.Text, HPhone.Text, MPhone.Text, EMail.Text, Target.Text,
                        Salary.Text, Schedule.Text, Employment.Text, Skills.Text, Institution.Text,
                        LearnMonth.Text, LearnYear.Text, Specialty.Text, Education.Text,
                        Language.Text, Level.Text, Company.Text, Description.Text,
                        Position.Text, BeginMonth.Text, BeginYear.Text, EndMonth.Text,
                        EndYear.Text, Present.IsChecked, Duties.Text, Achievements.Text, Additionally.Text);
                    pdf.CreateFile();
                    this.Close();
                    break;
            }
        }

        private void button_inspect<T>(object sender, T e)
        {
            switch (page)
            {
                case 1:
                    if (Target.Text == "" || Name.Text == "")
                        Next.IsEnabled = false;
                    else Next.IsEnabled = true;
                    break;
                case 2:
                    if (MPhone.Text == "" || City.Text == "")
                        Next.IsEnabled = false;
                    else Next.IsEnabled = true;
                    break;
                case 3:
                    if (Company.Text == ""
                        || BeginMonth.Text == "" || BeginYear.Text == ""
                        || (Present.IsChecked == false && (EndMonth.Text == "" || EndYear.Text == ""))
                        || Position.Text == "" || Duties.Text == "")
                        Next.IsEnabled = false;
                    else Next.IsEnabled = true;
                    break;
                case 4:
                    if (Institution.Text == ""
                        || LearnMonth.Text == "" || LearnYear.Text == ""
                        || Education.Text == "" || Specialty.Text == "")
                        Next.IsEnabled = false;
                    else Next.IsEnabled = true;
                    break;
                case 5:
                    if (Skills.Text == "")
                        Next.IsEnabled = false;
                    else Next.IsEnabled = true;
                    break;
            }
        }

        private void ImagePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Файлы рисунков|*.jpg";
            if (openDlg.ShowDialog() == true)
                ImagePath.Text = openDlg.FileName;
        }
    }
}
