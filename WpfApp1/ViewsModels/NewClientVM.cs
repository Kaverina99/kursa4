using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL;
using WpfApp1.ViewModels;
using Agency;

namespace WpfApp1.ViewsModels
{

    public class NewClientVM : INotifyPropertyChanged
    {
        AgencyDB db;
        ClientWindow win;
        bool add;
        public NewClientVM(AgencyDB context, ClientWindow w)
        {
            add = true;
            win = w;
            db = context;
        }
        Client client;
        public NewClientVM(AgencyDB context, ClientWindow w, Client cli)
        {
            add = false;
            win = w;
            db = context;
            Client_Name = cli.Client_Name;
            Client_Passport = cli.Client_Passport;
            Client_INN = cli.Client_INN;
            Client_BIK = cli.Client_BIK;
            Client_SNILS = cli.Client_SNILS;
            Client_Phone = cli.Client_Phone;
            client = cli;
        }

        string Client_Name;
        string Client_Passport;
        string Client_INN;
        string Client_BIK;
        string Client_SNILS;
        string Client_Phone;

        public string clName
        {
            get { return Client_Name; }
            set
            {
                Client_Name = value;
                OnPropertyChanged("Client_Name");
            }
        }

        public string clPassport
        {
            get { return Client_Passport; }
            set
            {
                Client_Passport = value;
                OnPropertyChanged("Client_Passport");
            }
        }
        public string clINN
        {
            get { return Client_INN; }
            set
            {
                Client_INN = value;
                OnPropertyChanged("Client_INN");
            }
        }
        public string clBIK
        {
            get { return Client_BIK; }
            set
            {
                Client_BIK = value;
                OnPropertyChanged("Client_BIK");
            }
        }
        public string clSNILS
        {
            get { return Client_SNILS; }
            set
            {
                Client_SNILS = value;
                OnPropertyChanged("Client_SNILS");
            }
        }
        public string clPhone
        {
            get { return Client_Phone; }
            set
            {
                Client_Phone = value;
                OnPropertyChanged("Client_Phone");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (add)
                {
                    return addCommand ??
                        (addCommand = new RelayCommand(obj =>
                        {
                            Client client = new Client();
                            client.Id_Client = 1;
                            client.Client_Name = clName;
                            client.Client_Passport = clPassport;
                            client.Client_INN = clINN;
                            client.Client_BIK = clBIK;
                            client.Client_SNILS = clSNILS;
                            client.Client_Phone = clPhone;
                            db.Client.Add(client);
                            db.SaveChanges();
                            win.Close();
                        }));
                }
                else
                {
                    return upDateCommand ??
                     (upDateCommand = new RelayCommand(obj =>
                     {
                         client.Client_BIK = Client_BIK;
                         client.Client_INN = Client_INN;
                         client.Client_Name = Client_Name;
                         client.Client_Passport = Client_Passport;
                         client.Client_Phone = Client_Phone;
                         client.Client_SNILS = Client_SNILS;
                         
                         db.SaveChanges();
                         win.Close();
                     }));
                }
               
            }
        }

        private RelayCommand upDateCommand;
        public RelayCommand UpDateCommand
        {
            get
            {
                return upDateCommand ??
                  (upDateCommand = new RelayCommand(obj =>
                  {
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

