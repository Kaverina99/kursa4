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

    public class NewDealVM : INotifyPropertyChanged
    {
        AgencyDB db;
        DealWindow win;
        public NewDealVM(AgencyDB context, DealWindow w)
        {
            win = w;
            db = context;
            Cli1 = new ObservableCollection<Client>(db.Client);
            Cli2 = new ObservableCollection<Client>(db.Client);
            Pro = new ObservableCollection<Property>(db.Property);
            Age = new ObservableCollection<Agent>(db.Agent);
        }

        DateTime Deal_Date;
        string Deal_Form_of_Payment;
        string Deal_Mortgage_Period;
        string Deal_Monthly_Payout;
        decimal Deal_Total_Cost;
        decimal Deal_AgentShare_Cost;


        public DateTime dlDate
        {
            get { return Deal_Date; }
            set
            {
                Deal_Date = value;
                OnPropertyChanged("Deal_Date");
            }
        }

        public string dlFPayment
        {
            get { return Deal_Form_of_Payment; }
            set
            {
                Deal_Form_of_Payment = value;
                OnPropertyChanged("Deal_Form_of_Payment");
            }
        }
        public string dlPeriod
        {
            get { return Deal_Mortgage_Period; }
            set
            {
                Deal_Mortgage_Period = value;
                OnPropertyChanged("Deal_Mortgage_Period");
            }
        }
        public string dlMPayout
        {
            get { return Deal_Monthly_Payout; }
            set
            {
                Deal_Monthly_Payout = value;
                OnPropertyChanged("Deal_Monthly_Payout");
            }
        }
        public decimal dlTotalCost
        {
            get { return Deal_Total_Cost; }
            set
            {
                Deal_Total_Cost = value;
                OnPropertyChanged("Deal_Total_Cost");
            }
        }
        
        public decimal dlAgentShareCost
        {
            get { return Deal_AgentShare_Cost; }
            set
            {
                Deal_AgentShare_Cost = value;
                OnPropertyChanged("Deal_AgentShare_Cost");
            }
        }

        public ObservableCollection<Client> Cli1 { get; set; }
        Client selectCli1;
        public Client SelectCli1
        {
            get { return selectCli1; }
            set
            {
                selectCli1 = value;
                OnPropertyChanged("SelectCli1");
            }
        }

        public ObservableCollection<Client> Cli2 { get; set; }
        Client selectCli2;
        public Client SelectCli2
        {
            get { return selectCli2; }
            set
            {
                selectCli2 = value;
                OnPropertyChanged("SelectCli2");
            }
        }

        public ObservableCollection<Property> Pro { get; set; }
        Property selectPro;
        public Property SelectPro
        {
            get { return selectPro; }
            set
            {
                selectPro = value;
                OnPropertyChanged("SelectPro");
            }
        }

        public ObservableCollection<Agent> Age { get; set; }
        Agent selectAge;
        public Agent SelectAge
        {
            get { return selectAge; }
            set
            {
                selectAge = value;
                OnPropertyChanged("SelectAge");
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
                      Deal deall = new Deal();
                      deall.Id_Deal = 1;
                      deall.Deal_Date = dlDate;
                      deall.Deal_Form_of_Payment = dlFPayment;
                      deall.Deal_Mortgage_Period = dlPeriod;
                      deall.Deal_Monthly_Payout = dlMPayout;
                      deall.Deal_Total_Cost = dlTotalCost;
                      deall.Deal_AgentShare_Cost = dlAgentShareCost;

                      deall.Deal_Seller_FK = selectCli1.Id_Client;
                      deall.Deal_Customer_FK = selectCli2.Id_Client;
                      deall.Deal_Property_FK = selectPro.Id_Property;
                      deall.Deal_Agent_FK = selectAge.Id_Agent;

                      db.Deal.Add(deall);
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

