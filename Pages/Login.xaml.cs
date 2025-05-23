﻿using ClassConnection;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Connection connection;
        public static string[] UserInfo = new string[2];

        public Login()
        {
            InitializeComponent();
            connection = new Connection();
            Connection.Connect();
            if (Connection.ConnectIsTrue == false) MainWindow.init.Close();
            MessageBox.Show(Connection.ConnectIsTrue.ToString());
        }

        private void login_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_incorrect.Visibility = Visibility.Hidden;
            login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        private void password_user_TextChanged(object sender, RoutedEventArgs e)
        {
            password_incorrect.Visibility = Visibility.Hidden;
            password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
            login_incorrect.Visibility = Visibility.Hidden;
            login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        public void Login_to_Main()
        {
            login_incorrect.Content = "Логин не верный";
            login_incorrect.Visibility = Visibility.Hidden;
            password_incorrect.Content = "Пароль не верный";
            if (login_user.Text == "")
            {
                login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                login_incorrect.Content = "Введите логин";
                login_incorrect.Visibility = Visibility.Visible;
                return;
            }
            if (password_user.Password == "")
            {
                password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                password_incorrect.Content = "Введите пароль";
                password_incorrect.Visibility = Visibility.Visible;
                return;
            }
            connection.LoadData(ClassConnection.Connection.Tables.users);
            var info = ClassConnection.Connection.users.Find(x => x.Login == login_user.Text && x.Password == password_user.Password);
            if (info != null)
            {
                UserInfo[0] = login_user.Text;
                UserInfo[1] = info.Role;
                MainWindow.init.OpenPageMain();
                Main.main.RoleUser();
                Main.main.CreateConnect(true);
                return;
            }
            else
            {
                login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                login_incorrect.Visibility = Visibility.Visible;
                password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                password_incorrect.Visibility = Visibility.Visible;
                return;
            }
        }

        private void Login_Click(object sender, MouseButtonEventArgs e) => Login_to_Main();

        private void Login_Click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Login_to_Main();
            if (e.Key == Key.Escape) MainWindow.init.Close();
        }
    }
}
