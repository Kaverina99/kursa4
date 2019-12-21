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
    public class DealVM : INotifyPropertyChanged
    {

        private DealModel selectedDeal;

        public ObservableCollection<DealModel> Deals { get; set; }
        public DealModel SelectedDeal
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
                      DealModel deal = new DealModel();
                      Deals.Insert(0, deal);
                      SelectedDeal = deal;
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
                      DealModel deal = obj as DealModel;
                      if (deal != null)
                      {
                          Deals.Remove(deal);
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (Deals.Count > 0 && selectedDeal != null)));
            }
        }


        public DealVM()
        {
            DBDataOperation ClassWorkDB = new DBDataOperation();
            Deals = new ObservableCollection<DealModel>(ClassWorkDB.GetAllDeals());


        }

    }
}
