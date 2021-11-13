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
        public Author SelectedAuthor { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public Genre SelectedGenre { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }
        public Publisher SelectedPublisher { get; set; }
        public ObservableCollection<BookViewModel> Books { get; set; }
        private BookViewModel _selectedBook;
        public BookViewModel SelectedBook { get { return _selectedBook; } set {  _selectedBook = value;OnPropertyChange("SelectedBook"); } }
        public ObservableCollection<ABGModel> ABGModels { get; set; }
        public ABGModel _selectedABGModel;
        public ABGModel SelectedABGModel { get { return _selectedABGModel; } set { _selectedABGModel = value; OnPropertyChange("SelectedABGModel"); } }
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
            //_dmc.Authors.Add(new Author() { FIO = "test" });
            //_dmc.Publishers.Add(new Publisher() { Name = "Example publisher" });
            //_dmc.GenreSet.Add(new Genre() { Name = "Example genre" });
            //_dmc.SaveChanges();
            Authors = new ObservableCollection<Author>();
            Genres = new ObservableCollection<Genre>();
            Publishers = new ObservableCollection<Publisher>();
            Books = new ObservableCollection<BookViewModel>();

            ABGModels = new ObservableCollection<ABGModel>();

            RadioButtonCommand = new RelayCommand((parametr)=>
            {
                SelectedRadioButton = (string)parametr;
            }, (obj)=> { return true; });

            LoadGenresList();
            LoadAuthorsList();
            LoadPublishersList();
            LoadBooksList();
            LoadList();
        }

        private RelayCommand _addItem;
        public RelayCommand AddItem {
            get {
                return _addItem ?? (_addItem = new RelayCommand(
                    (obj) =>
                    {
                        if (SelectedRadioButton == "Author")
                        {
                            Author tmp = new Author() { FIO = "New author" };
                            _dmc.Authors.Add(tmp);
                            _dmc.SaveChanges();
                            LoadAuthorsList();
                            LoadList();
                        } else if (SelectedRadioButton == "Publisher") {
                            Publisher tmp = new Publisher() { Name = "New publisher" };
                            _dmc.Publishers.Add(tmp);
                            _dmc.SaveChanges();
                            LoadPublishersList();
                            LoadList();
                        }
                        else
                        {
                            Genre tmp = new Genre() { Name = "New genre" };
                            _dmc.GenreSet.Add(tmp);
                            _dmc.SaveChanges();
                            LoadGenresList();
                            LoadList();
                        }
                    }
                    ));
            }
        }
        private RelayCommand _updateItem;
        public RelayCommand UpdateItem
        {
            get { return _updateItem ?? (_updateItem = new RelayCommand(
                (obj) => {

                    var items = ABGModels.ToArray();
                    if (SelectedRadioButton == "Author")
                    {
                        foreach (var item in _dmc.Authors)
                        {
                            var Aitems = ABGModels.Where(s => s.Id == item.Id).ToList();
                            if (Aitems.ToList().Count > 0)
                            {
                                item.FIO = Aitems.FirstOrDefault().Name;
                            }
                        }
                    }
                    else if (SelectedRadioButton == "Publisher")
                    {
                        foreach (var item in _dmc.Publishers)
                        {
                            var Aitems = ABGModels.Where(s => s.Id == item.Id).ToList();
                            if (Aitems.ToList().Count > 0)
                            {
                                item.Name = Aitems.FirstOrDefault().Name;
                            }
                        }
                    }
                    else {
                        foreach (var item in _dmc.GenreSet)
                        {
                            var Aitems = ABGModels.Where(s => s.Id == item.Id).ToList();
                            if (Aitems.ToList().Count > 0)
                            {
                                item.Name = Aitems.FirstOrDefault().Name;
                            }
                        }
                    }
                    _dmc.SaveChanges();
                    LoadAuthorsList();
                    LoadPublishersList();
                    LoadGenresList();
                    MessageBox.Show("Sucessfully updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                })); 
            }
        }

        private RelayCommand _deleteItem;
        public RelayCommand DeleteItem
        {
            get {return _deleteItem ?? (_deleteItem = new RelayCommand(
                (obj) =>{
                    if (SelectedABGModel != null)
                    {
                        if (SelectedRadioButton == "Author")
                        {
                            _dmc.Authors.Remove(_dmc.Authors.Where(s => s.FIO == SelectedABGModel.Name).FirstOrDefault());
                        }
                        else if(SelectedRadioButton == "Publisher")
                        {
                            _dmc.Publishers.Remove(_dmc.Publishers.Where(s => s.Name == SelectedABGModel.Name).FirstOrDefault());
                            
                        } else
                        {
                            //Genre delete
                            _dmc.GenreSet.Remove(_dmc.GenreSet.Where(s => s.Name == SelectedABGModel.Name).FirstOrDefault());
                        }
                        _dmc.SaveChanges();
                        LoadAuthorsList();
                        LoadPublishersList();
                        LoadGenresList();
                        LoadList();
                        MessageBox.Show("Sucessuflly deleted!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                })); 
            }
        }

        private RelayCommand _addBook;
        public RelayCommand AddBook
        {
            get {
                return _addBook ?? (_addBook = new RelayCommand(
               (obj) =>
               {
                   if(SelectedAuthor!=null && SelectedGenre!=null && SelectedPublisher != null)
                   {
                       int AId = SelectedAuthor.Id;
                       int GId = SelectedGenre.Id;
                       int PId = SelectedPublisher.Id;
                       Book bk = new Book() { Id = 0, AuthorId = AId, GenreId = GId, PublisherId = PId, About = "New about", Title = "New title", Pages = 0, Year = 0, Price = 0 };
                       Books.Add(new BookViewModel(bk));
                       //_dmc.Books.Add(bk);
                       //_dmc.SaveChanges();
                      // LoadBooksList();
                   }
                   else
                   {
                       System.Windows.MessageBox.Show("Some items not selected.", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                   }
               }
               )); }
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
                ABGModels.Clear();
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
                Books.Add(new BookViewModel(item));
            }
        }
        private void LoadGenresList()
        {
            Genres.Clear();
            foreach(var item in _dmc.GenreSet)
            {
                Genres.Add(item);
            }
            if (Genres.Count > 0)
            {
                SelectedGenre = Genres[0];
            }
        }
        private void LoadAuthorsList()
        {
            Authors.Clear();
            foreach (var item in _dmc.Authors)
            {
                Authors.Add(item);
            }
            if (Authors.Count > 0)
            {
                SelectedAuthor = Authors[0];
            }
        }
        private void LoadPublishersList()
        {
            Publishers.Clear();
            foreach (var item in _dmc.Publishers)
            {
                Publishers.Add(item);
            }
            if (Publishers.Count > 0)
            {
                SelectedPublisher = Publishers[0];
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
