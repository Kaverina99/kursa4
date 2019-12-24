using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL;
using WpfApp1.ViewModels;
using Agency;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewsModels
{

    public class NewPropertyVM : INotifyPropertyChanged
    {
        AgencyDB db;
        PropertyWindow win;
        public NewPropertyVM(AgencyDB context, PropertyWindow w)
        {
            win = w;
            db = context;
            Cl = new ObservableCollection<Client>(db.Client);
            Tip = new ObservableCollection<Type_of_Property>(db.Type_of_Property);
            Tar = new ObservableCollection<Target>(db.Target);
            Ar = new ObservableCollection<Area>(db.Area);
            Bat = new ObservableCollection<Bathroom>(db.Bathroom);
            Lay = new ObservableCollection<Layout>(db.Layout);
            Mat = new ObservableCollection<Material>(db.Material);
        }


        decimal Pr_Cost;
        string Pr_Address;
        decimal? Pr_Metric_area;
        string Pr_Floor;
        decimal? Pr_Plot_size;
        int Pr_Number_of_rooms;

        

        public decimal prCost
        {
            get { return Pr_Cost; }
            set
            {
                Pr_Cost = value;
                OnPropertyChanged("Pr_Cost");
            }
        }

        public string prAddress
        {
            get { return Pr_Address; }
            set
            {
                Pr_Address = value;
                OnPropertyChanged("Pr_Address");
            }
        }
        public decimal? prMetric_area
        {
            get { return Pr_Metric_area; }
            set
            {
                Pr_Metric_area = value;
                OnPropertyChanged("Pr_Metric_area");
            }
        }
        public string prFloor
        {
            get { return Pr_Floor; }
            set
            {
                Pr_Floor = value;
                OnPropertyChanged("Pr_Floor");
            }
        }
        public decimal? prPlot_size
        {
            get { return Pr_Plot_size; }
            set
            {
                Pr_Plot_size = value;
                OnPropertyChanged("Pr_Plot_size");
            }
        }
        public int prNumber_of_rooms
        {
            get { return Pr_Number_of_rooms; }
            set
            {
                Pr_Number_of_rooms = value;
                OnPropertyChanged("Pr_Number_of_rooms");
            }
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

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Property property = new Property();
                      property.Id_Property = 1;
                      property.Pr_Cost = prCost;
                      property.Pr_Address = prAddress;
                      property.Pr_Metric_area = prMetric_area;
                      property.Pr_Floor = prFloor;
                      property.Pr_Plot_size = prPlot_size;
                      property.Pr_Number_of_rooms = prNumber_of_rooms;

                      property.Pr_Client_FK = selectCl.Id_Client;
                      property.Pr_TypeP_FK = selectTip.Id_Type;
                      property.Pr_Target_FK = selectTar.Id_Target;
                      property.Pr_Area_FK = selectAr.Id_Area;
                      property.Pr_Bathroom_FK = selectBat.Id_Bathroom;
                      property.Pr_Layout_FK = selectLay.Id_Layout;
                      property.Pr_Material_FK = selectMat.Id_Material;

                      db.Property.Add(property);
                      db.SaveChanges();
                      win.Close();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

