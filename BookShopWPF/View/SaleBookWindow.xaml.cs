using BookShopWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookShopWPF.View
{
    /// <summary>
    /// Логика взаимодействия для SalesControl.xaml
    /// </summary>
    public partial class SaleBookWindow : Window
    {

        public DateTime date;
        public SaleBookWindow()
        {
            InitializeComponent();
            sale_datepicker.SelectedDate = DateTime.Now;
            
        }

        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sale_datepicker.SelectedDate != null)
            {
                date = (DateTime)sale_datepicker.SelectedDate;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Date not selected!");
            }
            
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
