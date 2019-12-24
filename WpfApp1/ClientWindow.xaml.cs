using DAL;
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
using WpfApp1.ViewModels;
using WpfApp1.ViewsModels;

namespace Agency
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow(AgencyDB context)
        {
            InitializeComponent();
            DataContext = new NewClientVM(context, this);
        }

        public ClientWindow(AgencyDB context, Client cli )
        {
            InitializeComponent();
            DataContext = new NewClientVM(context, this, cli);
        }
    }
}
