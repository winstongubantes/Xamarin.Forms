using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSlideOverMenu.Pages;
using Xamarin.Forms;

namespace CustomSlideOverMenu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LeftSlide_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeftSlidePage());
        }
    }
}
