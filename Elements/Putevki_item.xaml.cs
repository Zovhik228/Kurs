using ClassConnection;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Elements
{
    /// <summary>
    /// Логика взаимодействия для Putevki_item.xaml
    /// </summary>
    public partial class Putevki_item : UserControl
    {
        Connection connection;
        ClassModules.Putevki putevki;
        public Putevki_item(ClassModules.Putevki _putevki)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (Pages.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            putevki = _putevki;
            if (_putevki.Country != null)
            {
                Id_putevka.Content = "Путевка №" + _putevki.id.ToString();
                Type_of_activity.Content = "Тип деятельности: " + _putevki.Type_of_activity;
                Country.Content = "Страна: " + _putevki.Country;
                City.Content = "Город: " + _putevki.City;
                Address.Content = "Адрес: " + _putevki.Adress;
                FIO_Director.Content = "ФИО директора: " + _putevki.FIO_Director;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
    }
}
