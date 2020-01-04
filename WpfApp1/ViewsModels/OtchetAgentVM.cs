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
    public class OtchetAgentVM : INotifyPropertyChanged
    {

        public ObservableCollection<Agent> Agents { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public ObservableCollection<Agent> Agg { get; set; }
        Agent selectAgg;
        public Agent SelectAgg

        {
            get { return selectAgg; }
            set
            {
                selectAgg = value;
                OnPropertyChanged("SelectPAgg");
            }
        }

        AgencyDB db;

        public OtchetAgentVM()
        {
            db = new AgencyDB();
            Agents = new ObservableCollection<Agent>(db.Agent.ToList());

            Agg = new ObservableCollection<Agent>(db.Agent);
            otchet2s = new ObservableCollection<Otchet2>();
        }

        public class Otchet2
        {
            public int Id_Deal { get; set; }
            public DateTime Deal_Date { get; set; }
            public string Pr_Address { get; set; }
            public string Client_Name { get; set; }
            public string Client_Phone { get; set; }
            public decimal Deal_Total_Cost { get; set; }
            public decimal Deal_AgentShare_Cost { get; set; }
            public decimal TotalCostAgency { get; set; }

        }

        DateTime DateAgent1 { get; set; }
        public DateTime dateAgent1
        {
            get { return DateAgent1; }
            set
            {
                DateAgent1 = value;
                OnPropertyChanged("dateAgent1");
            }
        }

        DateTime DateAgent2 { get; set; }
        public DateTime dateAgent2
        {
            get { return DateAgent2; }
            set
            {
                DateAgent2 = value;
                OnPropertyChanged("dateAgent2");
            }
        }

        int ComboBoxAgName { get; set; }
        public int comboBoxAgName
        {
            get { return ComboBoxAgName; }
            set
            {
                ComboBoxAgName = value;
                OnPropertyChanged("comboBoxAgName");
            }
        }

        public ObservableCollection<Otchet2> otchet2s { get; set; }

        private RelayCommand otchet2Command;
        public RelayCommand Otchet2Command
        {
            get
            {
                return otchet2Command ??
                   (otchet2Command = new RelayCommand(obj =>
                   {
                       SqlParameter param1 = new SqlParameter("@DATE1", dateAgent1);
                       SqlParameter param2 = new SqlParameter("@DATE2", dateAgent2);
                       SqlParameter param3 = new SqlParameter("@Agent", comboBoxAgName);

                       List<Otchet2> sPs = db.Database.SqlQuery<Otchet2>("Otchet2 @DATE1,@DATE2,@Agent", new object[] { param1, param2, param3 }).ToList();
                       otchet2s.Clear();
                       foreach (Otchet2 otchet in sPs)
                       {
                           otchet2s.Add(otchet);
                       }
                   }));
            }
        }


    }
}
