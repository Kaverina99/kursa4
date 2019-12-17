using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ClientVM : INotifyPropertyChanged
    {
        private ClientVModel client;

        public ClientVM(ClientVModel c)
        {
            client = c;
        }

        public string Title
        {
            get { return client.Title; }
            set
            {
                client.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return client.Company; }
            set
            {
                client.Company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return client.Price; }
            set
            {
                client.Price = value;
                OnPropertyChanged("Price");
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
