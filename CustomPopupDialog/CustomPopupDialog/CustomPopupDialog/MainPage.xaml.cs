using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomPopupDialog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnShowDialog.Clicked += BtnShowDialog_Clicked;
        }

        private void BtnShowDialog_Clicked(object sender, EventArgs e)
        {
            PopUpDialog.ShowDialog();
        }
    }
}
