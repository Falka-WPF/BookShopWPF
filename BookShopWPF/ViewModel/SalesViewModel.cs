using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopWPF.Commands;
using BookShopWPF.Data;
using BookShopWPF.View;
using BookShopWPF.Models;
namespace BookShopWPF.ViewModel
{
    public class SalesViewModel
    {
        DataManagerContainer _dmc;
        public ObservableCollection<Sales> SalesList { get; set; }
        
        public ObservableCollection<SortedOption> SortedOptions { get; set; }
        public SortedOption SelectedOption { get; set; }
        private RelayCommand _filterItems;
        public RelayCommand FilterItems
        {
            get { return _filterItems ?? (_filterItems = new RelayCommand((obj) => {
                if (SelectedOption.SortName == "Last sales")
                {
                    SalesList.Clear();
                    var LSales = _dmc.Sales.OrderByDescending(s => s.SaleDate).ToList();
                    foreach (Sales item in LSales)
                    {
                        SalesList.Add(item);
                    }
                }
                else
                {
                    LoadSales();
                }

                })); }
        }
        public SalesViewModel(DataManagerContainer dmc)
        {
            _dmc = dmc;
            SalesList = new ObservableCollection<Sales>();
            SortedOptions = new ObservableCollection<SortedOption>();
            LoadSales();
            LoadOptions();
        }

        private void LoadOptions()
        {
            SortedOptions.Clear();
            SortedOptions.Add(new SortedOption() { SortName = "Default" });
            SortedOptions.Add(new SortedOption() { SortName = "Last sales" });
            SelectedOption = SortedOptions[0];
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
