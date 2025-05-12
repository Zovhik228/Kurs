using ClassConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Proecti_item.xaml
    /// </summary>
    public partial class Proecti_item : UserControl
    {
        Connection connection;
        ClassModules.Proecti proecti;
        public Proecti_item(ClassModules.Proecti _proecti)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (Pages.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            proecti = _proecti;
            if (_proecti.Date_nach != null)
            {
                Id_proect.Content = "Договор №" + _proecti.id.ToString();
                Date_nach.Content = "Этаж: " + _proecti.Date_nach;
                Date_end.Content = "Телефон: " + _proecti.Date_end;
                Dogovor_number.Content = "Начальник отдела: " + _proecti.Number_dogovor;
                Departament.Content = "Начальник отдела: " + _proecti.Departament;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
    }
}
