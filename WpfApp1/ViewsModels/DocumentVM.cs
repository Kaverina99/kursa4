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
    public class DocumentVM : INotifyPropertyChanged
    {
        public ObservableCollection<Property> Propertys { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public ObservableCollection<Property> Prop { get; set; }
        Property selectProp;
        public Property SelectProp

        {
            get { return selectProp; }
            set
            {
                selectProp = value;
                OnPropertyChanged("SelectProp");
            }
        }

        AgencyDB ClassWorkDB;

        public DocumentVM()
        {
            ClassWorkDB = new AgencyDB();
            Propertys = new ObservableCollection<Property>(ClassWorkDB.Property.ToList());

            Prop = new ObservableCollection<Property>(ClassWorkDB.Property);

        }

    }
}
