using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicTheming.Enums;
using DynamicTheming.Helpers;
using Xamarin.Forms;

namespace DynamicTheming
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            AppTheme theme;

            Enum.TryParse(ThemePicker.SelectedItem.ToString(), out theme);

            Settings.Theme = theme;

            //refresh page
            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync(false);
        }
    }
}
