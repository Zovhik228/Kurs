﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages.AddPages
{
    /// <summary>
    /// Логика взаимодействия для Dogovor.xaml
    /// </summary>
    public partial class Dogovor : Page
    {
        ClassModules.Dogovora dogovora;
        public Dogovor(ClassModules.Dogovora _dogovora)
        {
            InitializeComponent();
            dogovora = _dogovora;
            if (_dogovora.Organization != null)
            {
                Date.Text = _dogovora.Date.ToString("dd-MM-yyyy");
                organization.Text = _dogovora.Organization;
                Contract_cost.Text = _dogovora.Contract_cost;
            }
        }

        private void Click_Companies_Redact(object sender, RoutedEventArgs e)
        {
                int id = Login.connection.SetLastId(ClassConnection.Connection.Tables.dogovora);
                if (dogovora.Organization == null)
                {
                    string query = $"INSERT INTO companies ([Id_companies], [Name_companies], [Commander], [Date_foundation], [Date_update_information]) VALUES ({id.ToString()}, N'{Name_companies.Text}', N'{Commander.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                    var query_apply = Login.connection.Query(query);
                    if (query_apply != null)
                    {
                        Login.connection.LoadData(ClassConnection.Connection.Tables.dogovora);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.dogovora);
                    }
                    else MessageBox.Show("Запрос на добавление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"UPDATE companies SET Name_companies = N'{Name_companies.Text}', Commander = N'{Commander.Text}', Date_update_information = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE Id_companies = {companies.Id_companies}";
                    var query_apply = Login.connection.Query(query);
                    if (query_apply != null)
                    {
                        Login.connection.LoadData(ClassConnection.Connection.Tables.dogovora);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.dogovora);
                    }
                    else MessageBox.Show("Запрос на изменение роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void Click_Cancel_Companies_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_Companies_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.connection.LoadData(ClassConnection.Connection.Tables.dogovora);
                string query = "Delete From companies Where [Id_companies] = " + dogovora.id.ToString() + "";
                var query_apply = Login.connection.Query(query);
                if (query_apply != null)
                {
                    Login.connection.LoadData(ClassConnection.Connection.Tables.dogovora);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.dogovora);
                }
                else MessageBox.Show("Запрос на удаление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex(@"^[А-Яа-яA-Za-z0-9\s]*$");
        //    if (!regex.IsMatch(e.Text))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    string[] words = textBox.Text.Split(' ');
        //    if (words.Any(word => word.Length == 0))
        //    {
        //        textBox.Text = "Ошибка: введите значение";
        //        Name_companies.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
        //    }
        //}

        //private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    if (textBox.Text.StartsWith("Ошибка:"))
        //    {
        //        textBox.Text = "";
        //        ColorAnimation animation = new ColorAnimation();
        //        animation.From = (Color)ColorConverter.ConvertFromString("#FB3F51");
        //        animation.To = Colors.Transparent;
        //        animation.Duration = new Duration(TimeSpan.FromSeconds(2));
        //        SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
        //        brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        //        Name_companies.BorderBrush = brush;
        //    }
        //}

        //private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex(@"^[А-Яа-яA-Za-z\s]*$");
        //    if (!regex.IsMatch(e.Text))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    string[] words = textBox.Text.Split(' ');
        //    if (words.Length != 3 || words.Any(word => word.Length == 0))
        //    {
        //        textBox.Text = "Ошибка: введите ровно три слова";
        //        Commander.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
        //    }
        //}

        //private void TextBox_GotFocus_2(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = (TextBox)sender;
        //    if (textBox.Text.StartsWith("Ошибка:"))
        //    {
        //        textBox.Text = "";
        //        ColorAnimation animation = new ColorAnimation();
        //        animation.From = (Color)ColorConverter.ConvertFromString("#FB3F51");
        //        animation.To = Colors.Transparent;
        //        animation.Duration = new Duration(TimeSpan.FromSeconds(2));
        //        SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
        //        brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        //        Commander.BorderBrush = brush;
        //    }
        //}
    }
}
