using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopWPF.Data;

namespace BookShopWPF.ViewModel
{
    
    public class AppViewModel
    {
        private DataManagerContainer _dmc;
        public AppViewModel()
        {
            _dmc = new DataManagerContainer();
        }
    }
}
