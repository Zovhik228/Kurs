using ClassConnection;
using ClassModules;
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
    /// Логика взаимодействия для Otdeli_item.xaml
    /// </summary>
    public partial class Otdeli_item : UserControl
    {
        Connection connection;
        ClassModules.Otdeli otedeli;
        public Otdeli_item(ClassModules.Otdeli _otedeli)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (Pages.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            otedeli = _otedeli;
            if (_otedeli.Floor != null)
            {
                Id_otdel.Content = "Договор №" + _otedeli.id.ToString();
                Floor.Content = "Этаж: " + _otedeli.Floor;
                Phone.Content = "Телефон: " + _otedeli.Telephine;
                Departament_head.Content = "Начальник отдела: " + _otedeli.Departament_head;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
    }
}
