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
    public class DealVM : INotifyPropertyChanged
    {
        private Deal selectedDeal;

        public ObservableCollection<Deal> Deals { get; set; }
        public Deal SelectedDeal
        {
            get { return selectedDeal; }
            set
            {

                selectedDeal = value;
                OnPropertyChanged("SelectedDeal");
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
                      Deal deal = new Deal();

                      DealWindow pr = new DealWindow(ClassWorkDB);
                      bool? res = pr.ShowDialog();

                      Deals.Clear();
                      foreach (Deal dll in ClassWorkDB.Deal)
                      {
                          Deals.Add(dll);
                      }
                      selectedDeal = deal;
                  }));
            }
        }

        AgencyDB ClassWorkDB;

        public DealVM()
        {
            ClassWorkDB = new AgencyDB();
            Deals = new ObservableCollection<Deal>(ClassWorkDB.Deal.ToList());
        }
    }
}
