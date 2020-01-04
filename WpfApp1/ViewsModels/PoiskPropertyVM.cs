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
    public class PoiskPropertyVM : INotifyPropertyChanged
    {
        AgencyDB db;
        public ObservableCollection<Property> Propertys { get; set; }

        public PoiskPropertyVM()
        {
            db = new AgencyDB();
            Propertys = new ObservableCollection<Property>(db.Property.ToList());

            poisks = new ObservableCollection<Poisk>();

            Tip = new ObservableCollection<Type_of_Property>(db.Type_of_Property);
            Tar = new ObservableCollection<Target>(db.Target);
            Ar = new ObservableCollection<Area>(db.Area);
            Bat = new ObservableCollection<Bathroom>(db.Bathroom);
            Lay = new ObservableCollection<Layout>(db.Layout);
            Mat = new ObservableCollection<Material>(db.Material);
        }

        public class Poisk
        {
            public int Id_Property { get; set; }
            public decimal Pr_Cost { get; set; }
            public string Pr_Address { get; set; }
            public decimal? Pr_Metric_area { get; set; }
            public string Pr_Floor { get; set; }
            public decimal? Pr_Plot_size { get; set; }
            public int Pr_Number_of_rooms { get; set; }

            public string Client_Name { get; set; }
            public string TypeP_Name { get; set; }
            public string Target_Name { get; set; }
            public string Area_Name { get; set; }
            public string Bathroom_Name { get; set; }
            public string Layout_Name { get; set; }
            public string Material_Name { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        int ComboBoxPropertyType { get; set; }
        public int comboBoxPropertyType
        {
            get { return ComboBoxPropertyType; }
            set
            {
                ComboBoxPropertyType = value;
                OnPropertyChanged("comboBoxPropertyType");
            }
        }
        int ComboBoxPropertyTarget { get; set; }
        public int comboBoxPropertyTarget
        {
            get { return ComboBoxPropertyTarget; }
            set
            {
                ComboBoxPropertyTarget = value;
                OnPropertyChanged("comboBoxPropertyTarget");
            }
        }
        int ComboBoxPropertyPlan { get; set; }
        public int comboBoxPropertyPlan
        {
            get { return ComboBoxPropertyPlan; }
            set
            {
                ComboBoxPropertyPlan = value;
                OnPropertyChanged("comboBoxPropertyPlan");
            }
        }
        int ComboBoxPropertyMater { get; set; }
        public int comboBoxPropertyMater
        {
            get { return ComboBoxPropertyMater; }
            set
            {
                ComboBoxPropertyMater = value;
                OnPropertyChanged("comboBoxPropertyMater");
            }
        }
        int ComboBoxPropertyRaion { get; set; }
        public int comboBoxPropertyRaion
        {
            get { return ComboBoxPropertyRaion; }
            set
            {
                ComboBoxPropertyRaion = value;
                OnPropertyChanged("comboBoxPropertyRaion");
            }
        }
        int ComboBoxPropertyBat { get; set; }
        public int comboBoxPropertyBat
        {
            get { return ComboBoxPropertyBat; }
            set
            {
                ComboBoxPropertyBat = value;
                OnPropertyChanged("comboBoxPropertyBat");
            }
        }
        public ObservableCollection<Poisk> poisks { get; set; }

        private RelayCommand poiskCommand;
        public RelayCommand PoiskCommand
        {
            get
            {
                return poiskCommand ??
                   (poiskCommand = new RelayCommand(obj =>
                   {
                       SqlParameter param1 = new SqlParameter("@Tip", comboBoxPropertyType);
                       SqlParameter param2 = new SqlParameter("@Target", comboBoxPropertyTarget);
                       SqlParameter param3 = new SqlParameter("@Layy", comboBoxPropertyPlan);
                       SqlParameter param4 = new SqlParameter("@Matt", comboBoxPropertyMater);
                       SqlParameter param5 = new SqlParameter("@Area", comboBoxPropertyRaion);
                       SqlParameter param6 = new SqlParameter("@Bath", comboBoxPropertyBat);

                       List<Poisk> sPs = db.Database.SqlQuery<Poisk>("Poisk @Tip,@Target, @Layy, @Matt, @Area, @Bath", new object[] { param1, param2, param3, param4, param5, param6 }).ToList();
                       poisks.Clear();
                       foreach (Poisk poi in sPs)
                       {
                           poisks.Add(poi);
                       }
                   }));
            }
        }



    }
}
