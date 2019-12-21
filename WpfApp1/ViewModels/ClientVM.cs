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
    public class ClientVM : INotifyPropertyChanged
    {

        private ClientModel selectedClient;

        public ObservableCollection<ClientModel> Clients { get; set; }
        public ClientModel SelectedClient
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
                      ClientWindow cl = new ClientWindow();
                      cl.ShowDialog();
                      //ClientModel client = new ClientModel();
                      //Clients.Insert(0, client);
                      //SelectedClient = client;
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
                      ClientModel client = obj as ClientModel;
                      if (client != null)
                      {
                          Clients.Remove(client);
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (Clients.Count > 0 && selectedClient != null)));
            }
        }


        public ClientVM()
        {
            DBDataOperation ClassWorkDB = new DBDataOperation();
            Clients = new ObservableCollection<ClientModel>(ClassWorkDB.GetAllClients());


        }

    }
}
