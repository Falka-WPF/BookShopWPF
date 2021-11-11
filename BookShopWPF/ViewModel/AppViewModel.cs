using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopWPF.Data;
using BookShopWPF.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows;
using BookShopWPF.Models;
namespace BookShopWPF.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private DataManagerContainer _dmc;
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<ABGModel> ABGModels { get; set; }
        public ICommand RadioButtonCommand { get; set; }

        private string _selectedRadioButton;
        public string SelectedRadioButton
        {
            get { return _selectedRadioButton; }
            set {
                _selectedRadioButton = value;
                OnPropertyChange("Name");
                LoadList();
            }   
        }
        public AppViewModel()
        {
            _dmc = new DataManagerContainer();
            _dmc.Authors.Add(new Author() { FIO = "test" });
            
            _dmc.SaveChanges();
            Authors = new ObservableCollection<Author>();
            Genres = new ObservableCollection<Genre>();
            Publishers = new ObservableCollection<Publisher>();
            Books = new ObservableCollection<Book>();

            ABGModels = new ObservableCollection<ABGModel>();

            RadioButtonCommand = new RelayCommand((parametr)=>
            {
                SelectedRadioButton = (string)parametr;
            }, (obj)=> { return true; });

            LoadGenresList();
            LoadAuthorsList();
            LoadPublishersList();
            LoadBooksList();
        }

        private void SwitchProvider(string key)
        {
           
        }
        private void LoadList()
        {
            if(SelectedRadioButton == "Author")
            {
                // Load authors
                ABGModels.Clear();
                foreach (var item in Authors)
                {
                    ABGModels.Add(new ABGModel() {Id = item.Id, Name = item.FIO});
                }
            }
            else if (SelectedRadioButton == "Publisher")
            {
                // Load Publisher
                ABGModels.Clear();
                foreach (var item in Publishers)
                {
                    ABGModels.Add(new ABGModel() { Id = item.Id, Name = item.Name });
                }
            }
            else
            {
                // Load Genre
                foreach (var item in Genres)
                {
                    ABGModels.Add(new ABGModel() { Id = item.Id, Name = item.Name });
                }
            }
        }
        private void LoadBooksList()
        {
            Books.Clear();
            foreach (var item in _dmc.Books)
            {
                Books.Add(item);
            }
        }
        private void LoadGenresList()
        {
            Genres.Clear();
            foreach(var item in _dmc.GenreSet)
            {
                Genres.Add(item);
            }
        }
        private void LoadAuthorsList()
        {
            Authors.Clear();
            foreach (var item in _dmc.Authors)
            {
                Authors.Add(item);
            }
        }
        private void LoadPublishersList()
        {
            Publishers.Clear();
            foreach (var item in _dmc.Publishers)
            {
                Publishers.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName]string prop="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
