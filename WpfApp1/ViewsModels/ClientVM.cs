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
    public class ClientVM : INotifyPropertyChanged
    {
        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
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
                      Client cliet = new Client();

                      ClientWindow cl = new ClientWindow(ClassWorkDB);
                      bool? res = cl.ShowDialog();

                      Clients.Clear();
                      foreach (Client client in ClassWorkDB.Client)
                      {
                          Clients.Add(client);
                      }
                      selectedClient = cliet;

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
                      Client cliet = new Client();

                      ClientWindow cl = new ClientWindow(ClassWorkDB, SelectedClient);
                      bool? res = cl.ShowDialog();

                      Clients.Clear();
                      foreach (Client client in ClassWorkDB.Client)
                      {
                          Clients.Add(client);
                      }
                      selectedClient = cliet;

                  }));
            }
        }

        AgencyDB ClassWorkDB;

        public ClientVM()
        {
            ClassWorkDB = new AgencyDB();
            Clients = new ObservableCollection<Client>(ClassWorkDB.Client.ToList());
        }
    }
}
