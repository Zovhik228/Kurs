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
using System.Xml.Linq;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public enum page_main
        {
            dogovora, otdeli, proecti, putevki, sotrudnici, users, none
        }

        public static page_main page_select;
        public static Main main;

        public Main()
        {
            InitializeComponent();
            main = this;
            page_select = page_main.none;
        }

        public void CreateConnect(bool connectApply)
        {
            if (connectApply == true)
            {
                Login.connection.LoadData(Connection.Tables.dogovora);
                Login.connection.LoadData(Connection.Tables.otdeli);
                Login.connection.LoadData(Connection.Tables.proecti);
                Login.connection.LoadData(Connection.Tables.putevki);
                Login.connection.LoadData(Connection.Tables.sotrudnici);
            }
        }

        public void RoleUser()
        {
            if (Login.UserInfo[1] == "admin") WhoAmI.Content = $"Здравствуйте, {Login.UserInfo[0]}! Роль - {Login.UserInfo[1]}";
            else WhoAmI.Content = $"Здравствуйте, {Login.UserInfo[0]}! Роль - {Login.UserInfo[1]}";
        }

        public void OpenPageLogin()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                MainWindow.init.frame.Navigate(new Login());
                DoubleAnimation opgrisdAnimation = new DoubleAnimation();
                opgrisdAnimation.From = 0;
                opgrisdAnimation.To = 1;
                opgrisdAnimation.Duration = TimeSpan.FromSeconds(1.2);
                MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgrisdAnimation);
            };
            MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }

        private void LoadDogovora()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Dogovora dogovora_items in ClassConnection.Connection.dogovoras)
                {
                    if (page_select == page_main.dogovora)
                    {
                        parrent.Children.Add(new Elements.Dogovora_item(dogovora_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.dogovora)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Parts(new ClassModules.Dogovora());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Dogovora(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.dogovora)
            {
                page_select = page_main.dogovora;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadDogovora();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadOtdeli()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Otdeli otdeli_items in ClassConnection.Connection.otdelis)
                {
                    if (page_select == page_main.otdeli)
                    {
                        parrent.Children.Add(new Elements.Otdeli_item(otdeli_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.otdeli)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Locations(new ClassModules.Otdeli());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Otdeli(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.otdeli)
            {
                page_select = page_main.otdeli;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadOtdeli();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadProecti()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Proecti proecti_items in ClassConnection.Connection.proectis)
                {
                    if (page_select == page_main.proecti)
                    {
                        parrent.Children.Add(new Elements.Proecti_item(proecti_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.proecti)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Companies(new ClassModules.Proecti());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Proecti(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.proecti)
            {
                page_select = page_main.proecti;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadProecti();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadPutevki()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Putevki putevki_items in ClassConnection.Connection.putevkis)
                {
                    if (page_select == page_main.putevki)
                    {
                        parrent.Children.Add(new Elements.Putevki_item(putevki_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.putevki)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Technique(new ClassModules.Putevki());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Putevki(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.putevki)
            {
                page_select = page_main.putevki;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadPutevki();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadSotrudniki()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Sotrudnici sotrudnici_items in ClassConnection.Connection.sotrudnicis)
                {
                    if (page_select == page_main.sotrudnici)
                    {
                        parrent.Children.Add(new Elements.Sotrudnici_item(sotrudnici_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.sotrudnici)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Type_of_troops(new ClassModules.Sotrudnici());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Sotrudniki(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.sotrudnici)
            {
                page_select = page_main.sotrudnici;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadSotrudniki();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_Export(object sender, MouseButtonEventArgs e)
        {
            Search.IsEnabled = false;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            parrent.Children.Clear();
            page_select = page_main.none;
            var export = new ExportWindow();
            export.ShowDialog();
        }

        private bool isDataLoaded = false;

        private async void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Search.Text) && Search.Text != "Поиск")
            {
                await Task.Delay(100);
                if (page_select == page_main.dogovora)
                {
                    parrent.Children.Clear();
                    var dogovora = Connection.dogovoras.FindAll(x => x.id.ToString() == Search.Text);
                    foreach (var itemSearch in dogovora) parrent.Children.Add(new Elements.Dogovora_item(itemSearch));
                }
                else if (page_select == page_main.proecti)
                {
                    parrent.Children.Clear();
                    var companiesById = Connection.proectis.FindAll(x => x.id.ToString().Contains(Search.Text));
                    foreach (var itemSearch in companiesById) parrent.Children.Add(new Elements.Proecti_item(itemSearch));
                }
                else if (page_select == page_main.putevki)
                {
                    parrent.Children.Clear();
                    var techniqueByName = Connection.putevkis.FindAll(x => x.Type_of_activity.Contains(Search.Text));
                    foreach (var itemSearch in techniqueByName) parrent.Children.Add(new Elements.Putevki_item(itemSearch));
                }
                else if (page_select == page_main.sotrudnici)
                {
                    parrent.Children.Clear();
                    var typeOfTroopByName = Connection.sotrudnicis.FindAll(x => x.Job_title.Contains(Search.Text));
                    foreach (var itemSearch in typeOfTroopByName) parrent.Children.Add(new Elements.Sotrudnici_item(itemSearch));
                }
            }
            else
            {
                await Task.Delay(100);
                if (string.IsNullOrWhiteSpace(Search.Text))
                {
                    parrent.Children.Clear();
                    return;
                }
                if (!isDataLoaded || Search.Text == "Поиск")
                {
                    if (page_select == page_main.dogovora)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadDogovora();
                    }
                    else if (page_select == page_main.otdeli)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadOtdeli();
                    }
                    else if (page_select == page_main.proecti)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadProecti();
                    }
                    else if (page_select == page_main.putevki)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadPutevki();
                    }
                    else if (page_select == page_main.sotrudnici)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadSotrudniki();
                    }
                    isDataLoaded = true;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) => Search.Text = "Поиск";

        private void TextBox_GotFocus(object sender, RoutedEventArgs e) => Search.Text = "";

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = false;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            parrent.Children.Clear();
            page_select = page_main.none;
            Login.UserInfo[0] = ""; Login.UserInfo[1] = "";
            OpenPageLogin();
        }

        public void Animation_move(Control control1, Control control2, Frame frame_main = null, Page pages = null, page_main page_restart = page_main.none)
        {
            if (page_restart != page_main.none)
            {
                if (page_restart == page_main.dogovora)
                {
                    page_select = page_main.none;
                    Click_Dogovora(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.otdeli)
                {
                    page_select = page_main.none;
                    Click_Otdeli(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.proecti)
                {
                    page_select = page_main.none;
                    Click_Proecti(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.putevki)
                {
                    page_select = page_main.none;
                    Click_Putevki(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.sotrudnici)
                {
                    page_select = page_main.none;
                    Click_Sotrudniki(new object(), new RoutedEventArgs());
                }
            }
            else
            {
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.3);
                opgridAnimation.Completed += delegate
                {
                    if (pages != null)
                    {
                        frame_main.Navigate(pages);
                    }
                    control1.Visibility = Visibility.Hidden;
                    control2.Visibility = Visibility.Visible;
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    control2.BeginAnimation(ScrollViewer.OpacityProperty, opgriAnimation);
                };
                control1.BeginAnimation(ScrollViewer.OpacityProperty, opgridAnimation);
            }
        }
    }
}
