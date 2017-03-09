using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CustomSlideOverMenu.Models;
using Xamarin.Forms;
using MenuItem = CustomSlideOverMenu.Models.MenuItem;

namespace CustomSlideOverMenu.ViewModels
{
    public class MenuPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MenuItem> _menuList;
        private ObservableCollection<Message> _conversationList;

        private ICommand _showMenuCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        public Action ToggleMenuAction { get; set; }

        public MenuPageViewModel()
        {
            MenuList = new ObservableCollection<MenuItem>();

            MenuList.Add(new MenuItem() { Icon = "\uf1ab", Title = "Language"});
            MenuList.Add(new MenuItem() { Icon = "\uf06e", Title = "Vision" });
            MenuList.Add(new MenuItem() { Icon = "\uf18c", Title = "Emotion" });
            MenuList.Add(new MenuItem() { Icon = "\uf1ea", Title = "People" });
            MenuList.Add(new MenuItem() { Icon = "\uf2bb", Title = "Team" });
            MenuList.Add(new MenuItem() { Icon = "\uf19c", Title = "Company" });


            ConversationList = new ObservableCollection<Message>();
            ConversationList.Add(new Message() { Text = "Test"});
            ConversationList.Add(new Message() { Text = "Test" });
            ConversationList.Add(new Message() { Text = "Test" });
            ConversationList.Add(new Message() { Text = "Test" });
            ConversationList.Add(new Message() { Text = "Test" });
            ConversationList.Add(new Message() { Text = "Test" });
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

        public ObservableCollection<Message> ConversationList
        {
            get { return _conversationList; }
            set
            {
                _conversationList = value;
                OnPropertyChanged("ConversationList");
            }
        }

        public object ToggleMenuCommand
        {
            get
            {
                return _showMenuCommand = _showMenuCommand ?? new Command(() =>
                {
                    ToggleMenuAction?.Invoke();
                });
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
