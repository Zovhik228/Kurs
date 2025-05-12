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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages.AddPages
{
    public partial class Proecti : Page
    {
        ClassModules.Proecti proecti;
        public Proecti(ClassModules.Proecti _proecti)
        {
            InitializeComponent();
            proecti = _proecti;
            if (_proecti.Departament != null)
            {
                Date_nach.Text = _proecti.Date_nach.ToString("dd-MM-yyyy");
                date_kon.Text = _proecti.Date_end.ToString("dd-MM-yyyy");
                Number_dogovor.Text = _proecti.Number_dogovor.ToString();
                Organization.Text = _proecti.Departament;
            }
        }
        private void Click_Companies_Redact(object sender, RoutedEventArgs e)
        {
            int id = Login.connection.SetLastId(ClassConnection.Connection.Tables.proecti);
            if (proecti.Departament == null)
            {
                string query = $"INSERT INTO companies ([Id_companies], [Name_companies], [Commander], [Date_foundation], [Date_update_information]) VALUES ({id.ToString()}, N'{Name_companies.Text}', N'{Commander.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                var query_apply = Login.connection.Query(query);
                if (query_apply != null)
                {
                    Login.connection.LoadData(ClassConnection.Connection.Tables.proecti);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.proecti);
                }
                else MessageBox.Show("Запрос на добавление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"UPDATE companies SET Name_companies = N'{Name_companies.Text}', Commander = N'{Commander.Text}', Date_update_information = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE Id_companies = {companies.Id_companies}";
                var query_apply = Login.connection.Query(query);
                if (query_apply != null)
                {
                    Login.connection.LoadData(ClassConnection.Connection.Tables.proecti);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.proecti);
                }
                else MessageBox.Show("Запрос на изменение роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Click_Cancel_Companies_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_Companies_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.connection.LoadData(ClassConnection.Connection.Tables.proecti);
                string query = "Delete From companies Where [Id_companies] = " + proecti.id.ToString() + "";
                var query_apply = Login.connection.Query(query);
                if (query_apply != null)
                {
                    Login.connection.LoadData(ClassConnection.Connection.Tables.proecti);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.proecti);
                }
                else MessageBox.Show("Запрос на удаление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
