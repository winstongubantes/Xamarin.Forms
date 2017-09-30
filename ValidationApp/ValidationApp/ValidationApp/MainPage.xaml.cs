using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ValidationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //THIS IS NOT THE ELEGANT WAY (THIS SHOULD HAVE BEEN IN VIEWMDOEL)
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MoreAwesomeValidationPage());
        }
    }
}
