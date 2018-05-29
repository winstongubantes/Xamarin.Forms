using System;
using Xamarin.Forms;

namespace CustomIconizeFont.Controls
{
    public class FlatTabbedPage : TabbedPage
    {
        public static BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(FlatTabbedPage), null);
        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(FlatTabbedPage), 20d);

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public FlatTabbedPage()
        {
            CurrentPageChanged += OnCurrentPageChanged;
        }
        private void OnCurrentPageChanged(Object sender, EventArgs e)
        {
            MessagingCenter.Send(sender, IconToolbarItem.UpdateToolbarItemsMessage);
        }
    }
}