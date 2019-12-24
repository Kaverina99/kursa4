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
    public class OtchetAgencyVM : INotifyPropertyChanged
    {
        AgencyDB db;
        public OtchetAgencyVM()
        {
            db = new AgencyDB();
            otchet1s = new ObservableCollection<Otchet1>();
        }
        public class Otchet1
        {
            public int Id_Deal { get; set; }
            public DateTime Deal_Date { get; set; }
            public string Pr_Address { get; set; }
            public string Client_Name { get; set; }
            public string Agent_Name { get; set; }
            public decimal Deal_Total_Cost { get; set; }

        }
        DateTime DatePicker1 { get; set; }
        public DateTime datePicker1
        {
            get { return DatePicker1; }
            set
            {
                DatePicker1 = value;
                OnPropertyChanged("datePicker1");
            }
        }

        DateTime DatePicker2 { get; set; }
        public DateTime datePicker2
        {
            get { return DatePicker2; }
            set
            {
                DatePicker2 = value;
                OnPropertyChanged("datePicker2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<Otchet1> otchet1s { get; set; }

        private RelayCommand otchet1Command;
        public RelayCommand Otchet1Command
        {
            get
            {
               return otchet1Command ??
                  (otchet1Command = new RelayCommand(obj =>
                  {
                      SqlParameter param1 = new SqlParameter("@DATE1", DatePicker1);
                      SqlParameter param2 = new SqlParameter("@DATE2", DatePicker2);
                      
                      List<Otchet1> sPs = db.Database.SqlQuery<Otchet1>("Otchet1 @DATE1,@DATE2", new object[] { param1, param2 }).ToList();
                      otchet1s.Clear();
                     foreach(Otchet1 otchet in sPs)
                      {
                          otchet1s.Add(otchet);
                      }
                  }));
            }
        }

        

    }
}
