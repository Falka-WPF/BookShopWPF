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
        public BookViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.About = book.About;
            this.Year = book.Year;
            this.Pages = book.Pages;
            this.PublisherId = book.PublisherId;
            this.GenreId = book.GenreId;
            this.AuthorId = book.AuthorId;
            this.Price = book.Price;
        }
        private int _id { get; set; }
        public int Id {
            get { return _id;}
            set { _id = value; OnPropertyChanged("Id"); }}
        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set { Console.WriteLine("Changed!"); _title = value; OnPropertyChanged("Title"); }
        }
        private string _about { get; set; }
        public string About
        {
            get { return _about; }
            set { _about = value; OnPropertyChanged("About"); }
        }
        private int _year { get; set; }
        public int Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged("Year"); }
        }
        private int _pages { get; set; }
        public int Pages
        {
            get { return _pages; }
            set { _pages = value; OnPropertyChanged("Pages"); }
        }
        private int _publisherId { get; set; }
        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; OnPropertyChanged("PublisherId"); }
        }
        private int _genreId { get; set; }
        public int GenreId
        {
            get { return _genreId; }
            set { _genreId = value; OnPropertyChanged("GenreId"); }
        }
        private int _authorId { get; set; }
        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; OnPropertyChanged("AuthorId"); }
        }
        private double _price { get; set; }
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged("Price"); }
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
