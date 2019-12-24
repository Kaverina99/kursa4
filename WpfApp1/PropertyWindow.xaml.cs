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
using DAL;
using WpfApp1.ViewsModels;

namespace Agency
{
    /// <summary>
    /// Логика взаимодействия для PropertyWindow.xaml
    /// </summary>
    public partial class PropertyWindow : Window
    {
        public PropertyWindow(AgencyDB context)
        {
            InitializeComponent();
            DataContext = new NewPropertyVM(context, this);
        }
    }
}
