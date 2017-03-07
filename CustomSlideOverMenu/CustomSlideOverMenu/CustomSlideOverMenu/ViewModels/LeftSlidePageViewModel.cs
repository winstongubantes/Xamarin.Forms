using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CustomSlideOverMenu.Models;

namespace CustomSlideOverMenu.ViewModels
{
    public class LeftSlidePageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MenuItem> _menuList;

        public event PropertyChangedEventHandler PropertyChanged;

        public LeftSlidePageViewModel()
        {
            MenuList = new ObservableCollection<MenuItem>();

            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People"});
            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People" });
            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People" });
            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People" });
            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People" });
            MenuList.Add(new MenuItem() { Icon = "\uf17a", Title = "People" });
        }

        public ObservableCollection<MenuItem> MenuList
        {
            get { return _menuList; }
            set
            {
                _menuList = value;
                OnPropertyChanged("MenuList");
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
