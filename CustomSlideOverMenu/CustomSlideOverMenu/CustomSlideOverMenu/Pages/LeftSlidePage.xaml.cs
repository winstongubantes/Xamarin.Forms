using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomSlideOverMenu.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftSlidePage : ContentPage
    {
        public LeftSlidePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView) sender;

            if(listView.SelectedItem != null)
                listView.SelectedItem = null;
        }
    }
}
