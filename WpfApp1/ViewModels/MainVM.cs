using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Controls;
using WpfApp1;
using System.Linq;
using BLL;
using BLL.Interfaces;
using DAL;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class MainVM : INotifyPropertyChanged
    {
        DBDataOperation db = new DBDataOperation();

        public MainVM()
        {
            IsAdmin = CurrentUser.Role == "Admin" ? true : false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #region Flags

        private bool isPastries;
        public bool IsPastries
        {
            get
            {
                return isPastries;
            }
            set
            {
                isPastries = value;
                OnPropertyChanged();
            }
        }

        private bool isOrders;
        public bool IsOrders
        {
            get
            {
                return isOrders;
            }
            set
            {
                isOrders = value;
                OnPropertyChanged();
            }
        }

        private bool isDiscounts;
        public bool IsDiscounts
        {
            get
            {
                return isDiscounts;
            }
            set
            {
                isDiscounts = value;
                OnPropertyChanged();
            }
        }

        private bool isStock;
        public bool IsStock
        {
            get
            {
                return isStock;
            }
            set
            {
                isStock = value;
                OnPropertyChanged();
            }
        }

        private bool isAdmin;
        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Pastries

        private List<Pastry> pastries;
        public List<Pastry> Pastries
        {
            get
            {
                return pastries;
            }
            set
            {
                pastries = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand viewAllPastries;
        public DelegateCommand ViewAllPastries
        {
            get
            {
                return viewAllPastries ??
                  (viewAllPastries = new DelegateCommand(obj =>
                  {
                      Pastries = db.GetAllPastries().Where(p => p.Stock_ID == null).ToList();
                      IsPastries = true;
                      IsOrders = false;
                      IsDiscounts = false;
                      IsStock = false;
                  }));
            }
        }

        private DelegateCommand setADiscount;
        public DelegateCommand SetADiscount
        {
            get
            {
                return setADiscount ??
                  (setADiscount = new DelegateCommand(obj =>
                  {
                      foreach (var item in obj as dynamic)
                      {
                          SetDiscountsWindow discountWindow = new SetDiscountsWindow();
                          discountWindow.DataContext = new DiscountViewModel(item as Pastry, db);
                          discountWindow.ShowDialog();
                      }
                  }));
            }
        }

        private DelegateCommand productsOrder;
        public DelegateCommand ProductsOrder
        {
            get
            {
                return productsOrder ??
                    (productsOrder = new DelegateCommand(obj =>
                    {
                        List<Pastry> SelectedPastries = new List<Pastry>();
                        foreach (var item in obj as dynamic)
                        {
                            SelectedPastries.Add(item as Pastry);
                        }
                        if (SelectedPastries.Count != 0)
                        {
                            OrderWindow orderWindow = new OrderWindow();
                            orderWindow.DataContext = new OrderViewModel(SelectedPastries);
                            orderWindow.ShowDialog();
                        }
                    }));
            }
        }

        #endregion

        #region Orders

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand viewAllOrders;
        public DelegateCommand ViewAllOrders
        {
            get
            {
                return viewAllOrders ??
                  (viewAllOrders = new DelegateCommand(obj =>
                  {
                      Orders = db.GetAllOrders();
                      IsOrders = true;
                      IsPastries = false;
                      IsDiscounts = false;
                      IsStock = false;
                  }));
            }
        }

        private DelegateCommand deleteOrder;
        public DelegateCommand DeleteOrder
        {
            get
            {
                return deleteOrder ??
                    (deleteOrder = new DelegateCommand(obj =>
                    {
                        if (obj != null)
                        {
                            db.DeleteOrder((obj as Order).ID);
                        }
                    }));
            }
        }

        private DelegateCommand acceptOrder;
        public DelegateCommand AcceptOrder
        {
            get
            {
                return acceptOrder ??
                    (acceptOrder = new DelegateCommand(obj =>
                    {
                        if (obj != null)
                        {
                            var order = obj as Order;
                            if (order.Status_ID != 3)
                            {
                                order.Status_ID = 3;
                                if (Pastries == null)
                                {
                                    Pastries = Pastries = db.GetAllPastries().Where(p => p.Stock_ID == null).ToList();
                                }
                                foreach (var orderLine in order.OrderLines)
                                {
                                    Pastries.Where(p => p.PastryType_ID == orderLine.Pastry.PastryType_ID).FirstOrDefault().Quantity += orderLine.Quantity;
                                }
                                db.UpdateOrder(order);
                            }
                        }
                    }));
            }
        }

        #endregion

        #region Discounts

        private ObservableCollection<Discount> discounts;
        public ObservableCollection<Discount> Discounts
        {
            get
            {
                return discounts;
            }
            set
            {
                discounts = value;
                OnPropertyChanged();
            }
        }

        private DelegateCommand deleteDiscount;
        public DelegateCommand DeleteDiscount
        {
            get
            {
                return deleteDiscount ??
                    (deleteDiscount = new DelegateCommand(obj =>
                    {
                        if (obj != null)
                        {
                            db.DeleteDiscount((obj as Discount).ID);
                        }
                    }));
            }
        }

        private DelegateCommand viewAllDiscounts;
        public DelegateCommand ViewAllDiscounts
        {
            get
            {
                return viewAllDiscounts ??
                  (viewAllDiscounts = new DelegateCommand(obj =>
                  {
                      Discounts = db.GetAllDiscounts();
                      IsDiscounts = true;
                      IsOrders = false;
                      IsPastries = false;
                      IsStock = false;
                  }));
            }
        }

        #endregion

        #region Stock

        private DelegateCommand viewStock;
        public DelegateCommand ViewStock
        {
            get
            {
                return viewStock ??
                    (viewStock = new DelegateCommand(obj =>
                    {
                        IsPastries = false;
                        IsOrders = false;
                        IsDiscounts = false;
                        StockWindow stockWindow = new StockWindow();
                        stockWindow.DataContext = new StockViewModel();
                        stockWindow.ShowDialog();
                        IsStock = false;

                    }));
            }
        }

        #endregion

        private DelegateCommand closeWindow;
        public DelegateCommand CloseWindow
        {
            get
            {
                return closeWindow ??
                    (closeWindow = new DelegateCommand(obj =>
                    {
                        var window = obj as MainWindow;
                        window.Close();
                    }));
            }
        }

    }
}
