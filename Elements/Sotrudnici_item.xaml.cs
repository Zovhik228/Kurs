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
    /// Логика взаимодействия для Sotrudnici_item.xaml
    /// </summary>
    public partial class Sotrudnici_item : UserControl
    {
        Connection connection;
        ClassModules.Sotrudnici sotrudnici;
        public Sotrudnici_item(ClassModules.Sotrudnici _sotrudnici)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (Pages.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            sotrudnici = _sotrudnici;
            if (_sotrudnici.Date_birth != null)
            {
                Id_sotrudnic.Content = "Путевка №" + _sotrudnici.id.ToString();
                Job_title.Content = "Тип деятельности: " + _sotrudnici.Job_title;
                Departament_number.Content = "Страна: " + _sotrudnici.Deparatament_number;
                Floor.Content = "Город: " + _sotrudnici.floor;
                Address.Content = "Адрес: " + _sotrudnici.Address;
                Date_birth.Content = "ФИО директора: " + _sotrudnici.Date_birth;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
    }
}
