using WpfApp1.ViewModels;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClientsTab.DataContext = new ClientVM();
            DealsTab.DataContext = new DealVM();
            PropertyTab.DataContext = new PropertyVM();
            DocumentTab.DataContext = new DocumentVM();
            OtchetAgencyTab.DataContext = new OtchetAgencyVM();
            OtchetAgentTab.DataContext = new OtchetAgentVM();
        }

    }
}
