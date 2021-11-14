using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookShopWPF.Data;

namespace BookShopWPF.ViewModel
{
    public class BookViewModel :INotifyPropertyChanged
    {
        private Book _book;
        public BookViewModel(Book book)
        {
            this._book = book;
        }
        public int Id {
            get { return _book.Id;}
            set { _book.Id = value; OnPropertyChanged("Id"); }}
        public string Title
        {
            get { return _book.Title; }
            set { Console.WriteLine("Changed!"); _book.Title = value; OnPropertyChanged("Title"); }
        }
        public string About
        {
            get { return _book.About; }
            set { _book.About = value; OnPropertyChanged("About"); }
        }
        public int Year
        {
            get { return _book.Year; }
            set { _book.Year = value; OnPropertyChanged("Year"); }
        }
        public int Pages
        {
            get { return _book.Pages; }
            set { _book.Pages = value; OnPropertyChanged("Pages"); }
        }
        public int PublisherId
        {
            get { return _book.PublisherId; }
            set { _book.PublisherId = value; OnPropertyChanged("PublisherId"); }
        }
        public int GenreId
        {
            get { return _book.GenreId; }
            set { _book.GenreId = value; OnPropertyChanged("GenreId"); }
        }
        public int AuthorId
        {
            get { return _book.AuthorId; }
            set { _book.AuthorId = value; OnPropertyChanged("AuthorId"); }
        }
        public double Price
        {
            get { return _book.Price; }
            set { _book.Price = value; OnPropertyChanged("Price"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
