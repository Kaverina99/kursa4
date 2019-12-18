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

        private void ButtonCreateClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow f = new ClientWindow();
            f.Show();
        }

        private void ButtonUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow f = new ClientWindow();
            f.Show();
        }

        private void ButtonCreatePoperty_Click(object sender, RoutedEventArgs e)
        {
            PropertyWindow f = new PropertyWindow();
            f.Show();
        }

        private void ButtonUpdateProperty_Click(object sender, RoutedEventArgs e)
        {
            PropertyWindow f = new PropertyWindow();
            f.Show();
        }

        private void ButtonDeal_Click(object sender, RoutedEventArgs e)
        {
            DealWindow f = new DealWindow();
            f.Show();
        }

        private void MenuItemSpravka_Click(object sender, RoutedEventArgs e)
        {
            ReferenceWindow f = new ReferenceWindow();
            f.Show();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
