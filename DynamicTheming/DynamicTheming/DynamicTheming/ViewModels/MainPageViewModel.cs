using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DynamicTheming.Annotations;
using DynamicTheming.Enums;

namespace DynamicTheming.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> _themeModels;

        public MainPageViewModel()
        {
            ThemeModels = new ObservableCollection<string>();

            foreach (var theme in Enum.GetValues(typeof(AppTheme)))
            {
                ThemeModels.Add(theme.ToString().Split('.').Last());
            }
        }

        public ObservableCollection<string> ThemeModels
        {
            get { return _themeModels; }
            set
            {
                _themeModels = value;
                OnPropertyChanged("ThemeModels");
            }
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
