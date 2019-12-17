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

namespace Agency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow f = new ClientWindow();
            f.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientWindow f = new ClientWindow();
            f.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PropertyWindow f = new PropertyWindow();
            f.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PropertyWindow f = new PropertyWindow();
            f.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DealWindow f = new DealWindow();
            f.Show();
        }

        private void MenuSpravka_Click(object sender, RoutedEventArgs e)
        {
            ReferenceWindow f = new ReferenceWindow();
            f.Show();
        }

    }
}
