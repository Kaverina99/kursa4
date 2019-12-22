using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using DAL.Interfaces;
using Agency;

namespace WpfApp1.ViewModels
{
    public class PropertyVM : INotifyPropertyChanged
    {

        private PropertyModel selectedProperty;

        public ObservableCollection<PropertyModel> Property { get; set; }
        public PropertyModel SelectedProperty
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
                      PropertyModel pr = new PropertyModel();

                      PropertyWindow p = new PropertyWindow(pr);
                      bool? res = p.ShowDialog();
                      if (res != null && (bool)res)
                      {
                          Property.Insert(0, pr);
                          selectedProperty = pr;
                      }
                  }));
            }
        }
        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      PropertyModel property = obj as PropertyModel;
                      if (property != null)
                      {
                          Property.Remove(property);
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (Property.Count > 0 && selectedProperty != null)));
            }
        }


        public PropertyVM()
        {
            DBDataOperation ClassWorkDB = new DBDataOperation();
            Property = new ObservableCollection<PropertyModel>(ClassWorkDB.GetAllProperties());


        }

    }
}
