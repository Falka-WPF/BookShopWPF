using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopWPF.Commands;
using BookShopWPF.Data;
using BookShopWPF.View;

namespace BookShopWPF.ViewModel
{
    public class SalesViewModel
    {
        DataManagerContainer _dmc;
        public ObservableCollection<Sales> SalesList { get; set; }
        
        public SalesViewModel(DataManagerContainer dmc)
        {
            _dmc = dmc;
            SalesList = new ObservableCollection<Sales>();
            LoadSales();
        }
        private void LoadSales()
        {
            SalesList.Clear();
            foreach (Sales item in _dmc.Sales)
            {
                SalesList.Add(item);
            }
        }
    }
}
