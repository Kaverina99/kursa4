using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Agency;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WpfApp1.ViewModels
{
    public class PropertyVM : INotifyPropertyChanged
    {
        private Property selectedProperty;

        public ObservableCollection<Property> Propertys { get; set; }
        public Property SelectedProperty
        {
            get { return selectedProperty; }
            set
            {
                selectedProperty = value;
                OnPropertyChanged("SelectedProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Property property = new Property();

                      PropertyWindow pr = new PropertyWindow(ClassWorkDB);
                      bool? res = pr.ShowDialog();

                      Propertys.Clear();
                      foreach (Property prop in ClassWorkDB.Property)
                      {
                          Propertys.Add(prop);
                      }
                      selectedProperty = property;

                  }));
            }
        }

        // команда изменеия 
        private RelayCommand upDateCommand;
        public RelayCommand UpDateCommand
        {
            get
            {
                return upDateCommand ??
                  (upDateCommand = new RelayCommand(obj =>
                  {
                      Property property = new Property();

                      PropertyWindow cl = new PropertyWindow(ClassWorkDB, SelectedProperty);
                      bool? res = cl.ShowDialog();

                      Propertys.Clear();
                      foreach (Property proper in ClassWorkDB.Property)
                      {
                          Propertys.Add(proper);
                      }
                      selectedProperty = property;

                  }));
            }
        }


        private RelayCommand poiskCommand;
        public RelayCommand PoiskCommand
        {
            get
            {
                return poiskCommand ??
                  (poiskCommand = new RelayCommand(obj =>
                  {
                      Property property = new Property();

                      PoiskPropertyWindow pr = new PoiskPropertyWindow(ClassWorkDB);
                      bool? res = pr.ShowDialog();

                      Propertys.Clear();
                      foreach (Property prop in ClassWorkDB.Property)
                      {
                          Propertys.Add(prop);
                      }
                      selectedProperty = property;
                  }));
            }
        }


        AgencyDB ClassWorkDB;

        public PropertyVM()
        {
            ClassWorkDB = new AgencyDB();
            Propertys = new ObservableCollection<Property>(ClassWorkDB.Property.ToList());


        }
    }
}
