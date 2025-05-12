using ClassConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для Dogovora_item.xaml
    /// </summary>
    public partial class Dogovora_item : UserControl
    {
        Connection connection;
        ClassModules.Dogovora dogovora;
        public Dogovora_item(ClassModules.Dogovora _dogovora)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (Pages.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            dogovora = _dogovora;
            if (_dogovora.Organization != null)
            {
                Id_dogovor.Content = "Договор №" + _dogovora.id.ToString();
                Date_zakl.Content = "Дата заключения: " + _dogovora.Date;
                Organization.Content = "Организация: " + _dogovora.Organization;
                Contract_cost.Content = "Стоимость договора: " + _dogovora.Contract_cost;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
    }
}
