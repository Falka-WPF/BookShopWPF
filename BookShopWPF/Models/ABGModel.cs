using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookShopWPF.Models
{
    public class ABGModel : INotifyPropertyChanged
    {
        //Author Publisher Genre model for list
        private int _id;
        public int Id { get { return _id; }
            set { _id = value; OnProperyChanged("Id"); } }
        private string _name;
        public string Name {
            get { return _name; }
            set { _name = value; OnProperyChanged("Name"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
