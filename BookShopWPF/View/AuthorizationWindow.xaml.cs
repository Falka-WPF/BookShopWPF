using System;
using System.Collections.Generic;
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
using BookShopWPF.Data;

namespace BookShopWPF.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        DataManagerContainer _dmc;
        public AuthorizationWindow()
        {
            InitializeComponent();
            _dmc = new DataManagerContainer();
           // _dmc.Users.Add(new Users() { Username = "admin", Password = "admin" });
            //_dmc.SaveChanges();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text;
            string password = Password_TextBox.Password;
            var users = _dmc.Users.Where(user => (user.Username == username && user.Password == password)).FirstOrDefault();
            if (users!=null)
            {
                this.Hide();
                MainWindow mw = new MainWindow(_dmc);
                mw.Show();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Login failed!", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
            }
        }
    }
}
