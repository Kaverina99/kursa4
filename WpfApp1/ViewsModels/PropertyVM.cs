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

       

        public ObservableCollection<Client> Cl { get; set; }
        Client selectCl;
        public Client SelectCl

        {
            get { return selectCl; }
            set
            {
                selectCl = value;
                OnPropertyChanged("SelectCl");
            }
        }

        public ObservableCollection<Type_of_Property> Tip { get; set; }
        Type_of_Property selectTip;
        public Type_of_Property SelectTip

        {
            get { return selectTip; }
            set
            {
                selectTip = value;
                OnPropertyChanged("SelectTip");
            }
        }

        public ObservableCollection<Target> Tar { get; set; }
        Target selectTar;
        public Target SelectTar

        {
            get { return selectTar; }
            set
            {
                selectTar = value;
                OnPropertyChanged("SelectTar");
            }
        }

        public ObservableCollection<Area> Ar { get; set; }
        Area selectAr;
        public Area SelectAr

        {
            get { return selectAr; }
            set
            {
                selectAr = value;
                OnPropertyChanged("SelectAr");
            }
        }

        public ObservableCollection<Bathroom> Bat { get; set; }
        Bathroom selectBat;
        public Bathroom SelectBat

        {
            get { return selectBat; }
            set
            {
                selectBat = value;
                OnPropertyChanged("SelectBat");
            }
        }

        public ObservableCollection<Layout> Lay { get; set; }
        Layout selectLay;
        public Layout SelectLay

        {
            get { return selectLay; }
            set
            {
                selectLay = value;
                OnPropertyChanged("SelectLay");
            }
        }

        public ObservableCollection<Material> Mat { get; set; }
        Material selectMat;
        public Material SelectMat

        {
            get { return selectMat; }
            set
            {
                selectMat = value;
                OnPropertyChanged("SelectMat");
            }
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

        AgencyDB ClassWorkDB;

        public PropertyVM()
        {
            ClassWorkDB = new AgencyDB();
            Propertys = new ObservableCollection<Property>(ClassWorkDB.Property.ToList());

            Tip = new ObservableCollection<Type_of_Property>(ClassWorkDB.Type_of_Property);
            Tar = new ObservableCollection<Target>(ClassWorkDB.Target);
            Ar = new ObservableCollection<Area>(ClassWorkDB.Area);
            Bat = new ObservableCollection<Bathroom>(ClassWorkDB.Bathroom);
            Lay = new ObservableCollection<Layout>(ClassWorkDB.Layout);
            Mat = new ObservableCollection<Material>(ClassWorkDB.Material);

        }
    }
}
